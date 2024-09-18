using CRUD_Application.Data;
using Microsoft.AspNetCore.Mvc;

using CRUD_Application.Models;
namespace CRUD_Application.Controllers
{
    public class CrudController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CrudController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Name> objList = _db.Names.ToList();
            return View(objList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Name obj)
        {
            if(obj.FirstName==obj.LastName)
            {
                ModelState.AddModelError("LastName","First Name & Last Name does not exact same");
            }

            if (ModelState.IsValid)
            {
                _db.Names.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Update(int? id)
        {
            if(id==0 || id == null)
            {
                return NotFound();
            }

            var objList = _db.Names.Find(id);

            if (objList == null)
            {
                return NotFound();
            }

            return View(objList);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Name obj)
        {
            if (obj.FirstName == obj.LastName)
            {
                ModelState.AddModelError("LastName", "First Name & Last Name does not exact same");
            }

            if (ModelState.IsValid)
            {
                _db.Names.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var objList = _db.Names.Find(id);

            if (objList == null)
            {
                return NotFound();
            }

            return View(objList);
        }

        //GET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var objList= _db.Names.Find(id);
            if (objList == null)
            {
                return NotFound();
            }

                _db.Names.Remove(objList);
                _db.SaveChanges();
                return RedirectToAction("Index");   
         
        }

    }
}
