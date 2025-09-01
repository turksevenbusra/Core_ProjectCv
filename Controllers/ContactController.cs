using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        public IActionResult Index()
        {
            var values = contactManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult EditContact(int id)
        {
            var getir= contactManager.TGetById(id);
            return View(getir);
        }

        [HttpPost]
        public IActionResult EditContact(Contact contact)
        {
            contactManager.TUpdate(contact);
            return RedirectToAction("Index");
        }

    }
}
