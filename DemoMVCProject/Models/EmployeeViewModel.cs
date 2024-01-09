using System.ComponentModel.DataAnnotations;

namespace DemoMVCProject.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int empid { get; set; }
        [Required]
        public string empname { get; set; }
        [Required]

        public string designation { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "should be greater or equal to 1")]

        public int grossal { get; set; }

        [Required]

        [Range(1, int.MaxValue,ErrorMessage ="should be greater or equal to 1")]
        public int deducts { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "should be greater or equal to 1")]

        public int netsal { get; set; }
        [Required]
    
        public string? isactive { get; set; }
    }
}
