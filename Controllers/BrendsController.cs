﻿using homework_54.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_54.Controllers
{
    public class BrendsController : Controller
    {
        private StoreContext _db;
        public BrendsController(StoreContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Brend> brends = _db.Brends.ToList();
            return View(brends);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var brand = _db.Brends.FirstOrDefault(t => t.Id == id);
            _db.Brends.Remove(brand);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(Brend brend)
        {
            List<Brend> brends = _db.Brends.ToList();
            List<Brend> Newbrends = new List<Brend>();
            Newbrends.Add(brend);
            if (brend != null)
            {
                Boolean b3 = brends.Any(x => Newbrends.Select(y => y.Name).Contains(x.Name));
                if (b3 != true)
                {
                    _db.Brends.Add(brend);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        public bool CheckName(Brend Brand)
        {
            var brend = _db.Brends.Any(b => b.Name == Brand.Name);
            return brend;
        }
        public bool CheckDate(Brend brend)
        {
            if (brend.DataOfCreate > DateTime.Now.AddYears(-100) && brend.DataOfCreate < DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}