using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoBilling
{
    public class PurchaseDetail
    {
        [Key]
        public int Id { get; set; }
        public int BillId { get; set; }
        [ForeignKey("BillId")]
        public Bill bill { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product product { get; set; }
        [Required(ErrorMessage = "Please enter value greater than 1")]
        public int Quantity { get; set; }
    }
}
