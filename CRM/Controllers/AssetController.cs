using CRM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class AssetController : Controller
    {
        private readonly ICrmRepository _repository;

        public AssetController(ICrmRepository repository)
        {
            this._repository = repository;
        }


        [HttpGet]
        [Route("/Asset/BuyNew/{customerId}")]
        public IActionResult BuyNew(long customerId)
        {
            // for later to map data and maybe check eligibility
            var customer = _repository.Customers
                .Where(x => x.Id == customerId)
                .Select(x => x);

            var assets = _repository.Assets
                .GetAllAsync()
                .Result
                .ToDictionary(x => x.Id, x => x.Name);

            return View(assets);
        }
    }
}
