using FeriaDesktop.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace FeriaDesktop.ViewModel
{
    public class CreateUserViewModel : ViewModelBase
    {
        #region Atribute
        private ICommand createUserCommand;
        private int selectedIndex;
        private int idUsuario;
        private string nombre;
        private string apPaterno;
        private string apMaterno;
        private string dni;
        private string direccion;
        private string codPostal;
        private string correo;
        private string usuario;
        private string contrasena;
        private Country pais;
        private string terms;
        private ObservableCollection<Country> countries = new ObservableCollection<Country>();
        #endregion

        #region Properties
        public ICommand CreateUserCommand
        {
            get { return createUserCommand; }
            set
            {
                createUserCommand = value;
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
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
                OnPropertyChanged("Nombre");
            }
        }

        public string ApPaterno
        {
            get
            {
                return apPaterno;

            }
            set
            {
                apPaterno = value;
                OnPropertyChanged("ApPaterno");
            }
        }

        public string ApMaterno
        {
            get
            {
                return apMaterno;

            }
            set
            {
                apMaterno = value;
                OnPropertyChanged("ApMaterno");
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

        public string Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                direccion = value;
                OnPropertyChanged("Direccion");
            }
        }

        public string CodPostal
        {
            get
            {
                return codPostal;
            }
            set
            {
                codPostal = value;
                OnPropertyChanged("CodPostal");
            }
        }

        public string Correo
        {
            get
            {
                return correo;
            }
            set
            {
                correo = value;
                OnPropertyChanged("Correo");
            }
        }
        public string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
                OnPropertyChanged("Usuario");
            }
        }

        public string Contrasena
        {
            get
            {
                return contrasena;
            }
            set
            {
                contrasena = value;
                OnPropertyChanged("Contrasena");
            }
        }
        public Country Pais
        {
            get
            {
                return pais;
            }
            set
            {
                pais = value;
                OnPropertyChanged("Pais");
            }
        }
        public string Terms
        {
            get
            {
                return terms;
            }
            set
            {
                terms = value;
                OnPropertyChanged("Terms");
            }
        }

        public IEnumerable<Country> Countries
        {
            get { return countries; }
        }
        #endregion

        public CreateUserViewModel()
        {
            this.GetCountries();
            CreateUserCommand = new RelayCommand(param => this.createUser());
        }

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

        private IEnumerable<Country> GetCountries()
        {
            var url = "http://localhost:8080/api/pais";

            using (HttpClient client = new HttpClient())

            {
                var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    List<Country> countries = new List<Country>();
                    var res = response.Content.ReadAsStringAsync().Result;
                    var countryList = JsonConvert.DeserializeObject<dynamic>(res);

                    foreach (var dato in countryList)
                    {
                        Country country = new Country();

                        country.IdPais = dato.idPais;
                        country.Descripcion = dato.descripcion;

                        this.countries.Add(country);
                    }

                }
                else
                {
                    //message.Content = $"Server error code {response.StatusCode}";
                }
            }
            return this.countries;
        }

        private async void createUser()
        {
            var userObject = new
            {
                nombre = this.Nombre,
                apPaterno = this.ApPaterno,
                apMaterno = this.ApMaterno,
                dni = this.Dni,
                direccion = this.Direccion,
                codPostal = this.CodPostal,
                correo = this.Correo,
                usuario = this.Usuario,
                contrasena = this.Contrasena,
                idPais = this.Pais.IdPais,
                idRol = 3,
                idEstado = 1,
                terminosCondiciones = 0
            };

            var json = JsonConvert.SerializeObject(userObject);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:8080/api/usuario";

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
                    this.ClearAll();
                }

            }

            //this.Add(vlClient);
        }

        public void ClearAll()
        {
           this.Nombre = string.Empty;
           this.ApPaterno = string.Empty;
           this.ApMaterno = string.Empty;
           this.Dni = string.Empty;
            this.Direccion = string.Empty;
            this.CodPostal = string.Empty;
            this.Correo = string.Empty;
            this.Usuario = string.Empty;
            this.Contrasena = string.Empty;
            //this.Pais.IdPais = 0;

        }
    }
}
