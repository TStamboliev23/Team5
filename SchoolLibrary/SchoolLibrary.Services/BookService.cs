using SchoolLibrary.Data.Models;
using SchoolLibrary.Data.Repositories;
namespace SchoolLibrary.Services;

public class BookService
{
    private readonly IBookRepository repository;
 
    public BookService(IBookRepository repository)
    {
        this.repository = repository;
    }
 
    public IReadOnlyList<Book> GetAllBooks()
    {
        return repository.GetAll();
    }
    public string BorrowBook(int id)
    {
        Book? book = repository.GetById(id);

        if (book == null)
        {
            return "Книгата не е намерена.";
        }
        
        if (book.IsBorrowed)
        {
            return "Книгата вече е заета.";
        }
        
        book.IsBorrowed = true;

        return "Книгата е заета успешно.";
    }
    public string ReturnBook(int id)
    {
        Book? book = repository.GetById(id);

        if (book == null)
        {
            return "Книгата не е намерена.";
        }

        if (!book.IsBorrowed)
        {
            return "Книгата не е заета.";
        }

        book.IsBorrowed = false;
        
        return "Книгата е върната успешно.";
    }
}