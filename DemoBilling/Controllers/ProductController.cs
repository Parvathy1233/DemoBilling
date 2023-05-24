using DemoBilling.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoBilling.Controllers
{
    public class ProductController : Controller
    {
        private readonly CustomerModel _customerModel;
        private readonly BillModel _billModel;
        private readonly BillDisplay _billDisplay;
        private readonly PurchaseModel _purchaseModel;
        private readonly ProductPurchaseDbContext _purchaseContext;
        private readonly ProductModel _productModel;

        public ProductController(ProductPurchaseDbContext purchaseDbContext, BillDisplay billDisplay)
        {
            _customerModel = new CustomerModel(purchaseDbContext);
            _billModel = new BillModel(purchaseDbContext);
            _purchaseModel = new PurchaseModel(purchaseDbContext);
            _purchaseContext = purchaseDbContext;
            _billDisplay = billDisplay;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Bill()
        {
            ViewBag.Customers = _purchaseContext.customers.ToList();
            ViewBag.Products = _purchaseContext.Products.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Bill(string name, List<int> productIds, List<int> quantities)
        {
            var customer = _customerModel.GetOrCreateCustomer(name);
            var bill = _billModel.CreateBill(customer);

            for (int i = 0; i < productIds.Count; i++)
            {
                var product = _purchaseContext.Products.FirstOrDefault(p => p.Id == productIds[i]);
                var quantity = quantities[i];

                var productTotal = _purchaseModel.CalculateProductTotal(product, quantity);
                bill.Total += productTotal;
                _purchaseModel.AddPurchaseDetails(bill, product.Id, quantity);
            }
            _purchaseContext.SaveChanges();
            return RedirectToAction("Save");
            return View();
        }
        public IActionResult Save()
        {
            return View();
        } 
        public IActionResult ShowBill(int billId)
        {
           var bill=_billModel.GetBillById(billId);
            if (bill == null)
            {
                return RedirectToAction("BillNotFound");
            }
            if (billId==0 || billId != bill.Id )
            {
                return RedirectToAction("BillNotFound");
            }
            var purchaseDetails=_purchaseModel.GetPurchaseDetailsByBillId(billId);
            var customer=_customerModel.GetCustomerById(bill.UserId);

            foreach (var purchaseDetail in purchaseDetails)
            {
                purchaseDetail.product = _purchaseContext.Products.FirstOrDefault(p => p.Id == purchaseDetail.ProductId);
            }
            double netTotal = purchaseDetails.Sum(p => p.Quantity * p.product.Price);
            var billViewModel = new BillViewModel
            {
                BillId = bill.Id,
                Date = bill.Date,
                CustomerName = bill.Customer.Name,
                Total = bill.Total,
                PurchaseDetails = purchaseDetails,
                NetTotal = netTotal,
            };
            return View (billViewModel);
        } 
        public IActionResult BillNotFound()
        {
            return View();
        }
    }
}
