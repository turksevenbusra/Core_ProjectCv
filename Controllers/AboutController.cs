using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public IActionResult Index()
        {
            var degerler = aboutManager.TGetList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult EditAbout(int id)
        {
            var getir= aboutManager.TGetById(id);
            return View(getir);
        }
        [HttpPost]
        public IActionResult EditAbout(About about)
        {
            aboutManager.TUpdate(about);
            return RedirectToAction("Index");
        }

    }
}
