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
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace FeriaDesktop.ViewModel
{
    public class ContractsViewModel : ObservableCollection<Contract>, INotifyPropertyChanged
    {
        #region Atribute
        private ICommand upContractCommand;
        private ICommand delContractCommand;
        private ICommand getCreateContractCommand;
        private int selectedIndex;
        private string dni;
        private string displayName;
        private string codigo;
        private string fechaIni;
        private string fechaFin;
        private int idContrato;
        private int firmado;
        private int idUsuario;
        private ObservableCollection<User_info> users = new ObservableCollection<User_info>();
        #endregion

        #region Properties
        public ILog Logger { get; set; }

        public string urlBase = ConfigurationManager.AppSettings[("urlBase")];

        public ICommand GetCreateContractCommand
        {
            get { return getCreateContractCommand; }
            set
            {
                getCreateContractCommand = value;
            }
        }
        public ICommand UpContractCommand
        {
            get { return upContractCommand; }
            set
            {
                upContractCommand = value;
            }
        }
        public ICommand DelContractCommand
        {
            get { return delContractCommand; }
            set
            {
                delContractCommand = value;
            }
        }
        public int SelectedIndexOfCollection
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndexOfCollection");

                OnPropertyChanged("Dni");
                OnPropertyChanged("Codigo");
                OnPropertyChanged("DisplayName");
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
                    ValidateProperty(value, "Codigo");
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
                    ValidateProperty(value, "FechaIni");
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
                    ValidateProperty(value, "FechaFin");
                    this.Items[this.SelectedIndexOfCollection].FechaFin = value;
                }
                else
                {
                    fechaFin = value;
                }
                OnPropertyChanged("FechaFin");
            }
        }
        public int IdContrato
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].IdContrato;
                }
                else
                {
                    return idContrato;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].IdContrato = value;
                }
                else
                {
                    idContrato = value;
                }
                OnPropertyChanged("IdContrato");
            }
        }
        public int Firmado
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].Firmado;
                }
                else
                {
                    return firmado;
                }
            }
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].Firmado = value;
                }
                else
                {
                    firmado = value;
                }
                OnPropertyChanged("Firmado");
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
        public IEnumerable<User_info> Users
        {
            get { return users; }
        }

        #endregion

        #region Constructors
        public ContractsViewModel()
        {
            this.Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log4net.Config.XmlConfigurator.Configure();

            this.showContracts();
            UpContractCommand = new RelayCommand(param => this.upContract());
            GetCreateContractCommand = new RelayCommand(param => this.getCreateContract());
            DelContractCommand = new RelayCommand(param => this.delContract());
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
        private async void showContracts()
        {
            this.Clear();
            try
            {
                this.Logger.Info("showContracts In");
                var dataGet = ConfigurationManager.AppSettings[("showContracts")];
                var url = $"{urlBase}{dataGet}";

                using (HttpClient client = new HttpClient())

                {
                    var response = client.GetAsync(url).Result;
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        List<Contract> contracts = new List<Contract>();
                        var res = response.Content.ReadAsStringAsync().Result;
                        var contractList = JsonConvert.DeserializeObject<dynamic>(res);

                        foreach (var dato in contractList)
                        {
                            Contract contract = new Contract();

                            contract.IdContrato = dato.idContrato;
                            contract.IdUsuario = dato.idUsuario;
                            contract.Dni = dato.dni;
                            string nom = Convert.ToString(dato.nombre);
                            string app1 = dato.apPaterno;
                            string app2 = dato.apMaterno;
                            string disp = nom + " " + app1 + " " + app2;
                            contract.DisplayName = disp;
                            contract.Firmado = dato.firmado;
                            contract.Codigo = dato.codigo;
                            contract.FechaIni = dato.fechaIni;
                            contract.FechaFin = dato.fechaFin;

                            this.Add(contract);
                        }
                    }
                    else
                    {
                        this.Logger.Warn(url + "/Server error code: " + response.StatusCode);
                    }
                    this.Logger.Info(url + "/" + response.StatusCode);
                }
                this.Logger.Info("showContracts Out");
            }
            catch (Exception e)
            {
                this.Logger.Error(e);
            }
        }
        private async void upContract()
        {
            try
            {
                var id = this.IdContrato;

                var userObject = new
                {
                    idUsuario = this.IdUsuario,
                    codigo = this.Codigo,
                    fechaIni = this.FechaIni,
                    fechaFin = this.FechaFin,
                    firmado = this.Firmado
                };

                this.Logger.Info("upContract In");
                var dataUp = ConfigurationManager.AppSettings[("upContract")];
                var json = JsonConvert.SerializeObject(userObject);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
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
                this.Logger.Info("upContract Out");

                this.showContracts();
            }
            catch (Exception e)
            {
                this.Logger.Error(e);
            }
        }

        private async void delContract()
        {
            try
            {
                this.Logger.Info("delContract In");
                var dataDel = ConfigurationManager.AppSettings[("delContract")];
                var id = this.IdContrato;
                var url = $"{urlBase}{dataDel}{id}";

                using (HttpClient client = new HttpClient())
                {
                    var response = await client.DeleteAsync(url);
                    response.EnsureSuccessStatusCode();
                    var res = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Contrato Eliminado!");
                    }
                    else
                    {
                        this.Logger.Warn(url + "/Server error code: " + response.StatusCode);
                    }
                    this.Logger.Info(url + "/" + response.StatusCode);

                    this.showContracts();
                }
                this.Logger.Info("delContract Out");
            }
            catch (Exception e)
            {
                this.Logger.Error(e);
            }
        }

        private void getCreateContract()
        {
            CreateContract win_menu = new CreateContract();
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
