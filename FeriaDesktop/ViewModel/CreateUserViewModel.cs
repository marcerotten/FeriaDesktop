using FeriaDesktop.Model;
using log4net;
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
        public ILog Logger { get; set; }
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
        [Required(ErrorMessage = "No debe ir vacío")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Ingrese sólo letras")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ingrese al menos 2 carácteres")]
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                ValidateProperty(value, "Nombre");
                nombre = value;
                OnPropertyChanged("Nombre");
            }
        }

        [Required(ErrorMessage = "No debe ir vacío")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Ingrese sólo letras")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ingrese al menos 2 carácteres")]
        public string ApPaterno
        {
            get
            {
                return apPaterno;

            }
            set
            {
                ValidateProperty(value, "ApPaterno");
                apPaterno = value;
                OnPropertyChanged("ApPaterno");
            }
        }

        [Required(ErrorMessage = "No debe ir vacío")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Ingrese sólo letras")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ingrese al menos 2 carácteres")]
        public string ApMaterno
        {
            get
            {
                return apMaterno;

            }
            set
            {
                ValidateProperty(value, "ApMaterno");
                apMaterno = value;
                OnPropertyChanged("ApMaterno");
            }
        }

        [Required(ErrorMessage = "No debe ir vacío")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Ingrese al menos 8 carácteres")]
        public string Dni
        {
            get
            {
                return dni;

            }
            set
            {
                ValidateProperty(value, "Dni");
                dni = value;
                OnPropertyChanged("Dni");
            }
        }

        [Required(ErrorMessage = "No debe ir vacío")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Ingrese al menos 5 carácteres")]
        public string Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                ValidateProperty(value, "Direccion");
                direccion = value;
                OnPropertyChanged("Direccion");
            }
        }

        [Required(ErrorMessage = "No debe ir vacío")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Ingrese al menos 4 carácteres")]
        public string CodPostal
        {
            get
            {
                return codPostal;
            }
            set
            {
                ValidateProperty(value, "CodPostal");
                codPostal = value;
                OnPropertyChanged("CodPostal");
            }
        }

        [Required(ErrorMessage = "No debe ir vacío")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Ingrese al menos 5 carácteres")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail no valido")]
        public string Correo
        {
            get
            {
                return correo;
            }
            set
            {
                ValidateProperty(value, "Correo");
                correo = value;
                OnPropertyChanged("Correo");
            }
        }
        [Required(ErrorMessage = "No debe ir vacío")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Ingrese al menos 4 carácteres")]
        public string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                ValidateProperty(value, "Usuario");
                usuario = value;
                OnPropertyChanged("Usuario");
            }
        }

        [Required(ErrorMessage = "No debe ir vacío")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Ingrese al menos 4 carácteres")]
        public string Contrasena
        {
            get
            {
                return contrasena;
            }
            set
            {
                ValidateProperty(value, "Contrasena");
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

        #region Constructors
        public CreateUserViewModel()
        {
            this.Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log4net.Config.XmlConfigurator.Configure();
            this.GetCountries();
            CreateUserCommand = new RelayCommand(param => this.createUser());
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

        private IEnumerable<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();
            try
            {
                this.Logger.Info("GetCountries In");
                var url = "https://feriavirtual-endpoints.herokuapp.com/api/pais";

                using (HttpClient client = new HttpClient())

                {
                    var response = client.GetAsync(url).Result;
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        //List<Country> countries = new List<Country>();
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
                        this.Logger.Warn(url + "/Server error code: " + response.StatusCode);
                    }
                    this.Logger.Info(url + "/" + response.StatusCode);
                }
                this.Logger.Info("GetCountries Out");
                return this.countries;
            }
            catch (Exception e)
            {
                this.Logger.Error(e);
                return this.countries;
            }
        }

        private async void createUser()
        {
            try
            {
                this.Logger.Info("createUser In");
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
                var url = "https://feriavirtual-endpoints.herokuapp.com/api/usuario";

                using (HttpClient client = new HttpClient())

                {
                    var response = await client.PostAsync(url, data);
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        var res = await response.Content.ReadAsStringAsync();
                        var userList = JsonConvert.DeserializeObject<dynamic>(res);
                        string message = userList.msg;
                        MessageBox.Show(message);
                        if (message.Contains("correcta"))
                        {
                            //this.ClearAll();
                        }
                    }
                    else
                    {
                        this.Logger.Warn(url + "/Server error code: " + response.StatusCode);
                    }
                    this.Logger.Info(url + "/" + response.StatusCode);
                }
                this.Logger.Info("createUser Out");

                //this.Add(vlClient);
            }
            catch (Exception e)
            {
                this.Logger.Error(e);
            }
        }

        //public void ClearAll()
        //{
        //   this.Nombre = string.Empty;
        //   this.ApPaterno = string.Empty;
        //   this.ApMaterno = string.Empty;
        //   this.Dni = string.Empty;
        //    this.Direccion = string.Empty;
        //    this.CodPostal = string.Empty;
        //    this.Correo = string.Empty;
        //    this.Usuario = string.Empty;
        //    this.Contrasena = string.Empty;
        //    //this.Pais.IdPais = 0;

        //}


        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }
    }
}
