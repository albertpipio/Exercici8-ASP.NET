using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorEmpleats.Models
{
    public class EmpleatInfo
    {
        public int ID { get; set; }

        [Display(Name = "Your name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Display(Name = "Your surname")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(30)]
        public string Surname { get; set; }

        [Display(Name = "Your position")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(30)]
        public string Position { get; set; }

        [Display(Name = "Your salary")]
        [Column(TypeName = "decimal(18, 2)")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
    }
}