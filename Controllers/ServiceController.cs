using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        public IActionResult Index()
        {
            var serviveValues = serviceManager.TGetList();
            return View(serviveValues);
        }
        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            serviceManager.TAdd(service);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteService(int id)
        {
            var sil = serviceManager.TGetById(id);
            serviceManager.TDelete(sil);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditService(int id)
        {
            var getir= serviceManager.TGetById(id);
            return View(getir);
        }
        [HttpPost]
        public IActionResult EditService(Service service)
        {
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }

    }
}
