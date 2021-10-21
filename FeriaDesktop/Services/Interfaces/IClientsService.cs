using FeriaDesktop.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDesktop.Services.Interfaces
{
    public interface IClientsService
    {
        Task<string> GetClients();
    }
}
