using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity == null || !User.Identity.IsAuthenticated)
            {
                
                return RedirectToAction("Index", "Login");
            }
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.Surname;

            //Weather Api
            string api = "43a5e463bb2f2777c2aa47ba56b858a6";
            string connection = " https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&appid=" + api;
            XDocument xDocument = XDocument.Load(connection);
            ViewBag.v5 = xDocument.Descendants("temperature").ElementAt(0).Attribute("value").Value;


            //statistics
            Context c = new Context();
            ViewBag.v1 = c.WriterMessages.Where(x => x.Receiver == values.Email).Count();
            ViewBag.v2 = c.Announcements.Count();
            ViewBag.v3 = c.Users.Count();
            ViewBag.v4 = c.Skills.Count();
            return View();
        }
    }
}
/*
 https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&appid=43a5e463bb2f2777c2aa47ba56b858a6
 */