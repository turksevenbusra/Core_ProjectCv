using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        public IActionResult Index()
        {
            var degerler = featureManager.TGetList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult EditFeature(int id)
        {
            var getir = featureManager.TGetById(id);
            return View(getir);
        }
        [HttpPost]
        public IActionResult EditFeature(Feature fetaure)
        {
            featureManager.TUpdate(fetaure);
            return RedirectToAction("Index");
        }
    }
}
