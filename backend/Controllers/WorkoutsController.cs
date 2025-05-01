using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessTrackerAPI.Models;
using FitnessTrackerAPI.Data;

namespace FitnessTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutsController : ControllerBase
    {
        private readonly FitnessContext _context;

        public WorkoutsController(FitnessContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> Get() =>
            await _context.Workouts.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Workout>> Get(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null) return NotFound();
            return workout;
        }

        [HttpPost]
        public async Task<ActionResult<Workout>> Post(Workout workout)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = workout.ID }, workout);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Workout workout)
        {
            if (id != workout.ID) return BadRequest();
            _context.Entry(workout).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null) return NotFound();
            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
