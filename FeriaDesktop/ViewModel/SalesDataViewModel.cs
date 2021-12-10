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
using SalesData = FeriaDesktop.Model.SalesData;

namespace FeriaDesktop.ViewModel
{

    public class SalesDataViewModel : ObservableCollection<SalesData>, INotifyPropertyChanged
    {
        #region Atribute

        private int selectedIndex;
        private int cantProd;
        private int precProd;
        private string descProd;
        private ObservableCollection<SalesData> Sales = new ObservableCollection<SalesData>();

        #endregion

        #region Properties
        public ILog Logger { get; set; }
        public int SelectedIndexOfCollection
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndexOfCollection");
                OnPropertyChanged("CantProd");
                OnPropertyChanged("PrecProd");
                OnPropertyChanged("DescProd");
            }
        }

        public string urlBase = ConfigurationManager.AppSettings[("urlBase")];
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

        public string DescProd
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].DescProd;
                }
                else
                {
                    return descProd;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].DescProd = value;
                }
                else
                {
                    descProd = value;
                }
                OnPropertyChanged("DescProd");
            }
        }

     
        #endregion

        #region Constructors
        public SalesDataViewModel()
        {
            this.Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log4net.Config.XmlConfigurator.Configure();

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
            try
            {
                this.Logger.Info("ShowSalesDatas In");
                this.Clear();
                var dataGet = ConfigurationManager.AppSettings[("showSales")];
                var url = $"{urlBase}{dataGet}";

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

                            saledata.DescProd = dato.descripcion;
                            saledata.CantProd = dato.cantidad;
                            saledata.PrecProd = dato.precio;

                            this.Add(saledata);
                        }
                    }
                    else
                    {
                        this.Logger.Warn(url + "/Server error code: " + response.StatusCode);
                    }
                    this.Logger.Info(url + "/" + response.StatusCode);
                }
                this.Logger.Info("ShowSalesDatas Out");
            }
            catch (Exception e)
            {
                this.Logger.Error(e);
            }
        }
    }
        
        #endregion

}