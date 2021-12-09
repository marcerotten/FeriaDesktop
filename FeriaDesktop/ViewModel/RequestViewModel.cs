using FeriaDesktop.Model;
using FeriaDesktop.View;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        private int idSolicitudProductos;
        private string nombre;
        private string apPaterno;
        private string dni;
        private RequestType solicitud;
        private int solTypeId;
        private string solName;
        private string estado;
        private string fecha;
        private int cantidad;
        private int idUsuario;
        private ObservableCollection<Request> requests = new ObservableCollection<Request>();
        private ObservableCollection<RequestType> statuses = new ObservableCollection<RequestType>();
        #endregion

        #region Properties

        public ILog Logger { get; set; }
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
                OnPropertyChanged("idSolicitudProductos");
                OnPropertyChanged("nombre");
                OnPropertyChanged("apPaterno");
                OnPropertyChanged("dni");
                OnPropertyChanged("solicitud");
                OnPropertyChanged("estado");
                OnPropertyChanged("cantidad");
                OnPropertyChanged("fecha");
                OnPropertyChanged("idUsuario");
            }
        }

        public string urlBase = ConfigurationManager.AppSettings[("urlBase")];



        public int IdSolicitudProductos
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].IdSolicitudProductos;
                }
                else
                {
                    return idSolicitudProductos;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].IdSolicitudProductos = value;
                }
                else
                {
                    idSolicitudProductos = value;
                }
                OnPropertyChanged("IdSolicitudProductos");
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
        public RequestType Solicitud
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].Solicitud;
                }
                else
                {
                    return solicitud;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].Solicitud = value;
                }
                else
                {
                    solicitud = value;
                }
                OnPropertyChanged("Solicitud");
            }
        }
        public int SolTypeId
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].SolTypeId;
                }
                else
                {
                    return solTypeId;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].SolTypeId = value;
                }
                else
                {
                    solTypeId = value;
                }
                OnPropertyChanged("SolTypeId");
            }
        }
        public string SolName
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].SolName;
                }
                else
                {
                    return solName;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].SolName = value;
                }
                else
                {
                    solName = value;
                }
                OnPropertyChanged("SolName");
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
        public int Cantidad
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].Cantidad;
                }
                else
                {
                    return cantidad;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].Cantidad = value;
                }
                else
                {
                    cantidad = value;
                }
                OnPropertyChanged("Cantidad");
            }
        }
        public string Fecha
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].Fecha;
                }
                else
                {
                    return fecha;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].Fecha = value;
                }
                else
                {
                    fecha = value;
                }
                OnPropertyChanged("Fecha");
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

        public IEnumerable<Request> Requests
        {
            get { return requests; }
        }
        public IEnumerable<RequestType> Statuses
        {
            get { return statuses; }
        }
        #endregion

        #region Constructors
        public RequestViewModel()
        {
            this.Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log4net.Config.XmlConfigurator.Configure();
            this.GetStatus();
            this.showRequests();
            
            UpRequestCommand = new RelayCommand(param => this.upRequest());
            DelRequestCommand = new RelayCommand(param => this.delRequest());
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
        private async void showRequests()
        {
            try
            {
                this.Logger.Info("showRequests In");
                this.Clear();
                var dataGet = ConfigurationManager.AppSettings[("getRequest")];
                var url = $"{urlBase}{dataGet}";
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

                            application.IdSolicitudProductos = dato.idSolicitudProductos;
                            application.Nombre = dato.nombre;
                            application.ApPaterno = dato.apPaterno;
                            application.Dni = dato.dni;
                            application.SolName = dato.solicitud;
                            string solicitud = dato.solicitud;
                            application.Solicitud = statuses.FirstOrDefault(x => x.Descripcion.ToUpper() == solicitud.ToUpper());
                            application.SolTypeId = application.Solicitud.IdTipoSol;
                            application.Estado = dato.estado;
                            application.Cantidad = dato.cantidad;
                            application.Fecha = dato.fecha;
                            application.IdUsuario = dato.idUsuario;

                            this.Add(application);
                        }
                    }
                    else
                    {
                        this.Logger.Warn(url + "/Server error code: " + response.StatusCode);
                    }
                    this.Logger.Info(url + "/" + response.StatusCode);
                }
                this.Logger.Info("getRequest Out");
            }
            catch (Exception e)
            {
                this.Logger.Error(e);
            }

        }
        private async void upRequest()
        {
            {
                try
                {
                    this.Logger.Info("upRequest In");
                    var id = this.IdSolicitudProductos;

                    var userObject = new
                    {
                        idUsuario = this.IdUsuario,
                        idTipoSolicitud = this.Solicitud.IdTipoSol,
                        idEstadoSolicitud = 21
                    };

                    var json = JsonConvert.SerializeObject(userObject);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var dataUp = ConfigurationManager.AppSettings[("upRequest")];
                    var url = $"{urlBase}{dataUp}{id}";

                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.PutAsync(url, data);
                        response.EnsureSuccessStatusCode();
                        if (response.IsSuccessStatusCode)
                        {
                            var res = await response.Content.ReadAsStringAsync();
                            var userList = JsonConvert.DeserializeObject<dynamic>(res);
                            string message = userList.msg;
                            MessageBox.Show(message);

                            var reqObject = new
                            {
                                idUsuario = this.IdUsuario,
                                idSolicitudProductos = this.IdSolicitudProductos
                            };

                            var json2 = JsonConvert.SerializeObject(reqObject);
                            var data2 = new StringContent(json2, Encoding.UTF8, "application/json");
                            var dataCreate = ConfigurationManager.AppSettings[("createRequest")];
                            var url_create = $"{urlBase}{dataCreate}";
                            using (HttpClient create = new HttpClient())
                            {
                                var response_create = await create.PostAsync(url_create, data2);
                                response_create.EnsureSuccessStatusCode();
                                if (response_create.IsSuccessStatusCode)
                                {
                                    var res2 = await response.Content.ReadAsStringAsync();
                                    var reqList = JsonConvert.DeserializeObject<dynamic>(res2);
                                    string message2 = reqList.msg;
                                    if (message2.Contains("editado"))
                                    {
                                        MessageBox.Show("Subasta creada");
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.Logger.Warn(url + "/Server error code: " + response.StatusCode);
                        }
                        this.Logger.Info(url + "/" + response.StatusCode);
                    }
                    this.Logger.Info("upRequest Out");

                    this.showRequests();
                }
                catch (Exception e)
                {
                    this.Logger.Error(e);
                }
            }

        }

        private async void delRequest()
        {
            {
                try
                {
                    this.Logger.Info("delRequest In");
                    var id = this.IdSolicitudProductos;

                    var userObject = new
                    {
                        idUsuario = this.IdUsuario,
                        idTipoSolicitud = this.Solicitud.IdTipoSol,
                        idEstadoSolicitud = 22
                    };

                    var json = JsonConvert.SerializeObject(userObject);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var dataUp = ConfigurationManager.AppSettings[("upRequest")];
                    var url = $"{urlBase}{dataUp}{id}";

                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.PutAsync(url, data);
                        response.EnsureSuccessStatusCode();
                        if (response.IsSuccessStatusCode)
                        {
                            var res = await response.Content.ReadAsStringAsync();
                            var userList = JsonConvert.DeserializeObject<dynamic>(res);
                            string message = userList.msg;
                            MessageBox.Show(message);
                        }
                        else
                        {
                            this.Logger.Warn(url + "/Server error code: " + response.StatusCode);
                        }
                        this.Logger.Info(url + "/" + response.StatusCode);
                    }
                    this.Logger.Info("delRequest Out");

                    this.showRequests();
                }
                catch (Exception e)
                {
                    this.Logger.Error(e);
                }
            }
        }

        private IEnumerable<RequestType> GetStatus()
        {

            this.statuses.Add(new RequestType { IdTipoSol = 1, Descripcion = "LOCAL" });
            this.statuses.Add(new RequestType { IdTipoSol = 2, Descripcion = "EXTERNA" });

            return this.statuses;
        }

        #endregion
    } 
}
