using Core.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using ShopStore.Generic;
using ShopStore.Models.Context;
using ShopStore.Repositories;
using ShopStore.Service.Interface;
using ShopStore.ViewModels;

namespace ShopStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private IRegister _IRegister;
        private ILogin _ILogin;
        private IEmailSender _MessageSender;

        public AccountController(AppDbContext context, IRegister IRegister, 
            IEmailSender messageSender, ILogin login)
        {
            _context = context;
            _IRegister = IRegister;
            _MessageSender = messageSender;
            _ILogin = login;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }
            if (_IRegister.emailExist(FixedEmail.FixedText(registerModel.Email)))
                ModelState.AddModelError("Email", "ایمیل تکراری است.");

            if (_IRegister.userExist(registerModel.FirstName, registerModel.LasttName))
                ModelState.AddModelError("UserName", "کاربر با این نام وجود دارد.");

            User user = new User
            {
                FName = registerModel.FirstName,
                LName = registerModel.LasttName,
                UserEmail = registerModel.Email,
                Password = PasswordEncript.EncriptPassword(registerModel.Password),
            };
            _context.Users.Add(user);
            try
            {
                _context.SaveChanges();
                var emailMessage = "Your registration is complete now. Welcome to our site" +
                    "thank you for choosing us, hope you enjoy shopping.";
                await _MessageSender.SendEmailAsync(user.UserEmail, "Welcome", emailMessage);
                return RedirectToAction("Home");
            }
            catch
            {
                return View(registerModel);
            }
        }
        public IActionResult Login()
        {
            return View();                  
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }
            var user = _ILogin.userIsRegistered(loginModel);
            if (user != null)
            {
                ViewBag.LoggedIn = true;
                return View(user);
            }
            else
            {
                var name = loginModel.FName + " " + loginModel.LName;
                ModelState.AddModelError(name, "ابتدا در سایت ثبت‌ نام کنید.");
            }
            return View();
        }
    }
}
