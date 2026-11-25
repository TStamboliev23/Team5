using SchoolLibrary.Data.Models;
namespace SchoolLibrary.Data.Repositories;

public class InMemoryBookRepository : IBookRepository
{
    private readonly List<Book> books = new List<Book>
    {
        new Book{Id=1, Title = "Под Игото", Author = "Иван Вазов"},
        new Book{Id=2, Title = "Малкият принц", Author = "Антоан дьо Сент Екзюпери"},
        new Book{Id=3, Title = "Пипи Дългото чорапче", Author = "Астрид Линдгрен"}
    };
 
    public IReadOnlyList<Book> GetAll()
    {
        return books.AsReadOnly();
    }
    public Book? GetById(int id)
    {
        foreach (Book book in books)
        {
            if (book.Id == id)
            {
                return book;
            }
        }

        return null;
    }
}