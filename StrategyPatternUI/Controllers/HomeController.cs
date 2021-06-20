using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Models;
using StrategyPattern.Services.Abstract;
using StrategyPattern.Services.Concrete;
using System.Collections.Generic;

namespace StrategyPattern.Controllers
{
    public class HomeController : Controller
    {
        private IShipping _shipping;
        public HomeController(IShipping shipping) => _shipping = shipping;

        public IActionResult Index() => View(GetOrder());

        [HttpPost]
        public IActionResult Index(Checkout checkout)
        {
            checkout.Shipping = GetShippings();

            switch (checkout.SelectedMethod)
            {
                case 1:
                    _shipping.SetStrategy(new FreeShippingStrategy());
                    break;
                case 2:
                    _shipping.SetStrategy(new LocalShippingStrategy());
                    break;
                case 3:
                    _shipping.SetStrategy(new WorldwideShippingStrategy());
                    break;
            }

            checkout.FinalTotal = _shipping.ExecuteStrategy(checkout.OrderTotal);

            return View(checkout);
        }

        private Checkout GetOrder() => new Checkout()
        {
            OrderTotal = 200.00m,
            Shipping = GetShippings()
        };

        private List<Shipping> GetShippings() => new List<Shipping>()
            {
                new Shipping()
                {
                    Id = 1,
                    Name="Free Shipping ($0.00)"
                },
                new Shipping() {
                    Id = 2,
                    Name="Local Shipping (10.00)"
                },
                new Shipping() {
                    Id = 3,
                    Name="Worldwide Shipping (20.00)"
                }
            };
    }
}
