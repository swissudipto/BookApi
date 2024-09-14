
using BookApi.Interfaces;
using BookApi.Model;

namespace BookApi.Services
{
    public class Bookservice : IBookservice
    {
        private readonly IBookRepository _bookRepository;
        public Bookservice(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Book> Create(Book book)
        {
            await _bookRepository.Add(book);
            return book;
        }

        public async Task<List<Book>> Get()
        {
           var result =  await _bookRepository.GetAll();
           return result.ToList();
        }

        public async Task<Book> GetById(string Id)
        {
            var result = await _bookRepository.GetById(Id);
            return result;
        }

        public async Task<Book?> Update(string Id, Book book)
        {
            var result = await _bookRepository.Update(book);
            if(result)
            {
                return await _bookRepository.GetById(Id);
            }
            return null;
        }

        public async Task<bool> Delete(string Id)
        {
            return await _bookRepository.Remove(Id);
        }

    }
}