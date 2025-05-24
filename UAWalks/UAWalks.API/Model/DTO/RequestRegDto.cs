using System.ComponentModel.DataAnnotations;

namespace UAWalks.API.Model.DTO
{
    public class RequestRegDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string[] Roles { get; set; }

    }
}
