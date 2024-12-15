using AspNetCoreGeneratedDocument;
using BlogCore.DataAccess.Data.Repository.IRepository;
using BlogCore.Model;
using Microsoft.AspNetCore.Mvc;

namespace UdemyMVCMVCNET8Project2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IContainerWork _cw;

        public CategoriesController(IContainerWork cw)
        {
            _cw = cw;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category form)
        {
            if (ModelState.IsValid)
            {
                _cw.CategoryRepository.Add(form);
                _cw.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(form);
        }

        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category cat = new Category();

            cat = _cw.CategoryRepository.Get(id);

            if(cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category form)
        {
            if (ModelState.IsValid)
            {
                _cw.CategoryRepository.Update(form);
                _cw.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(form);
        }

        #endregion

        #region call to API

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new {data = _cw.CategoryRepository.GetAll()});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Category objFromDB = _cw.CategoryRepository.Get(id);

            if(objFromDB == null)
            {
                return Json(new { success = false, message = "Error deleting category" });
            }

            _cw.CategoryRepository.Remove(objFromDB);
            _cw.Save();

            return Json(new { success = true, message = "Deleted was successful" });
        }

        #endregion
    }
}
