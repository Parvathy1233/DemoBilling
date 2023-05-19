namespace DemoBilling.Models { 
public class CustomerModel
{ 
    private readonly ProductPurchaseDbContext _purchaseContext;

    public CustomerModel(ProductPurchaseDbContext purchaseContext)
    {
        _purchaseContext = purchaseContext;
    }
    public Customer GetOrCreateCustomer(string name)
    {
        var customer = _purchaseContext.customers.FirstOrDefault(c => c.Name == name);

        if (customer == null)
        {
            customer = new Customer { Name = name };
            _purchaseContext.customers.Add(customer);
            _purchaseContext.SaveChanges();
        }
        return customer;
    }
}
}


