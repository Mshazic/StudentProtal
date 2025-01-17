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
        public async Task<IActionResult> LoginAsync(LoginStudentUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password is incorrect.");
                    return View(model);
                }
            }
            return View();
        }


        public IActionResult VerifyEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyStudentUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await studentUserManager.FindByNameAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(model);

                }
                else
                {
                    return RedirectToAction("ChangePassword", "Account", new { Username = user.UserName });
                }

            }
            return View(model);
        }

       

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

