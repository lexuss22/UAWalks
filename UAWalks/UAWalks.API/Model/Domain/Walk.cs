﻿namespace UAWalks.API.Model.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }

        public Guid RegionId { get; set; }
        public Guid DifficultyId { get; set; }

        // Navigation properties
        public Region Region { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
