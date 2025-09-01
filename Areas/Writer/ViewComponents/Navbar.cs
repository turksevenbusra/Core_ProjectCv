using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks;
using System.IO;

namespace Core_Project.Areas.Writer.ViewComponents
{
    [Area("Writer")]
    public class Navbar : ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public Navbar(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            // Varsayılan resim
            string defaultImage = "default.jpg";

            // Eğer kullanıcıda ImageUrl varsa onu al, yoksa default kullan
            var imageName = user?.ImageUrl ?? defaultImage;

            // Dosya var mı kontrol et (silinmişse defaulta dön)
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userimage", imageName);
            if (!System.IO.File.Exists(path))
            {
                imageName = defaultImage;
            }

            ViewBag.v = imageName;

            return View();
        }

    }
}
