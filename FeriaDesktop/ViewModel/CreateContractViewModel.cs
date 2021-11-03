using FeriaDesktop.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace FeriaDesktop.ViewModel
{
    public class CreateContractViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region Atribute
        private ICommand findClientCommand;
        private ICommand createContractCommand;
        private string displayName;
        private string dni;
        private int idUsuario;
        private string codigo;
        private string firmado;
        private string fechaIni;
        private string fechaFin;
        private ObservableCollection<User_info> users = new ObservableCollection<User_info>();
        #endregion

        #region Properties
        public ICommand FindClientCommand
        {
            get { return findClientCommand; }
            set
            {
                findClientCommand = value;
            }
        }
        public ICommand CreateContractCommand
        {
            get { return createContractCommand; }
            set
            {
                createContractCommand = value;
            }
        }

        public string Dni
        {
            get
            {
                return dni;
            }
            set
            {
                dni = value;
                OnPropertyChanged("Dni");
            }
        }
        public string DisplayName
        {
            get
            {
                return displayName;
            }
            set
            {
                displayName = value;
                OnPropertyChanged("DisplayName");
            }
        }
        public int IdUsuario
        {
            get
            {
                return idUsuario;
            }
            set
            {
                idUsuario = value;
                OnPropertyChanged("IdUsuario");
            }
        }
        [Required(ErrorMessage = "No debe ir vacío")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Ingrese al menos 4 carácteres")]
        public string Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                ValidateProperty(value, "Codigo");
                codigo = value;
                OnPropertyChanged("Codigo");
            }
        }
        public string Firmado
        {
            get
            {
                return firmado;
            }
            set
            {
                firmado = value;
                OnPropertyChanged("Firmado");
            }
        }
        [Required(ErrorMessage = "Requerido          ")]
        public string FechaFin
        {
            get
            {
                return fechaFin;
            }
            set
            {
                ValidateProperty(value, "FechaFin");
                fechaFin = value;
                OnPropertyChanged("FechaFin");
            }
        }

        [Required(ErrorMessage = "Requerido          ")]
        public string FechaIni
        {
            get
            {
              
                return fechaIni;
            }
            set
            {
                ValidateProperty(value, "FechaIni");
                fechaIni = value;
                OnPropertyChanged("FechaIni");
            }
        }


        #endregion
        public CreateContractViewModel()
        {
            FindClientCommand = new RelayCommand(param => this.findClient());
            CreateContractCommand = new RelayCommand(param => this.createContract());
        }

        private async void createContract()
        {
            
            var userObject = new
            {
                idUsuario = this.IdUsuario,
                firmado = 1,
                codigo = this.Codigo,
                fechaIni = this.FechaIni,
                fechaFin = this.FechaFin
            };

            var json = JsonConvert.SerializeObject(userObject);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:8080/api/contrato";

            using (HttpClient client = new HttpClient())

            {
                var response = await client.PostAsync(url, data);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();
                var userList = JsonConvert.DeserializeObject<dynamic>(res);
                string message = userList.msg;
                MessageBox.Show(message);
                if (message.Contains("correcta"))
                {
                    //this.ClearAll();
                }

            }

            //this.Add(vlClient);
        }

        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }

        private User_info findClient()
        {
            //List<User_info> users = new List<User_info>();
            //this.Clear();
            var url = "http://localhost:8080/api/usuario/3";

            using (HttpClient client = new HttpClient())

            {
                var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    List<User_info> usuarios = new List<User_info>();
                    var res = response.Content.ReadAsStringAsync().Result;
                    var userList = JsonConvert.DeserializeObject<dynamic>(res);

                    foreach (var dato in userList)
                    {
                        User_info usuario = new User_info();
                        //usuario.IdUsuario = dato.idUsuario;
                        //usuario.Nombre = dato.nombre;
                        //usuario.ApPaterno = dato.apPaterno;
                        //usuario.ApMaterno = dato.apMaterno;
                        usuario.Dni = dato.dni;
                        
                        var dni = dato.dni;
                        if(dni == this.dni)
                        {
                            MessageBox.Show("encontrado");
                            string nom = Convert.ToString(dato.nombre);
                            string app1 = dato.apPaterno;
                            string app2 = dato.apMaterno;
                            string disp = nom + " " + app1 + " " + app2;
                            this.DisplayName = disp;
                            this.IdUsuario = dato.idUsuario;
                        }

                        this.users.Add(usuario);
                    }

                }
                else
                {
                    //message.Content = $"Server error code {response.StatusCode}";
                }
            }

            return this.users.FirstOrDefault(x => x.Dni == this.dni);
        }
    }
}
