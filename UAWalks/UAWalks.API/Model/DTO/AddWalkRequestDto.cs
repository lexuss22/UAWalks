using UAWalks.API.Model.Domain;

namespace UAWalks.API.Model.DTO
{
    public class AddWalkRequestDto
    {
        public string Name { get; set; }
        public double Length { get; set; }

        public Guid? RegionId { get; set; }
        public Guid? DifficultyId { get; set; }

    }
}
