using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager messageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IActionResult ReceiverMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var degerler = messageManager.GetListReceiverMessage(p);
            return View(degerler);
        }
        public IActionResult SenderMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var degerler = messageManager.GetListSenderMessage(p);
            return View(degerler);
        }
        [HttpGet]
        public IActionResult AdminMessageDetails(int id)
        {
            var values = messageManager.TGetById(id);
            return View(values);
        }
        public IActionResult DeleteAdminMessage(int id)
        {
            var deger = messageManager.TGetById(id);
            messageManager.TDelete(deger);
            if (deger.Receiver=="admin@gmail.com")
            {
                return RedirectToAction("ReceiverMessageList");
            }
            else if (deger.Sender == "admin@gmail.com")
            {
                return RedirectToAction("SenderMessageList");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public IActionResult SendAdminMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendAdminMessage(WriterMessage writerMessage)
        {
            writerMessage.Sender = "admin@gmail.com";
            writerMessage.SenderName = "Admin";
            writerMessage.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            Context x = new Context();
            var userNameSurname = x.Users.Where(x => x.Email == writerMessage.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            writerMessage.ReceiverName = userNameSurname;
            messageManager.TAdd(writerMessage);
            return RedirectToAction("Index");
        }
    }
}
