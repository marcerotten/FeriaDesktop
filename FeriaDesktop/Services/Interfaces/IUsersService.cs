using System.Threading.Tasks;

namespace FeriaDesktop.Services.Interfaces
{
    public interface IUsersService
    {
        Task<string> GetUsers();
    }
}
