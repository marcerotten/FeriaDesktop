﻿using FeriaDesktop.Services;
using FeriaDesktop.Services.Interfaces;
using System.ComponentModel;
using System.Windows.Input;

namespace FeriaDesktop.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        #region Atributos
        private string user;
        private string password;
        private ICommand getInCommand;
        
        #endregion

        #region Propiedades
        public string User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public ICommand GetInCommand
        {
            get
            {
                if (getInCommand == null)
                {
                    getInCommand = new RelayCommand(param => this.GetInCommandExecute(), null);
                }
                return getInCommand;

            }
            set
            {
                getInCommand = value;
            }
        }

        private void GetInCommandExecute()
        {

            var loginService = new LoginService();
            var login = loginService.GetLogin(user,password);


        }
        #endregion

        #region Constructores       
        /*
        public LoginViewModel()
        {//ILoginService loginService
            this.loginService = loginService;
            GetInCommand = new CommandBase(param => this.GetInSesion());
        }*/
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

        #region Metodos/Funciones
        /*
        private async void GetInSesion()
        {
            //var result = loginService.GetLogin();

            User vlClient = new User();
            vlClient.usuario = user;
            vlClient.contrasena = password;

            var userObject = new
            {
                correo = user,
                contrasena = password
            };

            var json = JsonConvert.SerializeObject(userObject);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:8080/api/auth";

            using (HttpClient client = new HttpClient())

            {
                var response = await client.PostAsync(url, data);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();
                var userList = JsonConvert.DeserializeObject<dynamic>(res);

                //validacion mientras la api responde el cod correcto
                var usuario_info = userList.idUsuario.ToObject<int>();

                //if (response.IsSuccessStatusCode)
                if (usuario_info != 0)
                {
                    //message.Content = await response.Content.ReadAsStringAsync();
                    Menu win_menu = new Menu();
                    win_menu.Show();
                }
                else
                {
                    MessageBox.Show("Credenciales Inválidas!");
                    //message.Content = $"Server error code {response.StatusCode}";
                }
            }

            //this.Add(vlClient);
        }*/
        #endregion
    }
}
