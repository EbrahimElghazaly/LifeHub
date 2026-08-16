using System;
using System.Collections.Generic;
using LifeHub.Core.Enums;

namespace LifeHub.Core.Entities
{
    public class Habit
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public HabitFrequency Frequency { get; set; } = HabitFrequency.Daily;
        public int TargetCount { get; set; } = 1;
        public int CurrentStreak { get; set; } = 0;
        public int BestStreak { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Foreign Keys
        public string UserId { get; set; } = string.Empty;
        
        // Navigation
        public virtual User User { get; set; } = null!;
        public virtual ICollection<HabitLog>? Logs { get; set; }
    }
}