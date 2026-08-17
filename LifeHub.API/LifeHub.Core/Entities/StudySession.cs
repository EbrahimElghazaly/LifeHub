using System;

namespace LifeHub.Core.Entities
{
    public class StudySession
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int DurationMinutes { get; set; }
        public int? FocusScore { get; set; }
        public string? Subject { get; set; }
        public string? Tags { get; set; }
        
        // Foreign Keys
        public string UserId { get; set; } = string.Empty;
        public Guid? CourseId { get; set; }
        
        // Navigation
        public virtual AppUser User { get; set; } = null!;
        public virtual Course? Course { get; set; }
    }
}