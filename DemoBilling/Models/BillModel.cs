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
        public Bill GetBillById(int billId)
        {
            return _purchaseContext.bills.FirstOrDefault(b => b.Id == billId);
            //var bill = GetBillById(billId);
            //if (bill == null)
            //{
            //    throw new Exception("BillId Not Found");
            //}
            ////if (billId == 0 || billId != bill.Id)
            ////{
            ////    throw new Exception("BillId Not Found");
            ////}
            //return bill;
           
           
            
        }

    }
}
