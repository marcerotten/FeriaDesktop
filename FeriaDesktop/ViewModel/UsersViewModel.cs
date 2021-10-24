using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using FeriaDesktop.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Linq;

namespace FeriaDesktop.ViewModel
{
    public class UsersViewModel : ObservableCollection<User_info>, INotifyPropertyChanged
    {
        #region Atribute
        private ICommand upUserCommand;// { get; set; }
        private ICommand delUserCommand;
        private int selectedIndex;
        private int idUsuario;
        private string nombre;
        private string apPaterno;
        private string apMaterno;
        private string dni;
        private string direccion;
        private string codPostal;
        private string correo;
        private Country pais;
        private Role rol;
        private Status estado;
        private int terms;
        private ObservableCollection<Role> roles = new ObservableCollection<Role>();
        private ObservableCollection<Country> countries = new ObservableCollection<Country>();
        private ObservableCollection<Status> statuses = new ObservableCollection<Status>();
        #endregion

        #region Properties
        public ICommand UpUserCommand
        {
            get { return upUserCommand; }
            set
            {
                upUserCommand = value;
            }
        }

        public ICommand DelUserCommand
        {
            get { return delUserCommand; }
            set
            {
                delUserCommand = value;
            }
        }

        public int SelectedIndexOfCollection
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndexOfCollection");

