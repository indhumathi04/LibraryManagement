using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class LibraryController : Controller
    {
        public readonly LibraryContext db;
        public LibraryController(LibraryContext _db)
        {
            db = _db;
        }
        public IActionResult viewBooks()
        {
            return View(db.BooksAvailables);
        }
        public IActionResult Details(int id)
        {
            var book = db.BooksAvailables.Where(x => x.BookId == id).SingleOrDefault();
            return View(book);
        }
        [HttpPost]
        [ActionName("Details")]
        public IActionResult DetailsAdd(int id)
        {
            var taken = db.BooksTransactions.Where(x => x.BookId == id && x.Status == "issued").ToList();
            if (taken.Count == 0)
            {
                BooksTransaction b = new BooksTransaction();
                b.UserId = HttpContext.Session.GetInt32("userId");
                b.BookId = id;
                b.IssueDate = DateTime.Now;
                b.DueDate = DateTime.Now.AddDays(12);
                b.Status = "issued";
                db.BooksTransactions.Add(b);
                db.SaveChanges();
                return RedirectToAction("viewBooks");
            }
            return RedirectToAction("viewBooks");

        }

    }
}
