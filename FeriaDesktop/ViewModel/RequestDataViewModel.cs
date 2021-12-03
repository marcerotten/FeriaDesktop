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
using RequestData = FeriaDesktop.Model.RequestData;

namespace FeriaDesktop.ViewModel
{
    public class RequestDataViewModel : ObservableCollection<RequestData>, INotifyPropertyChanged
    {
        #region Atribute
        
        private ICommand upRequestDataCommand;
        private ICommand delRequestDataCommand;
        private ICommand getRequestDataCommand;
        private int selectedIndex;
       
        private string displayName;
        
        private int idSolProd;
        private int idUsuario;
        private int idTipoSol;
        private int idEstadoSol;
        private int cantProd;
        private ObservableCollection<RequestData> users = new ObservableCollection<RequestData>();

        #endregion

        #region Properties
        public ICommand GetRequestDataCommand
        {
            get { return getRequestDataCommand; }
            set
            {
                getRequestDataCommand = value;
            }
        }
        public ICommand UpRequestDataCommand
        {
            get { return upRequestDataCommand; }
            set
            {
                upRequestDataCommand = value;
            }
        }
        public ICommand DelRequestDataCommand
        {
            get { return delRequestDataCommand; }
            set
            {
                delRequestDataCommand = value;
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
                //OnPropertyChanged("IdUsuario");
                //OnPropertyChanged("IdTipoSol");
                //OnPropertyChanged("EstadoSol");
                //OnPropertyChanged("FechaFin");
                OnPropertyChanged("DisplayName");
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
        //[Required(ErrorMessage = "No debe ir vacío")]
        //[StringLength(50, MinimumLength = 4, ErrorMessage = "Ingrese al menos 4 carácteres")]
        //public string Codigo
        //{
        //    get
        //    {
        //        if (this.SelectedIndexOfCollection > -1)
        //        {
        //            return this.Items[this.SelectedIndexOfCollection].Codigo;
        //        }
        //        else
        //        {
        //            return codigo;
        //        }
        //    }
        //    set
        //    {
        //        if (this.SelectedIndexOfCollection > -1)
        //        {
        //            ValidateProperty(value, "Codigo");
        //            this.Items[this.SelectedIndexOfCollection].Codigo = value;
        //        }
        //        else
        //        {
        //            codigo = value;
        //        }
        //        OnPropertyChanged("Codigo");
        //    }
        //}
        //[Required(ErrorMessage = "Requerido          ")]
        //public string FechaIni
        //{
        //    get
        //    {
        //        if (this.SelectedIndexOfCollection > -1)
        //        {
        //            return this.Items[this.SelectedIndexOfCollection].FechaIni;
        //        }
        //        else
        //        {
        //            return fechaIni;
        //        }
        //    }
        //    set
        //    {
        //        if (this.SelectedIndexOfCollection > -1)
        //        {
        //            ValidateProperty(value, "FechaIni");
        //            this.Items[this.SelectedIndexOfCollection].FechaIni = value;
        //        }
        //        else
        //        {
        //            fechaIni = value;
        //        }
        //        OnPropertyChanged("FechaIni");
        //    }
        //}
        //[Required(ErrorMessage = "Requerido          ")]
        //public string FechaFin
        //{
        //    get
        //    {
        //        if (this.SelectedIndexOfCollection > -1)
        //        {
        //            return this.Items[this.SelectedIndexOfCollection].FechaFin;
        //        }
        //        else
        //        {
        //            return fechaFin;
        //        }
        //    }
        //    set
        //    {
        //        if (this.SelectedIndexOfCollection > -1)
        //        {
        //            ValidateProperty(value, "FechaFin");
        //            this.Items[this.SelectedIndexOfCollection].FechaFin = value;
        //        }
        //        else
        //        {
        //            fechaFin = value;
        //        }
        //        OnPropertyChanged("FechaFin");
        //    }
        //}

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
        //public int CantProd
        //{
        //    get
        //    {
        //        if (this.SelectedIndexOfCollection > -1)
        //        {
        //            return this.Items[this.SelectedIndexOfCollection].CantProd;
        //        }
        //        else
        //        {
        //            return cantProd;
        //        }
        //    }
        //    set
        //    {
        //        if (this.SelectedIndexOfCollection > -1)
        //        {
        //            this.Items[this.SelectedIndexOfCollection].CantProd = value;
        //        }
        //        else
        //        {
        //            cantProd = value;
        //        }
        //        OnPropertyChanged("CantProd");
        //    }
        //}
        //public IEnumerable<User_info> Users
        //{
        //    get { return users; }
        //}
       
        #endregion

        #region Constructors
        public RequestDataViewModel()
        {
           
            this.ShowRequestDatas();
           

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

        
        private async void ShowRequestDatas()
        {
            this.Clear();
            var url = "https://feriavirtual-endpoints.herokuapp.com/api/sol-prod/api/1";

            using (HttpClient client = new HttpClient())

            {
                var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    List<RequestData> requestsdata = new List<RequestData>();
                    var res = response.Content.ReadAsStringAsync().Result;
                    var requestdataList = JsonConvert.DeserializeObject<dynamic>(res);

                    foreach (var dato in requestdataList)
                    {
                        RequestData requestdata = new RequestData();


                        requestdata.IdSolProd = dato.idSolicitudProductos;  //idSolicitudProductos campo no aparece segun API
                        //requestdata.IdUsuario = dato.idUsuario;        //idUsuario campo segun API
                        //requestdata.IdTipoSol = dato.idTipoSolicitud; //idTipoSolicitud campo segun API
                        /*requestdata.IdEstadoSol = dato.idSolicitudProductos;*/ //idEstadoSolicitud campo segun API
                        //requestdata.ProductName = dato.descripcion;
                        //requestdata.CantProd = dato.cantidad;
                        requestdata.DisplayName = dato.nombre;
                       

                        this.Add(requestdata);
                    }
                }
                else
                {
                    //message.Content = $"Server error code {response.StatusCode}";
                }
            }
        }
        private async void upRequest()
        {

            //DateTime date = DateTime.ParseExact(this.FechaIni, "M/dd/yyyy hh:mm:ss tt", null);
            var id = this.IdUsuario;

            var userObject = new
            {
                id_usuario = this.IdUsuario,
                id_tipo_solicitud = this.IdTipoSol,
                id_estado_solicitud = this.IdEstadoSol,
                id_solicitud_productos = this.IdSolProd,
            };


            var json = JsonConvert.SerializeObject(userObject);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"https://feriavirtual-endpoints.herokuapp.com/api/sol-prod/usr/{id}"; /*https://feriavirtual-endpoints.herokuapp.com/api/contrato/{id}*/

            using (HttpClient client = new HttpClient())
            {
                var response = await client.PutAsync(url, data);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();
                var userList = JsonConvert.DeserializeObject<dynamic>(res);
                string message = userList.msg;
                MessageBox.Show(message);

            }

            this.ShowRequestDatas();
        }
        private async void delRequest()
        {
            var id = 57; /* this.IdSolProd;*/

            var url = $"https://feriavirtual-endpoints.herokuapp.com/api/sol-prod/usr/{id}";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)

                    MessageBox.Show("Solicitud Eliminada!");
                this.ShowRequestDatas();
            }
        }

        //private void getCreateContract() //ver si aplica modificacion para Solicitudes
        //{
        //    CreateContract win_menu = new CreateContract();
        //    win_menu.Show();
        //}
        //private void ValidateProperty<T>(T value, string name)
        //{
        //    Validator.ValidateProperty(value, new ValidationContext(this, null, null)
        //    {
        //        MemberName = name
        //    });
        //}
        #endregion
    }
}
