using System.ComponentModel.DataAnnotations;

namespace DemoBilling
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
    }
}
