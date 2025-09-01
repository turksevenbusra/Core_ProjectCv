using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Footer
{
    public class FooterList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
