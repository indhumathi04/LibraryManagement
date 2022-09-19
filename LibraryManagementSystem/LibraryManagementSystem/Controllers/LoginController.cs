using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        public readonly LibraryContext db;
        public LoginController(LibraryContext _db)
        {
            db = _db;
        }
        public IActionResult userLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult userLogin(UserDetail user)
        {
            if (ModelState.IsValid)
            {
                var result = (from i in db.UserDetails where i.Email == user.Email && i.Password == user.Password select i).FirstOrDefault();
                if (result != null)
                {
                    HttpContext.Session.SetString("uid", result.UserId.ToString());
                    System.Diagnostics.Debug.WriteLine(HttpContext.Session.GetString("uid"));
                    HttpContext.Session.SetInt32("userId", result.UserId);
                    System.Diagnostics.Debug.WriteLine(HttpContext.Session.GetInt32("userId"));
                    Console.WriteLine(HttpContext.Session.GetInt32("userId"));
                    return RedirectToActionPermanent("viewbooks", "Library");
                }
                else
                {
                    return RedirectToAction("userLogin");
                }
            }
            return RedirectToAction("userLogin");
        }

        public IActionResult adminLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult adminLogin(AdminDetail admin)
        {
            if (ModelState.IsValid)
            {
                var result = (from i in db.AdminDetails where i.AdminEmail == admin.AdminEmail && i.AdminPassword == admin.AdminPassword select i).FirstOrDefault();
                if (result != null)
                {
                    HttpContext.Session.SetInt32("adminId", admin.AdminId);
                    return RedirectToActionPermanent("Index", "Home");
                }
                else
                {
                    return RedirectToAction("adminLogin");
                }
            }
            return RedirectToAction("adminLogin");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
