using System;

namespace LifeHub.Core.Entities
{
    public class AzkarItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string? Translation { get; set; }
        public string? Category { get; set; }
        public int RecommendedCount { get; set; } = 1;
        public string? Source { get; set; }
    }
}
