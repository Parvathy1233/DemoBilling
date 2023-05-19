namespace DemoBilling.Models
{
    public class BillModel
    {
        private readonly ProductPurchaseDbContext _purchaseContext;

        public BillModel(ProductPurchaseDbContext purchaseContext)
        {
            _purchaseContext = purchaseContext;
        }

        public Bill CreateBill(Customer customer)
        {
            var bill = new Bill
            {
                Date = DateTime.Now,
                UserId = customer.Id,
                Total = 0
            };

            _purchaseContext.bills.Add(bill);
            _purchaseContext.SaveChanges();

            return bill;
        }
    }
}
