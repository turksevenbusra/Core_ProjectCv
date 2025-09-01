using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core_Project.Areas.Writer.ViewComponents
{
    public class Notification : ViewComponent
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());

        public IViewComponentResult Invoke()
        {
            var values= announcementManager.TGetList();
            return View(values);
        }
    }
}
