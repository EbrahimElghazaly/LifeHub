using System;
using System.Collections.Generic;

namespace LifeHub.Core.Entities
{
    public class TaskCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Icon { get; set; }
        public string? Color { get; set; }
        public string UserId { get; set; } = string.Empty;
        
        // Navigation
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Task>? Tasks { get; set; }
    }
}