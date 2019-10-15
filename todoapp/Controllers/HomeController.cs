using Microsoft.AspNetCore.Mvc;
using System.Linq;
using todoapp.Models;
using todoapp.ViewModels;

namespace todoapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TodoDatabase db;

        public HomeController(TodoDatabase db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index(int category = -1)
        {
            var todos = db.GetAllTodos(onlyIncomplete: true);

            var vm = new AllTodosVM()
            {
                Todos = todos.Select(ti => new TodoVM()
                {
                    Description = ti.Description,
                    TodoId = ti.TodoItemId,
                    Category = ti.Category
                }).ToList(),

                Count = todos.Count,
                SelectedCategory = (TodoCategory)category
            };

            if (0 <= category)
            {
                vm.Todos = vm.Todos.Where(ti => ti.Category == vm.SelectedCategory).ToList();
                vm.Count = vm.Todos.Count;
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult EditDescription(int id, TodoEditRequest request)
        {
            var todo = db.GetTodoById(id);
            if (todo == null) return NotFound();

            todo.Description = request.Description;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MarkAsCompleted(int id)
        {
            var todo = db.GetTodoById(id);
            if (todo == null) return NotFound();

            todo.IsCompleted = true;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            db.DeleteById(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(TodoCreateRequest request)
        {
            var newTodo = new TodoItem()
            {
                Description = request.Description,
                Category = request.Category
            };

            db.AddTodo(newTodo);

            return RedirectToAction("Index");
        }
    }
}
