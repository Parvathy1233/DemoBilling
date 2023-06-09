﻿namespace DemoBilling.Models
{
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
        public int GetCustomerId(string customerName)
        {
            var customer = _purchaseContext.customers.FirstOrDefault(c => c.Name == customerName);

            if (customer == null)
            {
                customer = new Customer { Name = customerName };
                _purchaseContext.customers.Add(customer);
                _purchaseContext.SaveChanges();
            }
            return customer.Id;
        }
        public Customer GetCustomerById(int customerId)
        {
            return _purchaseContext.customers.FirstOrDefault(c => c.Id == customerId);
        }
    }
}


