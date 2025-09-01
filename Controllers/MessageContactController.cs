using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MessageContactController : Controller
    {
        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        public IActionResult Index()
        {
            var values = _messageManager.TGetList();
            return View(values);
        }
        //Burada AddMessage Defaullta site içinde kaydetme olduğunden Default/Index'de.
        public IActionResult DeleteMessage(int id)
        {
            var getir = _messageManager.TGetById(id);
            _messageManager.TDelete(getir);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var values = _messageManager.TGetById(id);
            return View(values);
        }
    }
}
