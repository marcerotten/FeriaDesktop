using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using FeriaDesktop.View;
using FeriaDesktop.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;

namespace FeriaDesktop.ViewModel
{
    public class ClientsViewModel : ViewModelBase
    {
        private string gridclients;

        public string dgClients
        {
            get
            {
                return gridclients;
            }
            set
            {
                gridclients = value;
                
                //OnPropertyChanged("dgClients");
            }
        }
        private async void mostrarClientes(List<Clients> listaClientes)
        {
            

            DataTable dt = new DataTable();

            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellido Paterno");
            dt.Columns.Add("Apellido Materno");
            dt.Columns.Add("DNI");
            dt.Columns.Add("Dirección");
            dt.Columns.Add("Código Postal");
            dt.Columns.Add("Correo");
            dt.Columns.Add("Pais");
            dt.Columns.Add("Rol");
            dt.Columns.Add("Estado");
            dt.Columns.Add("Términos y Condiciones");

            //var json = JsonConvert.SerializeObject(userObject);
            //var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://localhost:8080/api/usuario/1";

            using (HttpClient client = new HttpClient())

            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    //List<Usuario_info> usuarios = new List<Usuario_info>();
                    var res = await response.Content.ReadAsStringAsync();
                    //var userList = JsonConvert.DeserializeObject<List<Usuario_info>>(res);
                    var userList = JsonConvert.DeserializeObject<dynamic>(res);

                    //message.Content = historyname;

                    foreach (var dato in userList)
                    {
                        DataRow row = dt.NewRow();

                        //actividadEmpresa.Read(dato.IdActividadEmpresa);
                        //tipoEmpresa.Read(dato.IdTipoEmpresa);

                        row["Nombre"] = dato.nombre;
                        row["Apellido Paterno"] = dato.apPaterno;
                        row["Apellido Materno"] = dato.apMaterno;
                        row["DNI"] = dato.dni;
                        row["Dirección"] = dato.direccion;
                        row["Código Postal"] = dato.codPostal;
                        row["Correo"] = dato.correo;
                        row["Pais"] = dato.pais;
                        row["Rol"] = dato.rol;
                        row["Estado"] = dato.estado;
                        var terminos = dato.terminosCondiciones.ToObject<int>();
                        if (terminos != 0)
                        {
                            row["Términos y Condiciones"] = "Rechazado";
                        }
                        else
                        {
                            row["Términos y Condiciones"] = "Aceptado";
                        }


                        dt.Rows.Add(row);
                    }

                    //dgClients.ClearValue(ItemsControl.ItemsSourceProperty);
                    /*
                     * Para traerlo desde la clase
                    dgClientes.ItemsSource = userList; //dt.DefaultView;
                    */
                    //dgClients.ItemsSource = dt.DefaultView;
                    //dgClients.UpdateLayout();

                }
                else
                {
                    //message.Content = $"Server error code {response.StatusCode}";
                }
            }

        }
    }
}
