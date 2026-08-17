using System;

namespace LifeHub.Core.Entities
{
    public class JournalEntry
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? Mood { get; set; }
        public DateTime EntryDate { get; set; } = DateTime.UtcNow;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        
        // Foreign Keys
        public string UserId { get; set; } = string.Empty;
        
        // Navigation
        public virtual AppUser User { get; set; } = null!;
    }
}