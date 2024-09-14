using BookApi.Interface;
using BookApi.Repository;
using BookApi.Model;
using BookApi.Interfaces;

namespace inventoryApiDotnet.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(IMongoContext context) : base(context)
        {
        }
    }
}
