using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            var values = skillManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSkill(int id)
        {
            var idBul = skillManager.TGetById(id);
            skillManager.TDelete(idBul);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            var getir = skillManager.TGetById(id);
            return View(getir);
        }
        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}
