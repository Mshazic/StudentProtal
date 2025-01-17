using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;
using StudentPortal.Models.StudentAccountEntity;
using StudentPortal.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentPortal.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<StudentUser> signInManager;
        private readonly UserManager<StudentUser> studentUserManager;
        private readonly AppDbcontext dbContext;
        public AccountController(AppDbcontext dbContext, SignInManager<StudentUser> signInManager, UserManager<StudentUser> studentUserManager)
        {
            this.dbContext = dbContext;
            this.signInManager = signInManager;
            this.studentUserManager = studentUserManager;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterStudentUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                StudentUser studentUser = new StudentUser
                {
                    FullName = model.Name,
                    Email = model.Email,
                    UserName = model.Email,

                };

                var result = await studentUserManager.CreateAsync(studentUser, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }

            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync()
        {
         
            return View();
        }


        public IActionResult VerifyEmail()
        {
            return View();
        }

        [HttpPost]
      //  public async Task<IActionResult> VerifyEmail()
       // {
          
        //    return View();
       // }

       

        [HttpPost]
        public async Task<IActionResult> ChangePassword()
        {

            return  View();
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

