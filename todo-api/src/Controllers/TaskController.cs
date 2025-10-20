using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Services;

namespace src.Controllers
{ 
    [ApiController]                                 // Enables automatic binding, validation help, and problem details
    [Route("api/[controller]")]                     // Route prefix; [controller] = "task" -> /api/task
    public class TaskController : ControllerBase    // Inherits core API features for handling HTTP requests and responses
    {
        // Reference to TaskService
        private readonly TaskService _taskService; 

        // ASP.NET Core creates TaskController and "injects" TaskService that
        // was registered in Program.cs. This keeps code testable and decoupled
        // Controller does not own data; it delegates to the Service
        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        // GET /api/task/
        [HttpGet]
        public ActionResult<List<TaskItem>> GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        // GET /api/task/{id}
        [HttpGet("{id}", Name = "GetTaskById")]
        public ActionResult<TaskItem> GetTaskById([FromRoute] string id)
        {
            // Validate request isnt null or empty
            if (string.IsNullOrWhiteSpace(id)) return BadRequest("id is required");

            // Call Service to get task
            var task = _taskService.GetTaskById(id);

            // Interpret task was found
            if (task is null) return NotFound();

            // Return valid response
            return Ok(task);
        }

        // POST /api/task/
        [HttpPost]
        public ActionResult<TaskItem> CreateTask([FromBody] string title)
        {
            throw new NotImplementedException();  // temp

            // TODO: 
            // Validate request isnt null or empty
            // Call Service to create a new task
            // Interpret new task isnt null (error creating task)
            // Return 201 + Location header -> /api/task/{id}
        }

        // PATCH /api/task/{id}
        // TODO:
        // Patch request receiving an id as an input
        // method that returns a TaskItem (for validation) and accepts string id from route
        // Validate request isnt null or empty
        // call service to update task
        // Interpret updated task isnt null (not found)
        // return valid response 

        // DELETE /api/task/{id}
        // TODO:
        // Build a DELETE endpoint to delete one TaskItem
        // HINTS: 
        // Deleting will return nothing
        // Therefore return type would be IActionResult
        // (What method type should we return? HINT: Status 204)
    }
}