     using System.Threading.Tasks;
using CustomServer.Models;

namespace CustomServer.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string email, string password);
         Task<bool> UserExists(string email);
    }
}