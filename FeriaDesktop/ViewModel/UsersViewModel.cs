using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using FeriaDesktop.View;
using FeriaDesktop.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;
using System.Windows;

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
        private string pais;
        private string rol;
        private string estado;
        private int terms;
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

        public string Pais
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
                OnPropertyChanged("Pais");
            }
        }

        public string Rol
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

        public string Estado
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

        #endregion

        #region Constructors
        public UsersViewModel()
        {
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
            DataTable dt = new DataTable();

            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellido Paterno");
            dt.Columns.Add("Apellido Materno");
            dt.Columns.Add("DNI");
            dt.Columns.Add("Dirección");
            dt.Columns.Add("Código Postal");
            dt.Columns.Add("Correo");
            dt.Columns.Add("Pais");
            dt.Columns.Add("Rol");
            dt.Columns.Add("Estado");
            dt.Columns.Add("Términos y Condiciones");

            //var json = JsonConvert.SerializeObject(userObject);
            //var data = new StringContent(json, Encoding.UTF8, "application/json");
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
                    var userList = JsonConvert.DeserializeObject<List<User_info>>(res);
                    //var userList = JsonConvert.DeserializeObject<dynamic>(res);

                    //message.Content = historyname;

                    foreach (var dato in userList)
                    {
                       
                        DataRow row = dt.NewRow();

                        //actividadEmpresa.Read(dato.IdActividadEmpresa);
                        //tipoEmpresa.Read(dato.IdTipoEmpresa);

                        row["Nombre"] = dato.Nombre;
                        row["Apellido Paterno"] = dato.ApPaterno;
                        row["Apellido Materno"] = dato.ApMaterno;
                        row["DNI"] = dato.Dni;
                        row["Dirección"] = dato.Direccion;
                        row["Código Postal"] = dato.CodPostal;
                        row["Correo"] = dato.Correo;
                        row["Pais"] = dato.Pais;
                        row["Rol"] = dato.Rol;
                        row["Estado"] = dato.Estado;
                        var terminos = dato.Terms;
                        if (terminos != 0)
                        {
                            row["Términos y Condiciones"] = "Rechazado";
                        }
                        else
                        {
                            row["Términos y Condiciones"] = "Aceptado";
                        }

                        dt.Rows.Add(row);
                        this.Add(dato);
                    }

                    //dgClients.ClearValue(ItemsControl.ItemsSourceProperty);
                    /*
                     * Para traerlo desde la clase
                    dgClientes.ItemsSource = userList; //dt.DefaultView;
                    */
                    //dgClients.ItemsSource = dt.DefaultView;
                    //dgClients.UpdateLayout();

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
                idPais = 1,
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
        #endregion
    }


}
