using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoList.Domain.Entity;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskEntity model)
        {
            Debug.WriteLine(model.Name);
            Debug.WriteLine(model.Description);
            Debug.WriteLine(model.Priority);

            if(ModelState.IsValid)
            {
                return Ok(model);
            }
            return View("Index");
        }
    }
}