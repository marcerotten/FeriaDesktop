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
        private int idUsuario;
        private int idTipoSolicitud;
        private int idEstadoSolicitud;
        private string fecha;
        private ObservableCollection<Request> requests = new ObservableCollection<Request>();
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
                OnPropertyChanged("IdSolicitudProductos");
                OnPropertyChanged("IdUsuario");
                OnPropertyChanged("IdTipoSolicitud");
                OnPropertyChanged("IdEstadoSolicitud");
                OnPropertyChanged("Fecha");
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
        [Required(ErrorMessage = "Requerido          ")]
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
        [Required(ErrorMessage = "Requerido          ")]
        public int IdTipoSolicitud
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].IdTipoSolicitud;
                }
                else
                {
                    return idTipoSolicitud;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].IdTipoSolicitud = value;
                }
                else
                {
                    idTipoSolicitud = value;
                }
                OnPropertyChanged("IdTipoSolicitud");
            }
        }
        public int IdEstadoSolicitud
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].IdEstadoSolicitud;
                }
                else
                {
                    return IdEstadoSolicitud;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].IdEstadoSolicitud = value;
                }
                else
                {
                    idEstadoSolicitud = value;
                }
                OnPropertyChanged("IdEstadoSolicitud");
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
       
        public IEnumerable<Request> Requests
        {
            get { return requests; }
        }

        #endregion

        #region Constructors
        public RequestViewModel()
        {
            this.Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log4net.Config.XmlConfigurator.Configure();
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
                            application.IdUsuario = dato.idUsuario;
                            application.IdTipoSolicitud = dato.idTipoSolicitud;
                            application.IdEstadoSolicitud = dato.idEstadoSolicitud;
                            application.Fecha = dato.fecha;

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
                        idTipoSolicitud = this.IdTipoSolicitud,
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
                        idTipoSolicitud = this.IdTipoSolicitud,
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
        #endregion
    } 
}
