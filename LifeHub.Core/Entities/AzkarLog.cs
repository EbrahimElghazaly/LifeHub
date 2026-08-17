using System;

namespace LifeHub.Core.Entities
{
    public class AzkarLog
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string AzkarName { get; set; } = string.Empty;
        public int Count { get; set; } = 1;
        public DateTime LogDate { get; set; } = DateTime.UtcNow;
        
        public virtual AppUser User { get; set; } = null!;
    }
}