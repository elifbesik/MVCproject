using Microsoft.AspNetCore.Mvc;
using MVCproject.DataContext;
using MVCproject.Models;
namespace MVCproject.Controllers
{
    public class ToDoController : Controller
    {
        // temp data ile bir actiondan başka bir action metoduna veri taşımak için kullanılır .
        // aynı zamanda o diğer actionun view tarafına veri taşıyabilirz

        private readonly ToDoContext DB;
        public ToDoController(ToDoContext db)
        {
            DB = db;
        }

        [HttpGet]
        public IActionResult ToDoView()
        {
            IList<ToDoModel> list = DB.ToDoSet.ToList();
            return View(list);
        }

        [HttpPost]
        public JsonResult Add(ToDoModel todo)
        {
            DB.ToDoSet.Add(todo);
            DB.SaveChanges();
            return Json(todo);
        }
        [HttpPost]
        public JsonResult Delete (int? id)
        {
            var todo =DB.ToDoSet.Find(id);
            DB.ToDoSet.Remove(todo);
            DB.SaveChanges();
            return Json(todo);
        }
        [HttpPost]
        public JsonResult Update(ToDoModel todo)
        {
            var todoRow = DB.ToDoSet.Find(todo.Id);
            todoRow.IsComplete = todo.IsComplete;
            DB.ToDoSet.Update(todoRow);
            DB.SaveChanges();
            return Json(todoRow);
        }
    }
}
