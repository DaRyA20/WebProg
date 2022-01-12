using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using WebApplicationFromOnlineStore.Models;
using System.Data.Entity.Infrastructure;

namespace WebApplicationFromOnlineStore.Controllers
{
    public class OnlineStoreController : Controller
    {
        DBBase db = new DBBase();

        public ActionResult Index()
        {
            return View();
        }
        // GET: OnlineStore
        public ActionResult IndexProduct()
        {
            var products = db.dBProducts.Include(x => x.Categorys);
            products.Include(x => x.Manufacturer);
            return View(products.ToList());
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            // Формируем список команд для передачи в представление
            SelectList productsCategory = new SelectList(db.dBCategories, "CategoryId", "CategoryName");
            SelectList productsManufacturer = new SelectList(db.dBManufacturers, "ManufacturerId", "ManufacturerName");
            ViewBag.ProductsCategory = productsCategory;
            ViewBag.ProductsManufacturer = productsManufacturer;
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(DBProduct products)
        {
            db.dBProducts.Add(products);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("IndexProduct");
        }
        public ActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            DBProduct products = db.dBProducts.Find(id);
            if (products != null)
            {
                // Создаем список команд для передачи в представление
                SelectList productsCategory = new SelectList(db.dBCategories, "CategoryId", "CategoryName", products.ProductType);
                SelectList productsManufacturer = new SelectList(db.dBManufacturers, "ManufacturerId", "ManufacturerName", products.ManufacturerIds);
                ViewBag.ProductsCategory = productsCategory;
                ViewBag.ProductsManufacturer = productsManufacturer;
                return View(products);
            }
            return RedirectToAction("IndexProduct");
        }

        [HttpPost]
        public ActionResult EditProduct(DBProduct products)
        {
            db.Entry(products).State = EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("IndexProduct");
        }

        [HttpGet]
        public ActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var product = db.dBProducts.Include(x => x.Categorys)
                            .Include(x => x.Manufacturer)
                            .First(x => x.ProductId == id);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("DeleteProduct")]
        public ActionResult DeleteProducts(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            DBProduct b = db.dBProducts.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.dBProducts.Remove(b);
            db.SaveChanges();
            return RedirectToAction("IndexProduct");
        }
        public ActionResult IndexEmployee()
        {
            var employee = db.dBEmployees.Include(x => x.Position);
            return View(employee.ToList());
        }

        public ActionResult EditEmployee(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            DBEmployee employee = db.dBEmployees.Find(id);
            if (employee != null)
            {

                SelectList position = new SelectList(db.dBPositions, "PositionId", "PositionName", employee.EmployeePositionId);
                ViewBag.Position = position;
                return View(employee);
            }
            return RedirectToAction("IndexEmployee");
        }

        [HttpPost]
        public ActionResult EditEmployee(DBEmployee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("IndexEmployee");
        }

        public ActionResult CreateEmployee()
        {
            SelectList position = new SelectList(db.dBPositions, "PositionId", "PositionName");
            ViewBag.Position = position;
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(DBEmployee employee)
        {
            //Добавляем игрока в таблицу
            db.dBEmployees.Add(employee);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("IndexEmployee");
        }
        [HttpGet]
        public ActionResult DeleteEmployee(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var employees = db.dBEmployees.Include(x => x.Position)
                                            .First(x => x.EmployeeId == id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }
        [HttpPost, ActionName("DeleteEmployee")]
        public ActionResult DeletedBEmployees(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            DBEmployee b = db.dBEmployees.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.dBEmployees.Remove(b);
            db.SaveChanges();
            return RedirectToAction("IndexEmployee");
        }

        [HttpGet]
        public ActionResult CreateManufacturer()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult CreateManufacturer(DBManufacturer manufacturer)
        {
            db.dBManufacturers.Add(manufacturer);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(DBCategory category)
        {
            db.dBCategories.Add(category);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreatePosition()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult CreatePosition(DBPosition position)
        {
            db.dBPositions.Add(position);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index");
        }

        public ActionResult IndexProductAvailability()
        {
            var products = db.dBProductAvailabilities.Include(x => x.Premises);
            products.Include(x => x.Product);
            products.Include(x => x.Product.Manufacturer);
            return View(products.ToList());
        }

        public ActionResult EditProductAvailability(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            DBProductAvailability productAvailability = db.dBProductAvailabilities.Find(id);
            if (productAvailability != null)
            {
                SelectList premises = new SelectList(db.dBPremises, "PremisesId", "PremisesName", productAvailability.ProductAvailability_PremisesId);
                SelectList product = new SelectList(db.dBProducts, "ProductId", "ProductName", productAvailability.ProductAvailability_ProductId);
                ViewBag.Premises = premises;
                ViewBag.Product = product;
                return View(productAvailability);
            }
            return RedirectToAction("IndexProductAvailability");
        }

        [HttpPost]
        public ActionResult EditProductAvailability(DBProductAvailability productAvailability)
        {
            db.Entry(productAvailability).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("IndexProductAvailability");
        }
    }
}