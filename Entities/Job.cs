using System.ComponentModel.DataAnnotations;

namespace jobPortal.Entities
{
    public class Job
    {
        [Key]
        public int jobId { get; set; }

        [Required]
        // [DataType(DataType.Date)]
        public String postDate { get; set; }

        [Required]
        [StringLength(50)]
        public string jobTitle { get; set; }

        [Required]
        [StringLength(100)]
        public string jobLocat { get; set; }

        [Required]
        [StringLength(1000)]
        public string jobDescription { get; set; }
    }
}