using Autofac;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Test.Web.Models;

namespace Test.Web.Controllers
{
    public class MedicineController : Controller
    {
        ILifetimeScope _scope;
        ILogger<MedicineController> _logger;
        public MedicineController(ILifetimeScope scope, ILogger<MedicineController> logger)
        {
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Create()
        {
            var model = _scope.Resolve<MedicineCreateModel>();

            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(MedicineCreateModel model)
        {
            model.ResolveDependency(_scope);

            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateMedicine();
                    //TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    //{
                    //    Message = "Successfully added a new course.",
                    //    Type = ResponseTypes.Success
                    //});
                    return RedirectToAction("Create");
                }
                catch (DuplicateNameException ex)
                {
                    _logger.LogError(ex, ex.Message);
                    //TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    //{
                    //    Message = ex.Message,
                    //    Type = ResponseTypes.Danger
                    //});
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Server Error");

                    //TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    //{
                    //    Message = "There was a problem in creating course.",
                    //    Type = ResponseTypes.Danger
                    //});
                }
            }

            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
