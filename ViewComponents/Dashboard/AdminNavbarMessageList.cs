using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList : ViewComponent
    {
        WriterMessageManager messageManager= new WriterMessageManager(new EfWriterMessageDal());
        public IViewComponentResult Invoke()
        {
            string p = "admin@gmail.com";
            var values = messageManager.GetListReceiverMessage(p).OrderByDescending(x => x.WriterUserId).Take(3).ToList();
            return View(values);
        }
    }
}
