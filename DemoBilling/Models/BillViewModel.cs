namespace DemoBilling.Models
{
    public class BillViewModel
    {
        public int BillId { get; set; }
        public string CustomerName { get; set; }
        public List<Product> Products { get; set; }
        public List<int> Quantities { get; set; }
        public decimal Total { get; set; }
    }
}
