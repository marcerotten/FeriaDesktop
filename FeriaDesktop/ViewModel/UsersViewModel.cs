﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using FeriaDesktop.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Linq;
using FeriaDesktop.View;
using System.ComponentModel.DataAnnotations;

namespace FeriaDesktop.ViewModel
{
    public class UsersViewModel : ObservableCollection<User_info>, INotifyPropertyChanged
    {
        #region Atribute
        private ICommand getCreateUserCommand;
        private ICommand upUserCommand;
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
        private string usuario;
        private Country pais;
        private Role rol;
        private Status estado;
        private string terms;
        private ObservableCollection<Role> roles = new ObservableCollection<Role>();
        private ObservableCollection<Country> countries = new ObservableCollection<Country>();
        private ObservableCollection<Status> statuses = new ObservableCollection<Status>();
        #endregion

        #region Properties
        

        public ICommand GetCreateUserCommand
        {
            get { return getCreateUserCommand; }
            set
            {
                getCreateUserCommand = value;
            }
        }
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
        [Required(ErrorMessage = "No debe ir vacío")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Ingrese sólo letras")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ingrese al menos 2 carácteres")]
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
                    ValidateProperty(value, "Nombre");
                    this.Items[this.SelectedIndexOfCollection].Nombre = value;
                }
                else
                {
                    nombre = value;
                }
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
                    ValidateProperty(value, "ApPaterno");
                    this.Items[this.SelectedIndexOfCollection].ApPaterno = value;
                }
                else
                {
                    apPaterno = value;
                }
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
                    ValidateProperty(value, "ApMaterno");
                    this.Items[this.SelectedIndexOfCollection].ApMaterno = value;
                }
                else
                {
                    apMaterno = value;
                }
                OnPropertyChanged("ApMaterno");
            }
        }

        [Required(ErrorMessage = "No debe ir vacío")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Ingrese al menos 8 carácteres")]
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
                    ValidateProperty(value, "Dni");
                    this.Items[this.SelectedIndexOfCollection].Dni = value;
                }
                else
                {
                    dni = value;
                }
                OnPropertyChanged("Dni");
            }
        }

        [Required(ErrorMessage = "No debe ir vacío")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Ingrese al menos 5 carácteres")]
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
                    ValidateProperty(value, "Direccion");
                    this.Items[this.SelectedIndexOfCollection].Direccion = value;
                }
                else
                {
                    direccion = value;
                }
                OnPropertyChanged("Direccion");
            }
        }

        [Required(ErrorMessage = "No debe ir vacío")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Ingrese al menos 4 carácteres")]
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
                    ValidateProperty(value, "CodPostal");
                    this.Items[this.SelectedIndexOfCollection].CodPostal = value;
                }
                else
                {
                    codPostal = value;
                }
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
                    ValidateProperty(value, "Correo");
                    this.Items[this.SelectedIndexOfCollection].Correo = value;
                }
                else
                {
                    correo = value;
                }
                OnPropertyChanged("Correo");
            }
        }
        public string Usuario
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].Usuario;
                }
                else
                {
                    return usuario;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].Usuario = value;
                }
                else
                {
                    usuario = value;
                }
                OnPropertyChanged("Usuario");
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

        public string Terms
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
            GetCreateUserCommand = new RelayCommand(param => this.getCreateUsers());
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
            var url = "https://feriavirtual-endpoints.herokuapp.com/api/usuario/3";

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

                        usuario.IdUsuario = dato.idUsuario;
                        usuario.Nombre = dato.nombre;
                        usuario.ApPaterno = dato.apPaterno;
                        usuario.ApMaterno = dato.apMaterno;
                        usuario.Dni = dato.dni;
                        usuario.Direccion = dato.direccion;
                        usuario.CodPostal = dato.codPostal;
                        usuario.Correo = dato.correo;
                        usuario.Usuario = dato.usuario;
                        string pais = dato.pais;
                        usuario.Pais = countries.FirstOrDefault(x => x.Descripcion == pais);
                        usuario.PaisName = usuario.Pais.Descripcion;
                        string rol = dato.rol;
                        usuario.Rol = roles.FirstOrDefault(x => x.Descripcion.ToUpper() == rol.ToUpper());
                        usuario.RolName = usuario.Rol.Descripcion;
                        string estado = dato.estado;
                        usuario.Estado = statuses.FirstOrDefault(x => x.Descripcion.ToUpper() == estado.ToUpper());
                        usuario.EstadoName = usuario.Estado.Descripcion;
                        usuario.Terms = dato.terminosCondiciones == 0 ? "SI":"NO";

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
                usuario = this.Usuario,
                idPais = this.Pais.IdPais,
                idRol = this.Rol.IdRol,
                //idEstado = this.Estado.IdEstado,
                terminosCondiciones = this.Terms == "SI" ? 0 : 1
        };


            var json = JsonConvert.SerializeObject(userObject);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"https://feriavirtual-endpoints.herokuapp.com/api/usuario/{id}";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.PutAsync(url, data);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();
                var userList = JsonConvert.DeserializeObject<dynamic>(res);
                string message = userList.msg;
                MessageBox.Show(message);
             
            }

            this.showUsers();

        }

        private async void delUser()
        {
            var id = this.IdUsuario;
            var estado = this.Estado.IdEstado;
            string url;
            string msg;

            if(estado == 1)
            {
                url = $"https://feriavirtual-endpoints.herokuapp.com/api/usuario/{id}/2";
                msg = "Usuario Desactivado!";
            }
            else
            {
                url = $"https://feriavirtual-endpoints.herokuapp.com/api/usuario/{id}/1";
                msg = "Usuario Activado!";
            }

            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();
                //var userList = JsonConvert.DeserializeObject<dynamic>(res);
                if (response.IsSuccessStatusCode)
                   
                    MessageBox.Show(msg);
                    this.showUsers();
            }
        }

        private IEnumerable<Country> GetCountries()
        {
            var url = "https://feriavirtual-endpoints.herokuapp.com/api/pais";

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

        private IEnumerable<Role> GetRoles()
        {
            var url = "https://feriavirtual-endpoints.herokuapp.com/api/rol";

            using (HttpClient client = new HttpClient())

            {
                var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    List<Role> roles = new List<Role>();
                    var res = response.Content.ReadAsStringAsync().Result;
                    var roleList = JsonConvert.DeserializeObject<dynamic>(res);

                    foreach (var dato in roleList)
                    {
                        Role role = new Role();

                        role.IdRol = dato.idRol;
                        role.Descripcion = dato.descripcion;

                        this.roles.Add(role);
                    }

                }
                else
                {
                    //message.Content = $"Server error code {response.StatusCode}";
                }
            }

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

        private void getCreateUsers()
        {
            CreateUser win_menu = new CreateUser();
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
