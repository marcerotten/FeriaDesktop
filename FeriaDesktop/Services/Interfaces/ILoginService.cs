using FeriaDesktop.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDesktop.Services.Interfaces
{
    public interface ILoginService
    {
        Task<User> GetLogin();
    }
}
