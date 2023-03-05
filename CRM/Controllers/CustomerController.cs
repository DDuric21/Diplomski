using CRM.DbContext;
using CRM.Models;
using CRM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICrmRepository _repository;

        public CustomerController(ICrmRepository crmRepository)
        {
            _repository = crmRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/Customer/{id}")]
        public IActionResult Index(int id)
        {
            var customer = _repository.Customers.GetByIdAsync(id).Result;
            var customerAsetIDs = _repository.CustomerAssets
                .GetByCustomerIdAsync(id)
                .Result
                .Select(x => x.AssetID)
                .ToList();
            customer.Assets = new List<Asset>();

            foreach (var customerAsetID in customerAsetIDs)
            {
                customer.Assets.Add(
                    _repository.Assets
                    .GetByIdAsync(customerAsetID)
                    .Result);
            }

            return View(customer);
        }
    }
}
