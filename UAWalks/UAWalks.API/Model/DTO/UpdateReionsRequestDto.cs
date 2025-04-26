using System.ComponentModel.DataAnnotations;

namespace UAWalks.API.Model.DTO
{
    public class UpdateReionsRequestDto
    {
        [Required]
        [MaxLength(4, ErrorMessage = "Max lenght Code cannot more 4")]
        public string Code { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Max lenght Name cannot more 50")]
        public string Name { get; set; }
        public double? Area { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
        public long? Population { get; set; }
    }
}
