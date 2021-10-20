using FeriaDesktop.Model;
using System.Threading.Tasks;

namespace FeriaDesktop.Services.Interfaces
{
    public interface ILoginService
    {
        Task<User> GetLogin(string user, string password);
    }
}
