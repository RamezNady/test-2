using System.Threading.Tasks;
using ZwajApp.API.Mobels;

namespace ZwajApp.API.Data
{
    public interface IAuthRepoitory
    {
         Task<User> Register ( User user,string password);
         Task<User> Login ( string username,string password);
         Task<bool> UserExists ( string usernamed);
    }
}