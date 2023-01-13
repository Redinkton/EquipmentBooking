using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs
{
    //для брони DTO
    public record ServiceObjectBoDto
    {
        [Required]
        public Guid Id { get; init; }

        [Required]
        public int Amount { get; set; }
    }
}
