using BookApi.Model;

namespace BookApi.Interfaces
{
    public interface IAuthservice
    {
        Task<User> Authenticate(User user);
        string GenerateJWT(User user);   
    }
}