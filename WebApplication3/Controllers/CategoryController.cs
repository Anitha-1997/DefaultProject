using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;

namespace WebApplication3.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            _categoryRepo.Add(obj);
            _categoryRepo.Save();
            TempData["success"] = "Added successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Category? categoryObjDb = _categoryRepo.Get(u=>u.Id ==Id);
            if (categoryObjDb == null)
            {
                return NotFound();
            }
            return View(categoryObjDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
               _categoryRepo.Update(obj);
                _categoryRepo.Save();
                TempData["success"] = "Updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? Id)
        {
            Category? obj = _categoryRepo.Get(u => u.Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? Id)
        {
            Category? obj = _categoryRepo.Get(u => u.Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            _categoryRepo.Remove(obj);
            _categoryRepo.Save();
            TempData["success"] = "Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
