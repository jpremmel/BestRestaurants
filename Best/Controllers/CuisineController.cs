using Microsoft.AspNetCore.Mvc;
using Best.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Best.Controllers
{
    public class CuisineController:Controller
    {
        private readonly BestContext _db;
        public CuisineController(BestContext db)
        {
            _db = db;
        }

        //GOT RID OF CUISINE INDEX VIEW
        // public ActionResult Index()
        // {
        //     List<Cuisine> model = _db.Cuisines.Include(m => m.Restaurant).ToList();
        //     // ViewBag.RestaurantId = id;
        //     return View(model);
        // }

        //Cuisine Create: displays a form to make a new cuisine
        public ActionResult Create(int id)
        {
            //find the restaurant from DB
            //pass in as model
            ViewBag.RestaurantId = id;
            return View();
        }

        //Cuisine Create Post: Accepts new cuisine object from form, adds it to database, and redirects to Restaurant Details page
        [HttpPost]
        public ActionResult Create(Cuisine cuisines)
        {
            // Console.WriteLine(">>>>>ID passed in to Cuisine Controller Create Method: " + id);
            _db.Cuisines.Add(cuisines);
            _db.SaveChanges();
            return RedirectToAction("Details", "Restaurant", new { id = cuisines.RestaurantId });
        }

        //Displays details for a cuisine
        public ActionResult Details(int id)
        {
            Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(m => m.CuisineId == id);
            return View(thisCuisine);
        }

    }
}