using FeriaDesktop.Model;
using FeriaDesktop.Services.Interfaces;
using FeriaDesktop.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDesktop.Services
{
    public class UsersService : IUsersService
    {
        public async Task<string> GetUsers()
        {

            Users win_menu = new Users();
            win_menu.Show();

            //var response = string.Empty;
            //using (var client = new HttpClient())
            //{
            //    HttpResponseMessage result = await client.GetAsync("http://localhost:8080/api/pais");
            //    if (result.IsSuccessStatusCode)
            //    {
            //        response = await result.Content.ReadAsStringAsync();
            //    }
            //}
            //return response;
            //    var url = "http://localhost:8080/api/usuario/3";

            //    using (HttpClient client = new HttpClient())

            //    {
            //        var response = await client.GetAsync(url);
            //        response.EnsureSuccessStatusCode();
            //        if (response.IsSuccessStatusCode)
            //        {
            //            var res = await response.Content.ReadAsStringAsync();
            //            var userList = JsonConvert.DeserializeObject<dynamic>(res);

            //            //message.Content = historyname;

            //            foreach (var dato in userList)
            //            {
            //                Console.WriteLine("INFOOOOOOO", dato);

            //            }
            //            Clients win_menu = new Clients();
            //            win_menu.Show();
            //        }
            //    }
                return null;

        }
    }
}
