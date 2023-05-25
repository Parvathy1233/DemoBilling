namespace DemoBilling.Models
{
    public class BillViewModel
    {
        public int BillId { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public double NetTotal { get; set; }
        public List<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
