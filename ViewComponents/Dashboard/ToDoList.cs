using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
    public class ToDoList : ViewComponent
    {
        ToDoListManager toDoListManager = new ToDoListManager(new EfToDoListDal());
        public IViewComponentResult Invoke()
        {
            var degerler= toDoListManager.TGetList();   
            return View(degerler);
        }
    }
}
