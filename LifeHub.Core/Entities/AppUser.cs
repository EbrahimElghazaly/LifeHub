using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace LifeHub.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastActiveAt { get; set; }
        public string? PreferredLanguage { get; set; } = "ar";
        public bool IsDarkMode { get; set; } = false;
        
        // Navigation Properties
        public virtual ICollection<Task>? Tasks { get; set; }
        public virtual ICollection<Goal>? Goals { get; set; }
        public virtual ICollection<Habit>? Habits { get; set; }
        public virtual ICollection<JournalEntry>? JournalEntries { get; set; }
        public virtual ICollection<Note>? Notes { get; set; }
        public virtual ICollection<StudySession>? StudySessions { get; set; }
        public virtual ICollection<QuranProgress>? QuranProgress { get; set; }
        public virtual ICollection<AzkarLog>? AzkarLogs { get; set; }
    }
}