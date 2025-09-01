using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]")]
    public class MessageController : Controller
    {
        WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        private readonly UserManager<WriterUser> _userManager;

        public MessageController(WriterMessageManager writerMessageManager, UserManager<WriterUser> userManager)
        {
            _writerMessageManager = writerMessageManager;
            _userManager = userManager;
        }
        [Route("")]
        [Route("ReceiverMessage")]
        public async Task<IActionResult> ReceiverMessage()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var email = user.Email;
            var messages = _writerMessageManager.GetListReceiverMessage(email);

            return View(messages);
        }
        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var email = user.Email;
            var messages = _writerMessageManager.GetListReceiverMessage(email);
            return View(messages ?? new List<WriterMessage>());
        }
        [Route("MessageDetails/{id}")]
        public IActionResult MessageDetails(int id)
        {
            WriterMessage writerMessage = _writerMessageManager.TGetById(id);
            return View(writerMessage);
        }
        [Route("ReceiverMessageDetails/{id}")]
        public IActionResult ReceiverMessageDetails(int id)
        {
            WriterMessage writerMessage = _writerMessageManager.TGetById(id);
            return View(writerMessage);
        }
        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage writer)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name= values.Name+ " "+values.Surname;
            writer.Date= Convert.ToDateTime(DateTime.Now.ToShortDateString());
            writer.Sender = mail;
            writer.SenderName = name;
            Context c = new Context();
            var userNameSurname = c.Users.Where(x => x.Email == writer.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            writer.ReceiverName = userNameSurname;
            _writerMessageManager.TAdd(writer);
            return RedirectToAction("SenderMessage");
        }
    }
}
