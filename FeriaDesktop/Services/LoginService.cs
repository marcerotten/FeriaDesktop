using FeriaDesktop.Model;
using FeriaDesktop.Services.Interfaces;
using FeriaDesktop.View;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;



namespace FeriaDesktop.Services
{
    public class LoginService
    {
        public async Task<User> GetLogin(string user, string password)
        {
            var userObject = new
            {
                correo = user,
                contrasena = password
            };
            var json = JsonConvert.SerializeObject(userObject);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://feriavirtual-endpoints.herokuapp.com/api/auth";

            using (HttpClient client = new HttpClient())

            {
                var response = await client.PostAsync(url, data);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();
                var userList = JsonConvert.DeserializeObject<dynamic>(res);

                //validacion mientras la api responde el cod correcto
                var usuario_info = userList.idUsuario.ToObject<int>();
                var usuario_rol = userList.idRol.ToObject<int>();

                //if (response.IsSuccessStatusCode)
                if (usuario_info != 0)
                {
                    if(usuario_rol == 1)
                    {
                        Menu win_menu = new Menu();
                        win_menu.Show();
                    }
                    else
                    {
                        MessageBox.Show("No es usuario administrador!");
                    }
                    //message.Content = await response.Content.ReadAsStringAsync();
                    
                }
                else
                {
                    MessageBox.Show("Credenciales Inválidas!");
                    //message.Content = $"Server error code {response.StatusCode}";
                }
                return null;
            }
        }
    }
}
