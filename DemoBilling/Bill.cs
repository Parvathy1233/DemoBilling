using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoBilling
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Customer Customer { get; set; }
        public double Total { get; set; }

    }
}
