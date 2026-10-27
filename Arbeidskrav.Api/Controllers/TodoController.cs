using Arbeidskrav_cloud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arbeidskrav_cloud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : Controller
    {
        private readonly TodoContext context;

        public TodoController(TodoContext context) 
        {
            this.context = context;
        }

        [HttpPost("NewTask")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public IActionResult AddTask (TodoTask task)
        {
            try
            {
                context.TodoTasks.Add(task);
                context.SaveChanges();
                return Created();
            }
            catch (Exception ex) 
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpGet("Todolist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public IActionResult GetTaskList(string? taskname = null, bool? iscomplete = null)
        {
            var tasks = context.TodoTasks;

            try
            {
                IQueryable<TodoTask> filtered = tasks;
                if (taskname != null)
                {
                    filtered = filtered.Where(x => x.TaskName == taskname);
                }

                if (iscomplete.HasValue)
                {
                    filtered = filtered.Where(x => x.IsComplete == iscomplete.Value);
                }

                // Vurder logikk her, ekstra kall?
                var count = filtered.Count();

                if (count == 0)
                {
                    return NotFound($"No results found with parameters given: {taskname}, {iscomplete}");
                }

                return Ok(filtered.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest("something went wrong");
            }
        }
    }
}
