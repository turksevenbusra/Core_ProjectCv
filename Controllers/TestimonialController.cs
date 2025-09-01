using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager= new TestimonialManager(new EfTestimonialDal());
        public IActionResult Index()
        {
            var degerler = testimonialManager.TGetList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            testimonialManager.TAdd(testimonial);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditTestimonial(int id)
        {
            var getir = testimonialManager.TGetById(id);
            return View(getir);
        }
        [HttpPost]
        public IActionResult EditTestimonial(Testimonial testimonial)
        {
            testimonialManager.TUpdate(testimonial);
            return RedirectToAction("Index");
        }
        [HttpGet]   
        public IActionResult TestimonialDetails(int id)
        {
            var details = testimonialManager.TGetById(id);
            return View(details);   
        }
        public IActionResult DeleteTestimonial(int id)
        {
            var sil = testimonialManager.TGetById(id);
            testimonialManager.TDelete(sil);
            return RedirectToAction("Index");
        }
    }
}
