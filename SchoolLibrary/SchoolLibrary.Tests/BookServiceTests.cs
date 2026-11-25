using Xunit;
using SchoolLibrary.Data.Repositories; 
using SchoolLibrary.Services;          
namespace SchoolLibrary.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void BorrowBook_WhenBookIsAlreadyBorrowed_ReturnsMessage()
        {
            var repository = new InMemoryBookRepository();
            var service = new BookService(repository);
            service.BorrowBook(1); 

            string result = service.BorrowBook(1);

            Assert.Equal("Книгата вече е заета.", result);
        }

        [Fact]
        public void BorrowBook_WhenBookDoesNotExist_ReturnsNotFoundMessage()
        {
            var repository = new InMemoryBookRepository();
            var service = new BookService(repository);

            string result = service.BorrowBook(999);

            Assert.Equal("Книгата не е намерена.", result);
        }

        [Fact]
        public void ReturnBook_WhenBookIsReturned_MakesItAvailableAgain()
        {
            var repository = new InMemoryBookRepository();
            var service = new BookService(repository);
            service.BorrowBook(1); 

            service.ReturnBook(1);
            string result = service.BorrowBook(1);
            
            Assert.NotEqual("Книгата вече е заета.", result);
        }
    }
}