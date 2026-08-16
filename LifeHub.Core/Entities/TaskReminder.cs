using System;

namespace LifeHub.Core.Entities
{
    public class TaskReminder
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public DateTime ReminderTime { get; set; }
        public bool IsSent { get; set; } = false;
        public string? Message { get; set; }
        
        // Navigation
        public virtual Task Task { get; set; } = null!;
    }
}