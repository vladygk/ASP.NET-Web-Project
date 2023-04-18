using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Context;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    public class ToDoTaskController : Controller
    {
        private readonly TodoListAppContext _db;

        public ToDoTaskController(TodoListAppContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var tasks = _db.ToDoTasks.ToList();

            return View(tasks);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDoTask task)
        {

            _db.ToDoTasks.Add(task);

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //GET
        public async Task<IActionResult> Edit(int Id)
        {
            var taskToEdit = await _db.ToDoTasks.FindAsync(Id);
            if (taskToEdit == null)
            {
                return NotFound();
            }

            return View(taskToEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ToDoTask task)
        {

            if (ModelState.IsValid)
            {
                _db.ToDoTasks.Update(task);
            }

            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var taskToDelete = await _db.ToDoTasks.FindAsync(Id);
            if (taskToDelete == null)
            {
                return NotFound();
            }

            _db.Remove(taskToDelete);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

      
    }
}
