using System;

namespace LifeHub.Core.Entities
{
    public class GoalMilestone
    {
        public Guid Id { get; set; }
        public Guid GoalId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedAt { get; set; }
        public int Order { get; set; }
        
        // Navigation
        public virtual Goal Goal { get; set; } = null!;
    }
}