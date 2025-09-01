using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
    public class Last5Project : ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IViewComponentResult Invoke()
        {
            var degerler = portfolioManager.TGetList();
            return View(degerler);
        }
    }
}
