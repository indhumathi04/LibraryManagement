using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace LibraryManagementSystem.Controllers
{
    public class userController : Controller
    {
        public readonly LibraryContext db;
        public userController(LibraryContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            try
            {
                UserAndBooks ub = new UserAndBooks();

                int id = (int)HttpContext.Session.GetInt32("userId");

                ub.books = db.BooksTransactions.Include(x => x.Book).Where(x => x.UserId == id).ToList();

                ub.User = db.UserDetails.Where(x => x.UserId == id).SingleOrDefault();

                return View(ub);
            }
            catch(InvalidOperationException e)
            {
                TempData["BookUnavailable"] = "Login to continue";
                return RedirectToAction("userLogin", "Login");
            }
        }
        public IActionResult Renew(int id)
        {
            var book = db.BooksTransactions.Include(x => x.Book).Where(x => x.TransId == id).SingleOrDefault();
            return View(book);
        }
        [HttpPost]
        [ActionName("Renew")]
        public IActionResult RenewConfirm(int id)
        {
            var res = db.BooksTransactions.Where(x => x.TransId == id).SingleOrDefault();
            res.DueDate = DateTime.Now.AddDays(12);
            db.BooksTransactions.Update(res);
            db.SaveChanges(); 
            return RedirectToAction("Index");
        }

        public IActionResult Return(int id)
        {
            var res = db.BooksTransactions.Where(x => x.TransId == id).SingleOrDefault();
            db.BooksTransactions.Remove(res);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
} 

