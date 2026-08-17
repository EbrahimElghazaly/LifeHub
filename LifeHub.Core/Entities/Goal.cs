using System;
using System.Collections.Generic;
using LifeHub.Core.Enums;

namespace LifeHub.Core.Entities
{
    public class Goal
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public GoalType Type { get; set; } = GoalType.ShortTerm;
        public GoalStatus Status { get; set; } = GoalStatus.NotStarted;
        public DateTime? TargetDate { get; set; }
        public int ProgressPercentage { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
        
        public string UserId { get; set; } = string.Empty;
        
        public virtual AppUser User { get; set; } = null!;
        public virtual ICollection<GoalMilestone>? Milestones { get; set; }
    }
}