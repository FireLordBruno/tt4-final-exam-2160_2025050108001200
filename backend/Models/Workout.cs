namespace FitnessTrackerAPI.Models
{
    public class Workout
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public required string Type { get; set; }
        public int Duration { get; set; } // in minutes
        public int CaloriesBurned { get; set; }
    }
}