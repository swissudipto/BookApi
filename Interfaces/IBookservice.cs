using BookApi.Model;

namespace BookApi.Interfaces
{
    public interface IBookservice
    {
        Task<Book> Create(Book book);
        Task<List<Book>> Get();
        Task<Book> GetById(string Id); 
        Task<Book?> Update(string Id, Book book);
        Task<bool> Delete(string Id);     
    }
}