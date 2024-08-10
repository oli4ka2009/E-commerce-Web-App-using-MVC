using Microsoft.AspNetCore.Mvc;
using OnlineStore_DataAccess.Repository.IRepository;
using OnlineStore_DataAccess.Repository;
using OnlineStoreWebApp.DataAccess.Data;
using OnlineStoreWebApp.Models.Models;
using OnlineStore_Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore_Models.ViewModels;
using Microsoft.AspNetCore.Routing.Constraints;
using OnlineStoreWebApp.DataAccess.Migrations;
using OnlineStore_Utility;
using Microsoft.AspNetCore.Authorization;

namespace OnlineStoreWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Company> objectCompanyList = _unitOfWork.Company.GetAll().ToList();

            return View(objectCompanyList);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                return View(new Company());
            }
            else
            {
                Company company = _unitOfWork.Company.Get(u => u.Id == id);
                return View(company);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.Id == 0)
                {
                    _unitOfWork.Company.Add(company);
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                }

                _unitOfWork.Save();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objectCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objectCompanyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyToDelete = _unitOfWork.Company.Get(u => u.Id == id);
            if (companyToDelete == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Company.Remove(companyToDelete);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delele successful" });
        }

        #endregion
    }
}
