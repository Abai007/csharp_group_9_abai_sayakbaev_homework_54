using homework_54.Models;
using homework_54.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_54.Controllers
{
    public class ProductsController : Controller
    {
        private StoreContext _db;
        IEnumerable<Brend> brands = new List<Brend>();
        public ProductsController(StoreContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Phone> products = _db.Products.ToList();
            return View(products);
        }
        public IActionResult Index1(int id)
        {
            var viewModel = new BrandAndCompanyViewModel();
            viewModel.Product = _db.Products.FirstOrDefault(e => e.Id == id);
            viewModel.Product.Brend = _db.Brends.FirstOrDefault(e => e.Id == viewModel.Product.BrendId);
            return View(viewModel);
        }
        public IActionResult Create()
        {
            brands = _db.Brends.ToList();
            ViewBag.brands = new SelectList(brands, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(BrandAndCompanyViewModel p)
        {
            Phone prod = new Phone();
            prod.Name = p.Product.Name;
            prod.Price = p.Product.Price;
            prod.Image = p.Product.Image;
            prod.BrendId = p.Product.BrendId;
            prod.Brend = _db.Brends.FirstOrDefault(b => b.Id == p.Product.BrendId);
            if (prod != null)
            {
                _db.Products.Add(prod);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
            
        }
       public IActionResult EditingProduct(int id)
        {
            BrandAndCompanyViewModel PCB = new BrandAndCompanyViewModel();
            brands = _db.Brends.ToList();
            ViewBag.brands = new SelectList(brands, "Id", "Name");
            PCB.Product = _db.Products.FirstOrDefault(p => p.Id == id);
            PCB.Product.Brend = _db.Brends.FirstOrDefault(p => p.Id == PCB.Product.BrendId);
            return View(PCB);
        }
        [HttpPost]
        public ActionResult EditingProduct(Phone product)
        {
            Phone p = _db.Products.FirstOrDefault(p => p.Id == product.Id);
            p.Name = product.Name;
            p.Price = product.Price;
            p.Brend = _db.Brends.Find(product.BrendId);
            p.Image = product.Image;
            _db.Products.Update(p);
            _db.SaveChanges();
            return RedirectToAction("index");

        }
    }
}
