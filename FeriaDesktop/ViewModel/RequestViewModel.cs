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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FeriaDesktop.ViewModel
{
    public class RequestViewModel : ObservableCollection<Request>, INotifyPropertyChanged
    {
        #region Atribute
        private ICommand upRequestCommand;
        private ICommand delRequestCommand;
        private ICommand getRequestCommand;
        private int selectedIndex;
        private string dni;
        private string displayName;
        private string codigo;
        private string fechaIni;
        private string fechaFin;
        private int idUsuario;
        private int idSolProd;
        private int idTipoSol;
        private int idEstadoSol;
        private int cantProd;
        private ObservableCollection<User_info> users = new ObservableCollection<User_info>();
        #endregion

        #region Properties
        public ICommand GetRequestCommand
        {
            get { return getRequestCommand; }
            set
            {
                getRequestCommand = value;
            }
        }
        public ICommand UpRequestCommand
        {
            get { return upRequestCommand; }
            set
            {
                upRequestCommand = value;
            }
        }
        public ICommand DelRequestCommand
        {
            get { return delRequestCommand; }
            set
            {
                delRequestCommand = value;
            }
        }
        public int SelectedIndexOfCollection
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndexOfCollection");

                //OnPropertyChanged("Dni");
                OnPropertyChanged("IdSolProd");
                OnPropertyChanged("Codigo");
                OnPropertyChanged("IdUsuario");
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
                    //ValidateProperty(value, "Codigo");
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
                    //ValidateProperty(value, "FechaIni");
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
                    //ValidateProperty(value, "FechaFin");
                    this.Items[this.SelectedIndexOfCollection].FechaFin = value;
                }
                else
                {
                    fechaFin = value;
                }
                OnPropertyChanged("FechaFin");
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

        public int IdSolProd
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].IdSolProd;
                }
                else
                {
                    return idSolProd;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].IdSolProd = value;
                }
                else
                {
                    idSolProd = value;
                }
                OnPropertyChanged("IdSolProd");
            }
        }
        public int IdTipoSol
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].IdTipoSol;
                }
                else
                {
                    return idTipoSol;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].IdTipoSol = value;
                }
                else
                {
                    idTipoSol = value;
                }
                OnPropertyChanged("IdTipoSol");
            }
        }
        public int IdEstadoSol
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].IdEstadoSol;
                }
                else
                {
                    return idEstadoSol;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].IdEstadoSol = value;
                }
                else
                {
                    idEstadoSol = value;
                }
                OnPropertyChanged("IdEstadoSol");
            }
        }
        public int CantProd
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].CantProd;
                }
                else
                {
                    return cantProd;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].CantProd = value;
                }
                else
                {
                    cantProd = value;
                }
                OnPropertyChanged("CantProd");
            }
        }
        public IEnumerable<User_info> Users
        {
            get { return users; }
        }

        #endregion

        #region Constructors
        public RequestViewModel()
        {
            this.showApplications();
           // UpRequestCommand = new RelayCommand(param => this.upApplication());
            //GetRequestCommand = new RelayCommand(param => this.getCreateContract());
            DelRequestCommand = new RelayCommand(param => this.asd());
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
            var url = "https://feriavirtual-endpoints.herokuapp.com/api/sol-prod/1";

            using (HttpClient client = new HttpClient())

            {
                var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    List<Request> applications = new List<Request>();
                    var res = response.Content.ReadAsStringAsync().Result;
                    var applicationList = JsonConvert.DeserializeObject<dynamic>(res);

                    foreach (var dato in applicationList)
                    {
                        Request application = new Request();
                        //id_solicitud_productos  id_usuario id_tipo_solicitud  id_estado_solicitud

                        //application.IdSolProd = dato.id_solicitud_productos;
                        application.IdUsuario = dato.idUsuario;
                        application.IdTipoSol = dato.idTipoSolicitud;
                        application.IdEstadoSol = dato.idEstadoSolicitud;
                        application.IdSolProd = dato.idSolicitudProductos;

                        //private int idSolProd;
                        //private int idUsuario;
                        // private int idTipoSol;

                        //applications.IdContrato = dato.idContrato;
                        //applications.IdUsuario = dato.idUsuario;
                        //applications.Dni = dato.dni;
                        //string nom = Convert.ToString(dato.nombre);
                        //string app1 = dato.apPaterno;
                        //string app2 = dato.apMaterno;
                        //string disp = nom + " " + app1 + " " + app2;
                        //applications.DisplayName = disp;
                        //applications.Firmado = dato.firmado;
                        //applications.Codigo = dato.codigo;
                        //applications.FechaIni = dato.fechaIni;
                        //applications.FechaFin = dato.fechaFin;

                        this.Add(application);
                    }
                }
                else
                {
                    //message.Content = $"Server error code {response.StatusCode}";
                }
            }
        }
        private async void upApplication(int idEstadoSol)
        {

            //DateTime date = DateTime.ParseExact(this.FechaIni, "M/dd/yyyy hh:mm:ss tt", null);
            var id = this.IdSolProd;

            var ApplyObject = new
            {
                idUsuario = this.IdUsuario,
                idTipoSolicitud = this.IdTipoSol,
                idEstadoSolicitud = idEstadoSol != this.IdEstadoSol? idEstadoSol:this.IdEstadoSol,
               
            };


            var json = JsonConvert.SerializeObject(ApplyObject);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"https://feriavirtual-endpoints.herokuapp.com/api/sol-prod/{id}"; 

            using (HttpClient client = new HttpClient())
            {
                var response = await client.PutAsync(url, data);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Solicitud modificada");

            }

            this.showApplications();
        }
        private async void delApplication()
        {
            this.upApplication(2);
            //var id = this.IdSolProd;
            //MessageBox.Show(id.ToString());


            //var url = $"https://feriavirtual-endpoints.herokuapp.com/api/sol-prod/{id}";

            //MessageBox.Show(url);


            //using (HttpClient client = new HttpClient())
            //{
            //    var response = await client.PutAsync(url, data); 
            //    response.EnsureSuccessStatusCode();
            //    var res = await response.Content.ReadAsStringAsync();

            //    if (response.IsSuccessStatusCode)
            //        MessageBox.Show("Solicitud Eliminada!");
            //    this.showApplications();
            //}
        }

        private async Task<Boolean> UpAuction()
        {


            var auctionObject = new
            {
                idUsuario = this.IdUsuario,

                idSolicitudProductos = this.IdSolProd

            };


            var json = JsonConvert.SerializeObject(auctionObject);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"https://feriavirtual-endpoints.herokuapp.com/api/subastas"; //url de subastas

            using (HttpClient client = new HttpClient())
            {
                var response = await client.PostAsync(url, data); //modificado a post
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();

                MessageBox.Show("Subasta creada");
                return true;
            }
            return false;
            //this.showApplications();

        }
        public async void asd()
        {
            this.IdSolProd = 21;
            this.IdUsuario = 163;
            var status = await this.UpAuction();
            
            if (status)// {
            this.delApplication();
            }
        }

        #endregion
    }    

