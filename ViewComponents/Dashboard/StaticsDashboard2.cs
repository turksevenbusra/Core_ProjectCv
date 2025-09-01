using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
    public class StaticsDashboard2 : ViewComponent
    {
        Context db = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.p1 = db.Portfolios.Count();
            ViewBag.p2 = db.Messages.Count();
            ViewBag.p3 = db.Services.Count();
            return View();  
        }
    }
}
