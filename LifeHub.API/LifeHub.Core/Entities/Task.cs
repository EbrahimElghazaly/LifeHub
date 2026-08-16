using System;
using System.Collections.Generic;
using LifeHub.Core.Enums;

namespace LifeHub.Core.Entities
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TaskStatusEnum Status { get; set; } = TaskStatusEnum.Pending;  // تغيير الاسم
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
        public DateTime? DueDate { get; set; }
        public DateTime? ReminderDate { get; set; }
        public int? EstimatedMinutes { get; set; }
        public bool IsRecurring { get; set; } = false;
        public string? RecurrencePattern { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
        
        // Foreign Keys
        public string UserId { get; set; } = string.Empty;
        public Guid? CategoryId { get; set; }
        public Guid? ParentTaskId { get; set; }
        
        // Navigation Properties
        public virtual User User { get; set; } = null!;
        public virtual TaskCategory? Category { get; set; }
        public virtual Task? ParentTask { get; set; }
        public virtual ICollection<Task>? Subtasks { get; set; }
        public virtual ICollection<TaskReminder>? Reminders { get; set; }
    }
}