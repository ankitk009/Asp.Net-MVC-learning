using SampleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleApplication.Controllers
{
    public class HomeController : Controller
    {
        private MydatabaseEntities _db = new MydatabaseEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(_db.MyApp.ToList());
        }

 

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude ="Id")] MyApp recordtocreate)
        {
            if (!ModelState.IsValid)
                return View();

            _db.MyApp.Add(recordtocreate);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var movieToEdit = (from m in _db.MyApp
                               where m.Id == id
                               select m).First();
            return View(movieToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(MyApp RecordtoEdit)
        {
            var Originalrecord = (from m in _db.MyApp
                                  where m.Id == RecordtoEdit.Id
                                  select m).First();
            if (!ModelState.IsValid)
                return View(Originalrecord);

            _db.Entry(Originalrecord).CurrentValues.SetValues(RecordtoEdit);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
