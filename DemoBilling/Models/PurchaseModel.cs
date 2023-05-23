namespace DemoBilling.Models
{
    public class PurchaseModel
    {
        private readonly ProductPurchaseDbContext _purchaseContext;
        public PurchaseModel(ProductPurchaseDbContext purchaseContext)
        {
            _purchaseContext = purchaseContext;
        }
        public double CalculateProductTotal(Product product, int quantity)
        {
            return (double)(quantity * product.Price);
        }

        public void AddPurchaseDetails(Bill bill, int productId, int quantity)
        {
            _purchaseContext.purchaseDetails.Add(new PurchaseDetail
            {
                ProductId = productId,
                Quantity = quantity,
                BillId = bill.Id
            });
        }
        public List<PurchaseDetail> GetPurchaseDetailsByBillId(int billId)
        {
            return _purchaseContext.purchaseDetails.Where(p => p.BillId == billId).ToList();
        }
    }

}
