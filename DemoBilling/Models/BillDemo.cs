namespace DemoBilling.Models
{
    public class BillDemo
    {
        //private readonly ProductPurchaseDbContext _purchaseContext;
        //private readonly PurchaseModel _purchaseModel;
        //private readonly CustomerModel _customerModel;
        //public BillDemo(ProductPurchaseDbContext purchaseContext, string name, List<int> productIds, List<int> quantities)
        //{
        //    _purchaseContext = purchaseContext;
        //    Name = name;
        //    ProductIds = productIds;
        //    Quantities = quantities;
            
        //}

        public string Name { get; set; }
        public List<int> ProductIds { get; set; }
        public List<int> Quantities { get; set; }

    }

   
}
