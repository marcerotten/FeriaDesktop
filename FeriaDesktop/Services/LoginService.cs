using FeriaDesktop.Model;
using FeriaDesktop.Services.Interfaces;
using FeriaDesktop.View;
using log4net;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;



namespace FeriaDesktop.Services
{
    public class LoginService
    {
        public ILog Logger { get; set; }
        public string urlBase = ConfigurationManager.AppSettings[("urlBase")];

        public LoginService()
        {
            this.Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log4net.Config.XmlConfigurator.Configure();
        }

        public async void GetLogin(string user, string password)
        {
            try
            {
                this.Logger.Info("GetLogin In");
                var dataLogin = ConfigurationManager.AppSettings[("GetLogin")];
                
                var userObject = new
                {
                    correo = user,
                    contrasena = password
                };
                var json = JsonConvert.SerializeObject(userObject);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = $"{urlBase}{dataLogin}";

                using (HttpClient client = new HttpClient())

                {
                    var response = await client.PostAsync(url, data);
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        var res = await response.Content.ReadAsStringAsync();
                        var userList = JsonConvert.DeserializeObject<dynamic>(res);

                        //validacion mientras la api responde el cod correcto
                        var usuario_info = userList.idUsuario.ToObject<int>();
                        var usuario_rol = userList.idRol.ToObject<int>();

                        //if (response.IsSuccessStatusCode)
                        if (usuario_info != 0)
                        {
                            if (usuario_rol == 1)
                            {
                                Menu win_menu = new Menu();
                                win_menu.Show();
                            }
                            else
                            {
                                MessageBox.Show("No es usuario administrador!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Credenciales Inválidas!");
                        }
                    }
                    else
                    {
                        this.Logger.Warn(url + "/Server error code: " + response.StatusCode);
                    }
                    this.Logger.Info(url + "/" + response.StatusCode);
                    //return null;
                }
                this.Logger.Info("GetLogin Out");
            }
            catch (Exception e)
            {
                this.Logger.Error(e);
            }
        }
    }
}
