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
    }
}
