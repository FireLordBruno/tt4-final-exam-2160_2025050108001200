using Microsoft.EntityFrameworkCore;
using FitnessTrackerAPI.Models;

namespace FitnessTrackerAPI.Data
{
    public class FitnessContext : DbContext
    {
        public FitnessContext(DbContextOptions<FitnessContext> options) : base(options) { }

        public DbSet<Workout> Workouts { get; set; }
    }
}