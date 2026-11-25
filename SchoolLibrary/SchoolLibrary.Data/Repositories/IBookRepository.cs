using SchoolLibrary.Data.Models;
namespace SchoolLibrary.Data.Repositories;

public interface IBookRepository
{
    IReadOnlyList<Book> GetAll();
    Book? GetById(int id);
}