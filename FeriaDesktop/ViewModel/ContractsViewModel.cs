using FeriaDesktop.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace FeriaDesktop.ViewModel
{
    public class ContractsViewModel : ObservableCollection<Contract>, INotifyPropertyChanged
    {
        #region Atribute
        private ICommand upContractCommand;
        private ICommand findClientCommand;
        private ICommand createContractCommand;
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
        public ICommand CreateContractCommand
        {
            get { return createContractCommand; }
            set
            {
                createContractCommand = value;
            }
        }
        public ICommand UpContractCommand
        {
            get { return upContractCommand; }
            set
            {
                upContractCommand = value;
            }
        }
        public ICommand FindClientCommand
        {
            get { return findClientCommand; }
            set
            {
                findClientCommand = value;
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
                    this.Items[this.SelectedIndexOfCollection].Codigo = value;
                }
                else
                {
                    codigo = value;
                }
                OnPropertyChanged("Codigo");
            }
        }
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
                    this.Items[this.SelectedIndexOfCollection].FechaIni = value;
                }
                else
                {
                    fechaIni = value;
                }
                OnPropertyChanged("FechaIni");
            }
        }
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
                    return dni;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].FechaFin = value;
                }
                else
                {
                    dni = value;
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
        public ContractsViewModel()
        {
            this.showContracts();
            UpContractCommand = new RelayCommand(param => this.upContract());
            CreateContractCommand = new RelayCommand(param => this.createContract());
            FindClientCommand = new RelayCommand(param => this.findClient());
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
        private async void showContracts()
        {
            this.Clear();
            var url = "http://localhost:8080/api/usuario/3";

            using (HttpClient client = new HttpClient())

            {
                var response = client.GetAsync(url).Result;
                Console.WriteLine("antes de status code");
                response.EnsureSuccessStatusCode();
                Console.WriteLine("despues de status code");
                if (response.IsSuccessStatusCode)
                {
                    List<Contract> contracts = new List<Contract>();
                    var res = response.Content.ReadAsStringAsync().Result;
                    var contractList = JsonConvert.DeserializeObject<dynamic>(res);

                    foreach (var dato in contractList)
                    {
                        Contract contract = new Contract();

                        contract.IdUsuario = dato.idUsuario;
                        //contract.Nombre = dato.nombre;
                        //contract.ApPaterno = dato.apPaterno;
                        //contract.ApMaterno = dato.apMaterno;
                        contract.Dni = dato.dni;

                        this.Add(contract);
                    }
                }
                else
                {
                    //message.Content = $"Server error code {response.StatusCode}";
                }
            }
        }
        private async void upContract()
        {
            var id = this.IdContrato;

            var userObject = new
            {
                fechaIni = this.FechaIni,
                fechaFin = this.FechaFin,
                firmado = this.Firmado
            };


            var json = JsonConvert.SerializeObject(userObject);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"http://localhost:8080/api/usuario/{id}";//CAMBIAR API

            using (HttpClient client = new HttpClient())
            {
                var response = await client.PutAsync(url, data);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();
                var userList = JsonConvert.DeserializeObject<dynamic>(res);
                string message = userList.msg;
                MessageBox.Show(message);

            }

            this.showContracts();

        }

        private async void createContract()
        {
            var id = this.IdUsuario;

            var url = $"http://localhost:8080/api/usuario/{id}";//CAMBIAR API

            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();
                //var userList = JsonConvert.DeserializeObject<dynamic>(res);
                if (response.IsSuccessStatusCode)

                    MessageBox.Show("Usuario Desactivado!");
                this.showContracts();
            }
        }

        private User_info findClient()
        {
            //List<User_info> users = new List<User_info>();
            this.Clear();
            var url = "http://localhost:8080/api/usuario/3";

            using (HttpClient client = new HttpClient())

            {
                var response = client.GetAsync(url).Result;
                Console.WriteLine("antes de status code");
                response.EnsureSuccessStatusCode();
                Console.WriteLine("despues de status code");
                if (response.IsSuccessStatusCode)
                {
                    List<User_info> usuarios = new List<User_info>();
                    var res = response.Content.ReadAsStringAsync().Result;
                    var userList = JsonConvert.DeserializeObject<dynamic>(res);

                    foreach (var dato in userList)
                    {
                        User_info usuario = new User_info();

                        usuario.IdUsuario = dato.idUsuario;
                        usuario.Nombre = dato.nombre;
                        usuario.ApPaterno = dato.apPaterno;
                        usuario.ApMaterno = dato.apMaterno;
                        usuario.Dni = dato.dni;

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

        
        #endregion
    } 
}
