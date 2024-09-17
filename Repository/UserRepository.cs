using BookApi.Interface;
using BookApi.Repository;
using BookApi.Model;
using BookApi.Interfaces;

namespace BookApi.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoContext context) : base(context)
        {
        }
    }
}
