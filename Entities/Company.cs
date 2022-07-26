global using System.ComponentModel.DataAnnotations;
namespace jobPortal.Entities
{
    public class Company
    {

        public int companyId { get; set; }
        [Required]
        [StringLength(30)]
        public string companyName { get; set; }
        [Required]
        public string? companyLogo { get; set; }
        [Required]
        [StringLength(1000)]
        public string companyDetails { get; set; }

    }
}

