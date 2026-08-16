using System;

namespace LifeHub.Core.Entities
{
    public class HabitLog
    {
        public Guid Id { get; set; }
        public Guid HabitId { get; set; }
        public DateTime LogDate { get; set; } = DateTime.UtcNow;
        public int Count { get; set; } = 1;
        public string? Note { get; set; }
        
        // Navigation
        public virtual Habit Habit { get; set; } = null!;
    }
}