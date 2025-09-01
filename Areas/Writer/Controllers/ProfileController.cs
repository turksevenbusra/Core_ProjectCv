using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Core_Project.Areas.Writer.Models;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    //[Route("Write/[controller]/[action]")]

    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
        public ProfileController(UserManager<WriterUser> userManager)  
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname= values.Surname;  
            model.PictureUrl= values.ImageUrl;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Picture != null) {
                var resource = Directory.GetCurrentDirectory();
                var extension= Path.GetExtension(p.Picture.FileName);
                var imageName= Guid.NewGuid()+extension;
                var saveLocation= resource+ "/wwwroot/userimage/" + imageName;
                var stream= new FileStream(saveLocation, FileMode.Create);
                await p.Picture.CopyToAsync(stream);
                values.ImageUrl = imageName;
            }
            values.Name = p.Name;
            values.Surname= p.Surname;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, p.Password);
            var result =await _userManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
                return View();
        }
    }
}
