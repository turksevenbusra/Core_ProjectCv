using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Project.Controllers
{
    public class WriterUserController : Controller
    {
        WriterUserManager userManager = new WriterUserManager(new EfWriterUserDal());
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult ListUser()
        {
            var values = JsonConvert.SerializeObject(userManager.TGetList());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddUser(WriterUser writer)
        {
            userManager.TAdd(writer);
            var values = JsonConvert.SerializeObject(writer);
            return Json(values);
        }
        public IActionResult GetById(int id)
        {
            var v=userManager.TGetById(id);
            var values= JsonConvert.SerializeObject(v);
            return Json(values);
        }
    }
}
