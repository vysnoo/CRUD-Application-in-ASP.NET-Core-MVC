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

        //GET
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

    }
}
