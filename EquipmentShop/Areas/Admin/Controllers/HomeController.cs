using EquipmentShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentShop.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            db = context;
            _logger = logger;
        }

        #region Users
        public IActionResult Users()
        {
            return View(db.Users.ToList());
        }
        [HttpPost]
        public IActionResult UserDelete(Users users)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Users.Remove(users);
                    db.SaveChanges();
                    return RedirectToAction("Users");
                }
                return View(User);
            }
            catch (Exception)
            {
                return View();
            }
        }

        #endregion

        #region Logger
        public IActionResult Logs()
        {
            DateTime date = DateTime.Now;
            string today = date.ToString("yyyy-MM-dd");
            string path = @"C:\temp\nlog-AspNetCore3-own-" + today + ".log";

            StreamReader stream = new StreamReader(path);

            List<string> logers = new List<string>();
            while (stream.Peek() > -1)
            {
                logers.Add(stream.ReadLine());
            }
            return View(logers);
        }
        #endregion

        #region Orders
        [HttpGet]
        public IActionResult Orders()
        {
            _logger.LogInformation("(Admin)Admin/Orders has been called");
            //ViewData["Orders"] = db.Orders.ToList();

            return View(db.Orders.ToList());

        }
        [HttpGet]
        public IActionResult OrdersDone()
        {
            _logger.LogInformation("(Admin)Admin/Orders has been called");
            //ViewData["Orders"] = db.Orders.ToList();

            return View(db.Orders.ToList());

        }
        [HttpGet]
        public IActionResult OrderEdit(int? id)
        {
            if (id == null)
            {
                return BadRequest("Wrong input data!");
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost]
        public IActionResult OrderEdit(Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(order).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Orders");
                }
                return View(order);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
        [HttpGet]
        public ActionResult OrderDelete(int? id)
        {
            if (id == null)
            {
                return BadRequest("not found");
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost]
        public IActionResult OrderDelete(Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Orders.Remove(order);
                    db.SaveChanges();
                    return RedirectToAction("Orders");
                }
                return View(order);
            }
            catch (Exception)
            {
                return View();
            }
        }
        #endregion

        #region MaterialList
        [HttpGet]
        public IActionResult MaterialList()
        {
            _logger.LogInformation("(Admin)Admin/MaterialList has been called");

            return View(db.materialLists.ToList());
        }

        [HttpGet]
        public IActionResult MaterialListAdd()
        {
            return View();
        }


        [HttpPost]
        public IActionResult MaterialListAdd(MaterialList materialList)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var foo = db.materialLists.Where(v => v.Name == materialList.Name);

                    var fooCount = foo.Count();
                    if (fooCount == 0)
                    {
                        db.materialLists.Add(materialList);
                        db.SaveChanges();
                        return RedirectToAction("MaterialList");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Այդպիսի դաշտ արդեն գոյություն ունի!");
                    }

                }
                return View(materialList);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return View();
            }
        }
        #endregion

        #region ForWhom
        [HttpGet]
        public IActionResult ForWhom()
        {
            _logger.LogInformation("(Admin)Admin/ForWhom has been called");

            return View(db.ForWhoms.ToList());
        }

        [HttpGet]
        public IActionResult ForWhomAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForWhomAdd(ForWhom forWhom)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var foo = db.ForWhoms.Where(v => v.Name == forWhom.Name);

                    var fooCount = foo.Count();
                    if (fooCount == 0)
                    {
                        db.ForWhoms.Add(forWhom);
                        db.SaveChanges();
                        return RedirectToAction("ForWhom");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Այդպիսի դաշտ արդեն գոյություն ունի!");
                    }

                }
                return View(forWhom);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return View();
            }
        }

        [HttpGet]
        public IActionResult ForWhomEdit(int? id)
        {
            if (id == null)
            {
                return BadRequest("Wrong input data!");
            }
            ForWhom forWhom = db.ForWhoms.Find(id);
            if (forWhom == null)
            {
                return NotFound();
            }
            return View(forWhom);
        }
        [HttpPost]
        public IActionResult ForWhomEdit(ForWhom forWhom)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(forWhom).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ForWhom");
                }
                return View(forWhom);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        [HttpPost]
        public IActionResult ForWhomDelete(ForWhom forWhom)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ForWhoms.Remove(forWhom);
                    db.SaveChanges();
                    return RedirectToAction("ForWhom");
                }
                return View(forWhom);
            }
            catch (Exception)
            {
                return View();
            }
        }

        #endregion

        #region Materials
        [HttpGet]
        public IActionResult Materials()
        {
            _logger.LogInformation("(Admin)Admin/Materials has been called");
            //return View(db.Materials.AsEnumerable().GroupBy(row => row.Name).Select(group => group.First()));
            return View(db.Materials.ToList());
        }

        [HttpGet]
        public IActionResult AddMaterial()
        {
            ViewData["Products"] = db.Products.ToList();
            ViewData["MaterialList"] = db.materialLists.ToList();

            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddMaterial(Material material)
        {
            ViewData["Products"] = db.Products.ToList();
            ViewData["MaterialList"] = db.materialLists.ToList();

            try
            {
                if (ModelState.IsValid)
                {
                    var foo = db.Materials.Where(v => v.Name == material.Name && v.ProductID == material.ProductID);

                    var fooCount = foo.Count();
                    if (fooCount == 0)
                    {
                        db.Materials.Add(material);
                        db.SaveChanges();
                        return RedirectToAction("Materials");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ապրանք, որը ունի հետևյալ նյութը գոյություն ունի!");
                    }


                }
                return View(material);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return View();
            }
        }

        [HttpPost]
        public IActionResult MaterialDelete(Material material)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Materials.Remove(material);
                    db.SaveChanges();
                    return RedirectToAction("Materials");
                }
                return View(material);
            }
            catch (Exception)
            {
                return View();
            }
        }
        #endregion

        #region ProductCategoryList
        [HttpGet]
        public IActionResult ProductCategoryList()
        {
            _logger.LogInformation("(Admin)Admin/ProductCategoryList has been called");

            return View(db.Categories.ToList());
        }

        [HttpGet]
        public IActionResult ProductCategoryListAdd()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProductCategoryListAdd(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var foo = db.Categories.Where(v => v.CategoryName == category.CategoryName);

                    var fooCount = foo.Count();
                    if (fooCount == 0)
                    {
                        db.Categories.Add(category);
                        db.SaveChanges();
                        return RedirectToAction("ProductCategoryList");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Այդպիսի դաշտ արդեն գոյություն ունի!");
                    }
                }
                return View(category);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return View();
            }
        }

        [HttpGet]
        public IActionResult ProductCategoryListEdit(int? id)
        {
            if (id == null)
            {
                return BadRequest("Wrong input data!");
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult ProductCategoryListEdit(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(category).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ProductCategoryList");
                }
                return View(category);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        [HttpGet]
        public ActionResult ProductCategoryListDelete(int? id)
        {
            if (id == null)
            {
                return BadRequest("not found");
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult ProductCategoryListDelete(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Categories.Remove(category);
                    db.SaveChanges();
                    return RedirectToAction("ProductCategoryList");
                }
                return View(category);
            }
            catch (Exception)
            {
                return View();
            }
        }
        #endregion

        #region AboutSection

        [HttpGet]
        public IActionResult AboutSection()
        {
            _logger.LogInformation("(Admin)Admin/AboutSection has been called");

            return View(db.AboutSections.ToList());
        }

        [HttpGet]
        public IActionResult AboutSectionAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AboutSectionAdd(AboutSection about)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.AboutSections.Add(about);
                    db.SaveChanges();
                    return RedirectToAction("AboutSection");
                }
                return View(about);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return View();
            }
        }

        [HttpGet]
        public IActionResult AboutSectionEdit(int? id)
        {
            if (id == null)
            {
                return BadRequest("Wrong input data!");
            }
            AboutSection about = db.AboutSections.Find(id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }

        [HttpPost]
        public IActionResult AboutSectionEdit(AboutSection about)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(about).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("AboutSection");
                }
                return View(about);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        [HttpPost]
        public IActionResult AboutSectionDelete(AboutSection about)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.AboutSections.Remove(about);
                    db.SaveChanges();
                    return RedirectToAction("AboutSection");
                }
                return View(about);
            }
            catch (Exception)
            {
                return View();
            }
        }
        #endregion


        #region ContactSection
        [HttpGet]
        public IActionResult ContactSection()
        {
            return View(db.ContactSections.ToList());
        }

        [HttpPost]
        public IActionResult ContactSectionDelete(ContactSection contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ContactSections.Remove(contact);
                    db.SaveChanges();
                    return RedirectToAction("ContactSection");
                }
                return View(contact);
            }
            catch (Exception)
            {
                return View();
            }
        }
        #endregion

        #region HeadSection
        [HttpGet]
        public IActionResult HeadSectionEdit(int? id)
        {
            if (id == null)
            {
                return BadRequest("Wrong input data!");
            }
            HeadSection head = db.HeadSections.Find(id);
            if (head == null)
            {
                return NotFound();
            }
            return View(head);
        }

        [HttpPost]
        public IActionResult HeadSectionEdit(HeadSection head)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(head).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("HeadSection");
                }
                return View(head);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
        public IActionResult HeadSection()
        {
            return View(db.HeadSections.ToList());
        }
        #endregion

        #region StaffSection
        public IActionResult StaffSection()
        {
            return View(db.StaffSections.ToList());
        }

        [HttpGet]
        public IActionResult StaffSectionAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StaffSectionAdd(StaffSection staff)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.StaffSections.Add(staff);
                    db.SaveChanges();
                    return RedirectToAction("StaffSection");
                }
                return View(staff);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult StaffSectionEdit(int? id)
        {
            if (id == null)
            {
                return BadRequest("Wrong input data!");
            }
            StaffSection staff = db.StaffSections.Find(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        [HttpPost]
        public IActionResult StaffSectionEdit(StaffSection staff)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(staff).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("StaffSection");
                }
                return View(staff);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        [HttpPost]
        public IActionResult StaffSectionDelete(StaffSection staff)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.StaffSections.Remove(staff);
                    db.SaveChanges();
                    return RedirectToAction("StaffSection");
                }
                return View(staff);
            }
            catch (Exception)
            {
                return View();
            }
        }
        #endregion


        #region ProductsSection

        public IActionResult Index()
        {
            ViewData["Materials"] = db.Materials.ToList();

            return View(db.Products.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Categories"] = db.Categories.ToList();
            ViewData["Products"] = db.Products.ToList();
            ViewData["ForWhom"] = db.ForWhoms.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            ViewData["Categories"] = db.Categories.ToList();
            ViewData["Products"] = db.Products.ToList();
            ViewData["ForWhom"] = db.ForWhoms.ToList();
            try
            {
                if (ModelState.IsValid)
                {
                    var foo = db.Products.Where(v => v.Name == product.Name);
                    var fooCount = foo.Count();
                    if (fooCount == 0)
                    {
                        db.Products.Add(product);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Այդպիսի անունով պրոդուկտ արդեն գոյություն ունի!");
                    }
                }
                return View(product);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewData["Categories"] = db.Categories.ToList();
            ViewData["Materials"] = db.Materials.ToList();
            ViewData["Products"] = db.Products.ToList();
            ViewData["ForWhom"] = db.ForWhoms.ToList();
            if (id == null)
            {
                return BadRequest("Wrong input data!");
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            ViewData["Materials"] = db.Materials.ToList();

            if (id == null)
            {
                return BadRequest("not found");
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            ViewData["Materials"] = db.Materials.ToList();

            try
            {
                if (ModelState.IsValid)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch (Exception)
            {
                return View();
            }
        }
        #endregion
    }
}
