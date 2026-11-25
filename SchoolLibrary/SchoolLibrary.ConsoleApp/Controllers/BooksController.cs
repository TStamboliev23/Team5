using SchoolLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace SchoolLibrary.UI.Controllers;

public class BooksController : Controller
{
    private readonly BookService _service;

    // Системата ни подава BookService сама (виж Стъпка 2)
    public BooksController(BookService service)
    {
        _service = service;
    }

    // GET /Books → списък на книгите (бивша опция 1)
    public IActionResult Index()
    {
        var books = _service.GetAllBooks();
        return View(books);
    }

    // POST /Books/Borrow/2 → заемане (бивша опция 2)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Borrow(int id)
    {
        TempData["Message"] = _service.BorrowBook(id);
        return RedirectToAction(nameof(Index));
    }

    // POST /Books/Return/2 → връщане (бивша опция 3)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Return(int id)
    {
        TempData["Message"] = _service.ReturnBook(id);
        return RedirectToAction(nameof(Index));
    }
}