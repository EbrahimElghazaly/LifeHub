using System;
using System.Collections.Generic;

namespace LifeHub.Core.Entities
{
    public class LearningPath
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Foreign Keys
        public string UserId { get; set; } = string.Empty;
        
        // Navigation
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Course>? Courses { get; set; }
    }
}