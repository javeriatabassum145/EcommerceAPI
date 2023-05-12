using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EcommerceCRUDAPI.Models
{
    public class Brands
    {
        public int ID { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Category { get; set; }

        [MaxLength(1,ErrorMessage = "Length should be 1"),DisplayName("Active")]
        public int IsActive { get; set; }

    }
}
