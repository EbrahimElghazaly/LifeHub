using System;
using System.Collections.Generic;

namespace LifeHub.Core.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Instructor { get; set; }
        public int TotalHours { get; set; }
        public int CompletedHours { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public string UserId { get; set; } = string.Empty;
        public Guid? LearningPathId { get; set; }
        
        public virtual AppUser User { get; set; } = null!;
        public virtual LearningPath? LearningPath { get; set; }
        public virtual ICollection<StudySession>? StudySessions { get; set; }
    }
}