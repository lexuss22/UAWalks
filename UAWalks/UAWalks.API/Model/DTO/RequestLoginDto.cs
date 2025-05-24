using System.ComponentModel.DataAnnotations;

namespace UAWalks.API.Model.DTO
{
    public class RequestLoginDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}


