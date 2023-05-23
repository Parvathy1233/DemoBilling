using DemoBilling.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoBilling.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly CustomerModel _customerModel;
        private readonly BillModel _billModel;
        private readonly PurchaseModel _purchaseModel;
        private readonly ProductPurchaseDbContext _purchaseContext;

        public HomeController(ProductPurchaseDbContext purchaseDbContext)
        {
            _customerModel = new CustomerModel(purchaseDbContext);
            _billModel = new BillModel(purchaseDbContext);
            _purchaseModel = new PurchaseModel(purchaseDbContext);
            _purchaseContext = purchaseDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
    }
}