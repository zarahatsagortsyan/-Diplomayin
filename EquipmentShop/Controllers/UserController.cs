using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using EquipmentShop.Models;
using Microsoft.Extensions.Logging;
using System.Net.Mail;
using System.Net;
using X.PagedList;
using EquipmentShop.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using EquipmentShop.Services;
using System.Web;

namespace EquipmentShop.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        readonly ApplicationDbContext db;
        public UserController(ApplicationDbContext context, ILogger<UserController> logger)
        {
            db = context;
            _logger = logger;
        }

        public IActionResult AuthorPage() 
        {
            ViewData["au"] = db.AdminUsers.ToList();
            ViewData["Users"] = db.Users.ToList();
            return View();
        }
        public IActionResult Index()
        {
            _logger.LogInformation("(User)User/Index has been called");
            ViewData["Products"] = db.Products.ToList();
            ViewData["HeadSection"] = db.HeadSections.ToList();
            ViewData["AboutSection"] = db.AboutSections.ToList();
            ViewData["StaffSection"] = db.StaffSections.ToList();
            ViewData["au"] = db.AdminUsers.ToList();
            ViewData["Users"] = db.Users.ToList();

            return View();
        }
  
        public IActionResult ProductList(string KeyWord, decimal? maxPrice,
            List<string> categories, string GoldKarat, string sortOrder, int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 12;
            ViewBag.sortOrder = sortOrder;
            ViewBag.KeyWord = KeyWord;
            ViewBag.maxPrice = maxPrice;
            ViewBag.GoldKarat = GoldKarat;
            ViewData["Check"] = categories.ToList();
            if (sortOrder != null)
                page = 1;
            if (maxPrice != null)
                page = 1;
            if (KeyWord != null)
                page = 1;
            if (GoldKarat != null)
                page = 1;

            ViewData["Basket"] = db.BasketProducts.ToList();
            ViewData["ForWhoms"] = db.ForWhoms.ToList();
            ViewData["Categories"] = db.Categories.ToList();
            ViewData["au"] = db.AdminUsers.ToList();
            ViewData["Users"] = db.Users.ToList();
            List<Category> categ = db.Categories.ToList();
            var dataToReturn = db.Products.ToList();
            if (KeyWord != null)
                dataToReturn = dataToReturn.Where(c => c.ForWhom == KeyWord).ToList();
            if (maxPrice != null)
                dataToReturn = dataToReturn.Where(c => c.Price <= maxPrice).ToList();
            if (GoldKarat != null)
                dataToReturn = dataToReturn.Where(c => c.Description.ToLower().Contains(GoldKarat)).ToList();
         
            List<Product> product = new List<Product>();
            if (categories.Contains("true"))
            {
                for (int i = 0; i < categories.Count; i++)
                {
                    if (categories[i] == "true")
                    {
                        dataToReturn = db.Products.Where(
                                            c => c.Category.ToLower().Contains(categ[i].CategoryName.ToLower())).ToList();
                        product.AddRange(dataToReturn);
                    }
                }
                dataToReturn = product.ToList();
                if (KeyWord != null)
                    dataToReturn = dataToReturn.Where(c => c.ForWhom == KeyWord).ToList();
                if (maxPrice != null)
                    dataToReturn = dataToReturn.Where(c => c.Price <= maxPrice).ToList();
                if (GoldKarat != null)
                    dataToReturn = dataToReturn.Where(c => c.Description.ToLower().Contains(GoldKarat)).ToList();
            }
            if (sortOrder != null)
            {
                switch (sortOrder)
                {
                    case "price_desc":
                        dataToReturn = dataToReturn.OrderByDescending(a => a.Price).ToList();
                        break;
                    case "price_grow":
                        dataToReturn = dataToReturn.OrderBy(a => a.Price).ToList();
                        break;
                    case "by_popular":
                        dataToReturn = dataToReturn.OrderByDescending(a => a.Views).ToList();
                        break;
                    case "by_date":
                        dataToReturn = dataToReturn.OrderBy(a => a.DateCreated).ToList();
                        break;
                }
            }
            ViewData["Products"] = dataToReturn.ToPagedList(pageNumber, pageSize);
            return View();
        }
        #region Message
        [HttpPost]
        public ActionResult SendMessage(ContactSection contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ContactSections.Add(contact);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region MoreInfo
        [HttpGet]
        public IActionResult LearnMore(int? id)
        {
            ViewData["au"] = db.AdminUsers.ToList();
            ViewData["Basket"] = db.BasketProducts.ToList();
            ViewData["Materials"] = db.Materials.ToList();
            if (id == null)
                return BadRequest("Wrong input data!");

            Product product = db.Products.Find(id);
            product.Views+= 1;
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();

            if (product == null)
                return NotFound();

            return View(product);
        }
        #endregion

        #region OrderNow
        [HttpGet]
        public IActionResult OrderNow(int? id)
        {
            ViewData["au"] = db.AdminUsers.ToList();
            ViewData["Basket"] = db.BasketProducts.ToList();
            if (id == null)
                return BadRequest("Wrong input data!");
            OrderViewModel viewModel = new OrderViewModel();
            viewModel.Product = db.Products.Find(id);
            if (viewModel.Product == null)
                return NotFound();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult OrderNow(OrderViewModel viewModel)
        {
            ViewData["au"] = db.AdminUsers.ToList();
            ViewData["Basket"] = db.BasketProducts.ToList();
            bool ch = PhoneNumberChecker.CheckPhoneNumber(viewModel.Order.Phone);
            try
            {
                if (viewModel.Order.Name != null && viewModel.Order.Address != null)
                {
                    if (ch == true)
                    {
                        db.Orders.Add(new Order
                        {
                            Email = viewModel.Order.Email,
                            Name = viewModel.Order.Name,
                            LastName = viewModel.Order.LastName,
                            Address = viewModel.Order.Address,
                            Phone = viewModel.Order.Phone,
                            ProductId = viewModel.Product.ProductID,
                            ProductName = viewModel.Product.Name,
                            DateCreated = viewModel.Order.DateCreated,
                            Price = viewModel.Product.Price * viewModel.Order.PCount,
                            PCount = viewModel.Order.PCount,
                            ProductImage = viewModel.Product.Image,
                            Condition = "Նոր",
                        });
                        db.SaveChanges();
                        return RedirectToAction("OrderSucceed");
                    }
                    else
                        ModelState.AddModelError("", "Մուտքագրեք ճիշտ հեռախոսահամար։");
                }
                else
                    ModelState.AddModelError("", "Լրացրեք բոլոր դաշտերը։");
                return View(viewModel);
            }
            catch (Exception)
            {
                return View();
            }
        }
        public IActionResult OrderSucceed()
        {
            ViewData["Basket"] = db.BasketProducts.ToList();
            ViewData["au"] = db.AdminUsers.ToList();
            return View();
        }
        #endregion

        #region Profile
        [Authorize]
        [HttpGet]
        public IActionResult Profile()
        {
            ViewData["au"] = db.AdminUsers.ToList();
            ViewData["Basket"] = db.BasketProducts.ToList();
            ViewData["Users"] = db.Users.ToList();
            ViewData["Orders"] = db.Orders.ToList();
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult ChangeUserInfo(string id)
        {
            ViewData["au"] = db.AdminUsers.ToList();
            ViewData["Users"] = db.Users.ToList();
            ViewData["Basket"] = db.BasketProducts.ToList();

            if (id == null)
                return BadRequest("Wrong input data!");
            Users users = db.Users.Find(id);
            if (users == null)
                return NotFound();
            return View(users);
        }
        [Authorize]

        [HttpPost]
        public IActionResult ChangeUserInfo(Users users)
        {
            ViewData["au"] = db.AdminUsers.ToList();
            ViewData["Users"] = db.Users.ToList();
            ViewData["Basket"] = db.BasketProducts.ToList();

            Users user1 = db.Users.FirstOrDefault(e => e.Id == users.Id);
            if (ModelState.IsValid)
            {
                bool match = BCrypt.Net.BCrypt.Verify(users.PasswordHash, user1.PasswordHash);
                if (match)
                {
                    user1.UserName = users.UserName;
                    user1.PhoneNumber = users.PhoneNumber;
                    user1.Email = user1.Email;
                    user1.PasswordHash = BCrypt.Net.BCrypt.HashPassword(users.PasswordHash);
                    db.Entry(user1).State = EntityState.Modified;
                    db.SaveChanges();
                    return Redirect("/User/DataChangedLetter");
                }
                else
                    ModelState.AddModelError("", "Սխալ ծածկագիր");
            }
            return View(users);
        }
        public IActionResult DataChangedLetter()
        {
            ViewData["au"] = db.AdminUsers.ToList();
            ViewData["Users"] = db.Users.ToList();
            ViewData["Basket"] = db.BasketProducts.ToList();
            return View();
        }
        #endregion

        #region ShoppingCard
        [Authorize]
        [HttpGet]
        public IActionResult ProductsBasket()
        {
            ViewData["au"] = db.AdminUsers.ToList();
            ViewData["Basket"] = db.BasketProducts.ToList();
            return View(db.BasketProducts.ToList());
        }

        [Authorize]
        [HttpGet]
        public IActionResult ProductsBasketAdd(int? id)
        {
            ViewData["Basket"] = db.BasketProducts.ToList();
            ViewData["au"] = db.AdminUsers.ToList();
            if (id == null)
                return BadRequest("Wrong input data!");
            BasketProductsViewModel viewModel = new BasketProductsViewModel();
            viewModel.Product = db.Products.Find(id);
            if (viewModel.Product == null)
                return NotFound();

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult ProductsBasketAdd(BasketProductsViewModel viewModel)
        {
            ViewData["Basket"] = db.BasketProducts.ToList();
            ViewData["au"] = db.AdminUsers.ToList();
            try
            {
                var product = db.BasketProducts.Where(v => v.ProductId == viewModel.Product.ProductID && v.Email == viewModel.Basket.Email);
                var pCount = product.Count();
                if (pCount == 0)
                {
                    db.BasketProducts.Add(new BasketProducts
                    {
                        Email = viewModel.Basket.Email,
                        ProductId = viewModel.Product.ProductID,
                        ProductName = viewModel.Product.Name,
                        Price = viewModel.Product.Price,
                        ProductImage = viewModel.Product.Image,
                        Category = viewModel.Product.Category,
                        ForWhom = viewModel.Product.ForWhom,
                    });
                    db.SaveChanges();
                    return RedirectToAction("ProductList");
                }
                else
                    ModelState.AddModelError("", "Ձեր զամբյուղում կա այս ապրանքից!!");
                return View(viewModel);
            }
            catch (Exception e)
            {
                _logger.LogInformation("user added product to the basket");
                _logger.LogError(e.Message);
                return View();
            }
        }
        [Authorize]
        [HttpPost]
        public IActionResult ProductsBasketDelete(BasketProducts basket)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.BasketProducts.Remove(basket);
                    db.SaveChanges();
                    return RedirectToAction("ProductsBasket");
                }
                return View(basket);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return View();
            }
        }
        #endregion
    }
}
