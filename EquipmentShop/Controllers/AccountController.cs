using AutoMapper;
using EquipmentShop.Models;
using EquipmentShop.Services;
using EquipmentShop.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;

namespace EquipmentShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        private readonly ApplicationDbContext db;
        public readonly static string AdminVerificationCode = "1234";

        public AccountController(ApplicationDbContext context, ILogger<AccountController> logger)
        {
            _logger = logger;
            db = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                AdminUsers adminUsers = await db.AdminUsers.FirstOrDefaultAsync(u => u.Email == model.Login.Email);
                if (adminUsers != null)
                {
                    bool match = BCrypt.Net.BCrypt.Verify(model.Login.Password, adminUsers.Password);
                    if (match)
                    {
                        await Authenticate(model.Login.Email); // аутентификация
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Սխալ ծածկագիր կամ ել-հասցե");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                AdminUsers adminUsers = await db.AdminUsers.FirstOrDefaultAsync(u => u.Email == model.Register.Email);
                if (adminUsers == null && AdminVerificationCode == model.Register.AdminVerification)
                {
                    // avelacnum enq baza
                    db.AdminUsers.Add(new AdminUsers { Email = model.Register.Email, Password = BCrypt.Net.BCrypt.HashPassword(model.Register.Password) });
                    await db.SaveChangesAsync();

                    await Authenticate(model.Register.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    return View("ErrorExsistingUser");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult SignInUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignInUser(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Users users = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (users != null)
                {
                    bool match = BCrypt.Net.BCrypt.Verify(model.Password, users.PasswordHash);
                    if (match)
                    {
                        await Authenticate(model.Email);
                        return Redirect("/User/Index");
                    }
                }
                ModelState.AddModelError("", "Սխալ ծածկագիր կամ էլ-հասցե");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult SignUpUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUpUser(UserRegister model)
        {
            bool checkPhone = PhoneNumberChecker.CheckPhoneNumber(model.Phone);
            if (ModelState.IsValid)
            {
                if (model.ConfirmPassword != model.Password)
                {
                    ModelState.AddModelError("", "Ծածկագրերը չեն համընկնում!");
                }
                else
                {
                    Users users = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email || u.UserName == model.UserName);
                    if (users == null)
                    {
                        if (checkPhone == true)
                        {
                            // Ավելացնում ենք օգտատիրոջը տվյալների բազա
                            db.Users.Add(new Users
                            {
                                UserName = model.UserName,
                                Email = model.Email,
                                PhoneNumber = model.Phone,
                                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password)
                            });
                            await db.SaveChangesAsync();
                            await Authenticate(model.Email);

                            return Redirect("/User/Index");
                        }
                        else
                            ModelState.AddModelError("", "Մուտքագրեք ճիշտ հեռախոսահամար(09*****55)։");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Օգտատեր այս օգտանունով կամ էլ-հասցեով արդեն գոյություն ունի!");
                        _logger.LogInformation("user register exsisting attempt");
                    }
                }
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // ստեղծում ենք մեկ Claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // ստեղծում ենք ClaimsIdentity օբյեկտ
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // ներբեռնում ենք աուտենտիֆիկացիոն քուքիները
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/User/Index");
        }
    }
}

