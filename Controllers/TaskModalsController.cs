using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrelloTestApi.Data;
using TrelloTestApi.Modal;

namespace TrelloTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskModalsController : ControllerBase
    {
        private readonly TaskDataContext _context;

        public TaskModalsController(TaskDataContext context)
        {
            _context = context;
        }

        // GET: api/TaskModals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModal>>> Gettaskdb()
        {
            return await _context.taskdb.ToListAsync();
        }

        // GET: api/TaskModals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModal>> GetTaskModal(int id)
        {
            var taskModal = await _context.taskdb.FindAsync(id);

            if (taskModal == null)
            {
                return NotFound();
            }

            return taskModal;
        }

        // PUT: api/TaskModals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskModal(int id, TaskModal taskModal)
        {
            if (id != taskModal.TaskId)
            {
                return BadRequest();
            }

            _context.Entry(taskModal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskModalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TaskModals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskModal>> PostTaskModal(TaskModal taskModal)
        {
            _context.taskdb.Add(taskModal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskModal", new { id = taskModal.TaskId }, taskModal);
        }

        // DELETE: api/TaskModals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskModal(int id)
        {
            var taskModal = await _context.taskdb.FindAsync(id);
            if (taskModal == null)
            {
                return NotFound();
            }

            _context.taskdb.Remove(taskModal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskModalExists(int id)
        {
            return _context.taskdb.Any(e => e.TaskId == id);
        }
    }
}
