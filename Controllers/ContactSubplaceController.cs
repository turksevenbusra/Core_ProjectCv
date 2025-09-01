using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactSubplaceController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        [HttpGet]
        public IActionResult Index()
        {
            var degerler= contactManager.TGetList();
            return View(degerler);
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contactManager.TUpdate(contact);
            return RedirectToAction("Index");
        }

    }
}
