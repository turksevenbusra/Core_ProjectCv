using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IActionResult Index()
        {
            var degerler = portfolioManager.TGetList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            PortfolioValidator validationRules = new PortfolioValidator();
            ValidationResult result = validationRules.Validate(portfolio);
            if (result.IsValid) 
            {
                portfolioManager.TAdd(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var pv in result.Errors)
                {
                    ModelState.AddModelError(pv.PropertyName, pv.ErrorMessage);
                }
            }
            return View();
            
        }
        public IActionResult DeletePortfolio(int id)
        {
            var idBul = portfolioManager.TGetById(id);
            portfolioManager.TDelete(idBul);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            var getir = portfolioManager.TGetById(id);
            return View(getir);
        }
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            PortfolioValidator validator = new PortfolioValidator();
            ValidationResult result = validator.Validate(portfolio);
            if (result.IsValid)
            {
                portfolioManager.TUpdate(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var pv in result.Errors)
                {
                    ModelState.AddModelError(pv.PropertyName, pv.ErrorMessage);
                }
            }
            return View();  
        }
    }
}
