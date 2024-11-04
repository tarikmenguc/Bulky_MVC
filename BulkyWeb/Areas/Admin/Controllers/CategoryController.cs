using BulkyWeb.Data;
using Bulky.DataAccess.Repository;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;

namespace BulkyWeb.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        //private readonly ICategoryRepository _categoryRepo;
        //public CategoryController( ICategoryRepository db)
        //{
        //    _categoryRepo = db;
        //}
        //public IActionResult Index()
        //{
        //    List<Category> objcategorylist = _categoryRepo.GetAll().ToList();   
        //    return View(objcategorylist);
        //}
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Category obj)
        //{
        //    if (obj.Name == obj.DisplayOrder.ToString())
        //    {
        //        ModelState.AddModelError("name", "the Display Order cannot exactly match the name ");
        //    }

        //    if (ModelState.IsValid) {
        //        _categoryRepo.Add(obj);
        //        _categoryRepo.Save();
        //        TempData["Success"]= "Category Create Sucsessfully";
        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}


        //public IActionResult Edit(int? id)
        //{
        //    if (id== null || id== 0)
        //    {
        //        return NotFound();
        //    }
        //    Category categoryfromdb = _categoryRepo.Get(u=>u.ID==id);
        //    if (categoryfromdb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(categoryfromdb);
        //}
        //[HttpPost]
        //public IActionResult Edit(Category obj)
        //{


        //    if (ModelState.IsValid)
        //    {
        //        _categoryRepo.Update(obj);
        //        _categoryRepo.Save();
        //        TempData["Success"] = "Category Update Sucsessfully";
        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}

        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Category categoryfromdb = _categoryRepo.Get(u => u.ID == id);
        //    if (categoryfromdb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(categoryfromdb);
        //}
        //[HttpPost,ActionName("Delete")]
        //public IActionResult DeletePost(int? id)
        //{
        //    Category? obj = _categoryRepo.Get(u => u.ID == id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    _categoryRepo.Remove(obj);
        //    _categoryRepo.Save();
        //    TempData["Success"] = "Category Delete Sucsessfully";
        //    return RedirectToAction("Index");



        //    //return View();


        //[Area("Admin")]
        //[Authorize(Roles = SD.Role_Admin)]


        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.ID == id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.ID == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _unitOfWork.Category.Get(u => u.ID == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
