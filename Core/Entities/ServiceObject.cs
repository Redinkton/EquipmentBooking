using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Справочник услуг и кол-ва оборудования
    public record ServiceObject
    {
        [Key]
        public Guid Id { get; init; }
        [StringLength(100, ErrorMessage = "The Service Name value cannot exceed 100 characters. ")]
        public string ServiceName { get; set; }
        public int Amount { get; set; }
        public bool? Ok { get; set; }
        public string? Error { get; set; }
    }
}
