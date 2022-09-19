using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
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
            List<object> userRec = new List<object>();
            int id = (int)HttpContext.Session.GetInt32("userId");
            var res = db.UserDetails.Where(x => x.UserId == id).SingleOrDefault();
            var books = db.BooksTransactions.Where(x => x.UserId == id).ToList();
            var bookIdList = (from b in books select b.BookId).ToList();
            var userBooks = db.BooksAvailables.Where(x => bookIdList.Contains(x.BookId)).ToList();
            userRec.Add(res);
            userRec.Add(userBooks);
            userRec.Add(books);
            return View(userRec);
        }
        public IActionResult Renew(int id)
        {
            return View();
        }

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

