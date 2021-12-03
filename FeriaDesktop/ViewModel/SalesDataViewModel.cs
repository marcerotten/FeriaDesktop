using FeriaDesktop.Model;
using FeriaDesktop.View;
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
using SalesData = FeriaDesktop.Model.SalesData;

namespace FeriaDesktop.ViewModel
{
   
        public class SalesDataViewModel : ObservableCollection<SalesData>, INotifyPropertyChanged
        {
        #region Atribute
      
            private ICommand upSalesDataCommand;
            private ICommand delSalesDataCommand;
            private ICommand getSalesDataCommand;
            private int selectedIndex;
            private string displayName;
            private int cantProd;
            private int precProd;
            private int idSolProd;
            private int idUsuario;
            private ObservableCollection<SalesData> Sales = new ObservableCollection<SalesData>();

            #endregion

            #region Properties
            public ICommand GetSalesDataCommand
            {
                get { return getSalesDataCommand; }
                set
                {
                    getSalesDataCommand = value;
                }
            }
            public ICommand UpSalesDataCommand
            {
                get { return upSalesDataCommand; }
                set
                {
                    upSalesDataCommand = value;
                }
            }
            public ICommand DelSalesDataCommand
            {
                get { return delSalesDataCommand; }
                set
                {
                    delSalesDataCommand = value;
                }
            }
            public int SelectedIndexOfCollection
            {
                get { return selectedIndex; }
                set
                {
                    selectedIndex = value;
                    OnPropertyChanged("SelectedIndexOfCollection");

                    OnPropertyChanged("DisplayName");
                    OnPropertyChanged("IdProd");
                    OnPropertyChanged("CantProd");
                    OnPropertyChanged("PrecProd");
                    OnPropertyChanged("IdSolProd");
                    OnPropertyChanged("IdUsuario");



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

            public int PrecProd
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].PrecProd;
                }
                else
                {
                    return precProd;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].PrecProd = value;
                }
                else
                {
                    precProd = value;
                }
                OnPropertyChanged("PrecProd");
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
        #endregion

        #region Constructors
            public SalesDataViewModel()
            {
             
                this.ShowSalesDatas();


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


            private async void ShowSalesDatas()
            {
                this.Clear();
                var url = "https://feriavirtual-endpoints.herokuapp.com/api/det-venta";

                using (HttpClient client = new HttpClient())

                {
                    var response = client.GetAsync(url).Result;
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        List<SalesData> salesdata = new List<SalesData>();
                        var res = response.Content.ReadAsStringAsync().Result;
                        var salesdataList = JsonConvert.DeserializeObject<dynamic>(res);

                    foreach (var dato in salesdataList)
                    {
                        SalesData saledata = new SalesData();


                        saledata.CantProd = dato.idSolicitudProductos;
                        saledata.PrecProd = dato.idSolicitudProductos;
                        //saledata.IdSolProd = dato.idSolicitudProductos;
                        //saledata.IdUsuario = dato.idSolicitudProductos;



                        //salesdata.idProd = dato.idProductos
                        //salesdata.DisplayName = dato.nombre;
                         

                            this.Add(saledata);
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
                    //id_tipo_solicitud = this.IdTipoSol,
                   // id_estado_solicitud = this.IdEstadoSol,
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

                this.ShowSalesDatas();
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
                    this.ShowSalesDatas();
                }
            }

           
            #endregion

        }
    }