                OnPropertyChanged("Nombre");
                OnPropertyChanged("ApPaterno");
                OnPropertyChanged("ApMaterno");
                OnPropertyChanged("Dni");
                OnPropertyChanged("Direccion");
                OnPropertyChanged("CodPostal");
                OnPropertyChanged("Correo");
                OnPropertyChanged("Pais");
                OnPropertyChanged("Rol");
                OnPropertyChanged("Estado");
                OnPropertyChanged("Terms");
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
        public string Nombre
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].Nombre;
                }
                else
                {
                    return nombre;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].Nombre = value;
                }
                else
                {
                    nombre = value;
                }
                OnPropertyChanged("Nombre");
            }
        }

        public string ApPaterno
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].ApPaterno;
                }
                else
                {
                    return apPaterno;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].ApPaterno = value;
                }
                else
                {
                    apPaterno = value;
                }
                OnPropertyChanged("ApPaterno");
            }
        }

        public string ApMaterno
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].ApMaterno;
                }
                else
                {
                    return apMaterno;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].ApMaterno = value;
                }
                else
                {
                    apMaterno = value;
                }
                OnPropertyChanged("ApMaterno");
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

        public string Direccion
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].Direccion;
                }
                else
                {
                    return direccion;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].Direccion = value;
                }
                else
                {
                    direccion = value;
                }
                OnPropertyChanged("Direccion");
            }
        }

        public string CodPostal
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].CodPostal;
                }
                else
                {
                    return codPostal;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].CodPostal = value;
                }
                else
                {
                    codPostal = value;
                }
                OnPropertyChanged("CodPostal");
            }
        }

        public string Correo
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].Correo;
                }
                else
                {
                    return correo;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].Correo = value;
                }
                else
                {
                    correo = value;
                }
                OnPropertyChanged("Correo");
            }
        }

        public Country Pais
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].Pais;
                }
                else
                {
                    return pais;
                }
                //return pais;
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].Pais = value;
                }
                else
                {
                    pais = value;
                }
                //pais = value;
                OnPropertyChanged("Pais");
            }
        }

        public Role Rol
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].Rol;
                }
                else
                {
                    return rol;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].Rol = value;
                }
                else
                {
                    rol = value;
                }
                OnPropertyChanged("Rol");
            }
        }

        public Status Estado
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].Estado;
                }
                else
                {
                    return estado;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].Estado = value;
                }
                else
                {
                    estado = value;
                }
                OnPropertyChanged("Estado");
            }
        }

        public int Terms
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].Terms;
                }
                else
                {
                    return terms;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].Terms = value;
                }
                else
                {
                    terms = value;
                }
                OnPropertyChanged("Terms");
            }
        }

        public IEnumerable<Country> Countries
        {
            get { return countries; }
        }

        public IEnumerable<Role> Roles
        {
            get { return roles; }
        }

        public IEnumerable<Status> Statuses
        {
            get { return statuses; }
        }
        #endregion

        #region Constructors
        public UsersViewModel()
        {
            this.GetCountries();
            this.GetRoles();
            this.GetStatus();
            this.showUsers();
            UpUserCommand = new RelayCommand(param => this.upUser());
            DelUserCommand = new RelayCommand(param => this.delUser());
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
        private async void showUsers()
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
                        usuario.Direccion = dato.direccion;
                        usuario.CodPostal = dato.codPostal;
                        usuario.Correo = dato.correo;
                        string pais = dato.pais;
                        usuario.Pais = countries.FirstOrDefault(x => x.Descripcion == pais);//pais.Replace("{", "").Replace("}", "")
                        usuario.PaisName = usuario.Pais.Descripcion;
                        string rol = dato.rol;
                        usuario.Rol = roles.FirstOrDefault(x => x.Descripcion.ToUpper() == rol.ToUpper());
                        usuario.RolName = usuario.Rol.Descripcion;
                        string estado = dato.estado;
                        usuario.Estado = statuses.FirstOrDefault(x => x.Descripcion.ToUpper() == estado.ToUpper());
                        usuario.EstadoName = usuario.Estado.Descripcion;

                        this.Add(usuario);
                    }

                }
                else
                {
                    //message.Content = $"Server error code {response.StatusCode}";
                }
            }

        }

        private async void upUser()
        {
            var id = this.IdUsuario;

            var userObject = new
            {
                nombre = this.Nombre,
                apPaterno = this.ApPaterno,
                apMaterno = this.ApMaterno,
                dni = this.Dni,
                direccion = this.Direccion,
                codPostal = this.CodPostal,
                correo = this.Correo,
                usuario = "usertest2",
                contrasena = "test123",
                idPais = this.Pais.IdPais,
                idRol = 1,
                idEstado = 1,
                terms = this.Terms
            };


            var json = JsonConvert.SerializeObject(userObject);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"http://localhost:8080/api/usuario/{id}";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.PutAsync(url, data);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();
                var userList = JsonConvert.DeserializeObject<dynamic>(res);
            }

            this.showUsers();

        }

        private async void delUser()
        {
            var id = this.IdUsuario;

            var url = $"http://localhost:8080/api/usuario/{id}";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();
                //var userList = JsonConvert.DeserializeObject<dynamic>(res);
                if (response.IsSuccessStatusCode)
                   
                    MessageBox.Show("Usuario Desactivado!");
                    this.showUsers();
            }
        }

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

            //this.countries.Add(new Country { Id = 1, Descripcion = "CHILE" });
            //this.countries.Add(new Country { Id = 2, Descripcion = "ESPAÑA" });
            //this.countries.Add(new Country { Id = 3, Descripcion = "ITALIA" });

            return this.countries;
        }

        private IEnumerable<Role> GetRoles()
        {
            //var url = "http://localhost:8080/api/pais";

            //using (HttpClient client = new HttpClient())

            //{
            //    var response = client.GetAsync(url).Result;
            //    response.EnsureSuccessStatusCode();

            //    if (response.IsSuccessStatusCode)
            //    {
            //        List<Role> roles = new List<Role>();
            //        var res = response.Content.ReadAsStringAsync().Result;
            //        var roleList = JsonConvert.DeserializeObject<dynamic>(res);

            //        foreach (var dato in roleList)
            //        {
            //            Role role = new Role();

            //            role.IdRol = dato.idRol;
            //            role.Descripcion = dato.descripcion;

            //            this.roles.Add(role);
            //        }

            //    }
            //    else
            //    {
            //        //message.Content = $"Server error code {response.StatusCode}";
            //    }
            //}

            this.roles.Add(new Role { IdRol = 1, Descripcion = "ADMIN" });
            this.roles.Add(new Role { IdRol = 2, Descripcion = "PRODUCTOR" });

            return this.roles;
        }

        private IEnumerable<Status> GetStatus()
        {
            //var url = "http://localhost:8080/api/pais";

            //using (HttpClient client = new HttpClient())

            //{
            //    var response = client.GetAsync(url).Result;
            //    response.EnsureSuccessStatusCode();

            //    if (response.IsSuccessStatusCode)
            //    {
            //        List<Role> roles = new List<Role>();
            //        var res = response.Content.ReadAsStringAsync().Result;
            //        var roleList = JsonConvert.DeserializeObject<dynamic>(res);

            //        foreach (var dato in roleList)
            //        {
            //            Role role = new Role();

            //            role.IdRol = dato.idRol;
            //            role.Descripcion = dato.descripcion;

            //            this.roles.Add(role);
            //        }

            //    }
            //    else
            //    {
            //        //message.Content = $"Server error code {response.StatusCode}";
            //    }
            //}

            this.statuses.Add(new Status { IdEstado = 1, Descripcion = "ACTIVADO" });
            this.statuses.Add(new Status { IdEstado = 2, Descripcion = "DESACTIVADO" });

            return this.statuses;
        }
        #endregion
    }


}
