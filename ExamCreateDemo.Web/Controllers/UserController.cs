using ExamCreateDemo.Web.Data;
using ExamCreateDemo.Web.Entity;
using ExamCreateDemo.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCreateDemo.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ExamContext _context;

        public UserController(ExamContext context)
        {
            _context = context;
        }

        public object Session { get; private set; }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(UserCreateViewModel user)
        {

            if (ModelState.IsValid)
            {
                _context.Users.Add(new User
                {
                    UserName = user.UserName,
                    FullName=user.FullName,
                    Email=user.Email,
                    Password=user.Password,
                    RePassword=user.RePassword

                }); 
                _context.SaveChanges();
                return RedirectToAction("UserList", "User");
            }
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(UserLoginViewModel model)
        {
            var userInDb = _context.Users.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
            if (userInDb != null)
            {
                HttpContext.Session.SetString("sessionUsername", userInDb.UserName);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Wrong UserName or Password - Try Again Please";
                return View();
            }
        }

        
        public IActionResult UserDelete(int id)
        {

            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("UserList");
        }


        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("sessionUsername");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UserList()
        {
   
            return View(_context.Users.ToList());
        }
    }
}
