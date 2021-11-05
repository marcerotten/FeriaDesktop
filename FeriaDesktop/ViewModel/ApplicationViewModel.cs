using FeriaDesktop.Model;
using FeriaDesktop.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Application = FeriaDesktop.Model.Application;

namespace FeriaDesktop.ViewModel
{
    public class ApplicationViewModel : ObservableCollection<Model.Application>, INotifyPropertyChanged
    {
        #region Atribute
        private ICommand upApplicationCommand;
        private ICommand delApplicationCommand;
        private int selectedIndex;
        private string dni;
        private string displayName;
        private string codigo;
        private string fechaIni;
        private string fechaFin;
        public int idContrato;
        public int firmado;
        public int idUsuario;
        private ObservableCollection<User_info> users = new ObservableCollection<User_info>();
        #endregion

        #region Properties
        private ICommand getCreateApplicationCommand { get; set; }

        public ICommand GetCreateApplicationCommand
        {
            get { return getCreateApplicationCommand; }
            set
            {
                getCreateApplicationCommand = value;
            }
        }
        public ICommand UpApplicationCommand
        {
            get { return upApplicationCommand; }
            set
            {
                upApplicationCommand = value;
            }
        }
        public ICommand DelContractCommand
        {
            get { return delApplicationCommand; }
            set
            {
                delApplicationCommand = value;
            }
        }
        public int SelectedIndexOfCollection
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndexOfCollection");

                OnPropertyChanged("Dni");
                OnPropertyChanged("Codigo");
                OnPropertyChanged("DisplayName");
                OnPropertyChanged("FechaIni");
                OnPropertyChanged("FechaFin");
            }
        }
        public string Dni
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].Dni;
                }
                else
                {
                    return dni;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].Dni = value;
                }
                else
                {
                    dni = value;
                }
                OnPropertyChanged("Dni");
            }
        }
        public string DisplayName
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].DisplayName;
                }
                else
                {
                    return displayName;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].DisplayName = value;
                }
                else
                {
                    displayName = value;
                }
                OnPropertyChanged("DisplayName");
            }
        }
        [Required(ErrorMessage = "No debe ir vacío")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Ingrese al menos 4 carácteres")]
        public string Codigo
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].Codigo;
                }
                else
                {
                    return codigo;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    ValidateProperty(value, "Codigo");
                    this.Items[this.SelectedIndexOfCollection].Codigo = value;
                }
                else
                {
                    codigo = value;
                }
                OnPropertyChanged("Codigo");
            }
        }
        [Required(ErrorMessage = "Requerido          ")]
        public string FechaIni
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].FechaIni;
                }
                else
                {
                    return fechaIni;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    ValidateProperty(value, "FechaIni");
                    this.Items[this.SelectedIndexOfCollection].FechaIni = value;
                }
                else
                {
                    fechaIni = value;
                }
                OnPropertyChanged("FechaIni");
            }
        }
        [Required(ErrorMessage = "Requerido          ")]
        public string FechaFin
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].FechaFin;
                }
                else
                {
                    return fechaFin;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    ValidateProperty(value, "FechaFin");
                    this.Items[this.SelectedIndexOfCollection].FechaFin = value;
                }
                else
                {
                    fechaFin = value;
                }
                OnPropertyChanged("FechaFin");
            }
        }
        public int IdContrato
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].IdContrato;
                }
                else
                {
                    return idContrato;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].IdContrato = value;
                }
                else
                {
                    idContrato = value;
                }
                OnPropertyChanged("IdContrato");
            }
        }
        public int Firmado
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].Firmado;
                }
                else
                {
                    return firmado;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].Firmado = value;
                }
                else
                {
                    firmado = value;
                }
                OnPropertyChanged("Firmado");
            }
        }
        public int IdUsuario
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].IdUsuario;
                }
                else
                {
                    return idUsuario;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].IdUsuario = value;
                }
                else
                {
                    idUsuario = value;
                }
                OnPropertyChanged("IdUsuario");
            }
        }
        public IEnumerable<User_info> Users
        {
            get { return users; }
        }

        #endregion

        #region Constructors
        public ApplicationViewModel()
        {
            this.showApplications();
            UpApplicationCommand = new RelayCommand(param => this.upApplication());
            GetCreateApplicationCommand = new RelayCommand(param => this.getCreateContract());
            DelContractCommand = new RelayCommand(param => this.delContract());
        }
        #endregion

        #region Interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Methods and functions
        private async void showApplications()
        {
            this.Clear();
            var url = "https://feriavirtual-endpoints.herokuapp.com/api/contrato/3";

            using (HttpClient client = new HttpClient())

            {
                var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    List<Application> contracts = new List<Application>();
                    var res = response.Content.ReadAsStringAsync().Result;
                    var applicationList = JsonConvert.DeserializeObject<dynamic>(res);

                    foreach (var dato in applicationList)
                    {
                        Application application = new Application();

                        application.IdContrato = dato.idContrato;
                        application.IdUsuario = dato.idUsuario;
                        application.Dni = dato.dni;
                        string nom = Convert.ToString(dato.nombre);
                        string app1 = dato.apPaterno;
                        string app2 = dato.apMaterno;
                        string disp = nom + " " + app1 + " " + app2;
                        application.DisplayName = disp;
                        application.Firmado = dato.firmado;
                        application.Codigo = dato.codigo;
                        application.FechaIni = dato.fechaIni;
                        application.FechaFin = dato.fechaFin;

                        this.Add(application);
                    }
                }
                else
                {
                    //message.Content = $"Server error code {response.StatusCode}";
                }
            }
        }
        private async void upApplication()
        {
            
            //DateTime date = DateTime.ParseExact(this.FechaIni, "M/dd/yyyy hh:mm:ss tt", null);
            var id = this.IdContrato;

            var userObject = new
            {
                idUsuario = this.IdUsuario,
                codigo = this.Codigo,
                fechaIni = this.FechaIni,
                fechaFin = this.FechaFin,
                firmado = this.Firmado
            };


            var json = JsonConvert.SerializeObject(userObject);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"https://feriavirtual-endpoints.herokuapp.com/api/contrato/{id}";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.PutAsync(url, data);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();
                var userList = JsonConvert.DeserializeObject<dynamic>(res);
                string message = userList.msg;
                MessageBox.Show(message);

            }

            this.showApplications();

        }

        private async void delApplication()
        {
            var id = this.IdContrato;
            
            var url = $"https://feriavirtual-endpoints.herokuapp.com/api/contrato/{id}";
                
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();
                
                if (response.IsSuccessStatusCode)

                    MessageBox.Show("Contrato Eliminado!");
                this.showApplications();
            }
        }

        private void getCreateContract() //ver si aplica modificacion para Solicitudes
        {
            CreateContract win_menu = new CreateContract();
            win_menu.Show();
        }

        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }


        #endregion
    } 
}
