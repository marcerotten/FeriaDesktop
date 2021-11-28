using FeriaDesktop.Model;
using System.Threading.Tasks;

namespace FeriaDesktop.Services.Interfaces
{
    public interface ILoginService
    {
        void GetLogin(string user, string password);
    }
}
