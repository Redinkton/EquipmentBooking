using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs
{
    //для Create/Update DTO
    public record ServiceObjectCrUpDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "The Service Name value cannot exceed 100 characters. ")]
        public string ServiceName { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
