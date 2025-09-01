using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        SocialMediaManager mediaManager = new SocialMediaManager(new EfSocialMediaDal());
        public IActionResult Index()
        {
            var values = mediaManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            mediaManager.TAdd(socialMedia);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSocialMedia(int id)
        {
            var getir = mediaManager.TGetById(id);
            mediaManager.TDelete(getir);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            var getir1= mediaManager.TGetById(id);
            return View(getir1);
        }
        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia socialMedia)
        {
            mediaManager.TUpdate(socialMedia);
            return RedirectToAction("Index");
        }
    }
}
