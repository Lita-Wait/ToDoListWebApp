using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoList.Domain.Entity;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        private ILogger<TaskController> _logger;
        public TaskController(ILogger<TaskController> logger) 
        {
            _logger = logger;
        } 

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskEntity model)
        {
            _logger.LogInformation($"Создание задачи {model.Name}, {model.Priority}, {model.Description}");
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(model);
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, "Произошла ошибка при попытке создания задачи");
                throw;
            }
            
        }
    }
}