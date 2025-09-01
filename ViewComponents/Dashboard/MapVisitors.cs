using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
    public class MapVisitors : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
