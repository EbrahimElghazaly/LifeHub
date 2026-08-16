using System;

namespace LifeHub.Core.Entities
{
    public class QuranProgress
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int CurrentJuz { get; set; } = 1;
        public int CurrentPage { get; set; } = 1;
        public int TotalPagesRead { get; set; } = 0;
        public DateTime LastReadAt { get; set; } = DateTime.UtcNow;
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation
        public virtual User User { get; set; } = null!;
    }
}