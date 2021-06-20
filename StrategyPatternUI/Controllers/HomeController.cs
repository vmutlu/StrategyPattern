using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Models;
using StrategyPattern.Services.Abstract;
using StrategyPattern.Services.Concrete;
using StrategyPatternUI.Enums;
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
                case (int)ESelectedMethod.FreeShippingStrategy:
                    _shipping.SetStrategy(new FreeShippingStrategy());
                    break;
                case (int)ESelectedMethod.LocalShippingStrategy:
                    _shipping.SetStrategy(new LocalShippingStrategy());
                    break;
                case (int)ESelectedMethod.WorldwideShippingStrategy:
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
                    Id = (int)ESelectedMethod.FreeShippingStrategy,
                    Name="Free Shipping (₺0.00)"
                },
                new Shipping() {
                    Id = (int)ESelectedMethod.LocalShippingStrategy,
                    Name="Local Shipping (₺10.00)"
                },
                new Shipping() {
                    Id = (int)ESelectedMethod.WorldwideShippingStrategy,
                    Name="Worldwide Shipping (₺20.00)"
                }
            };
    }
}
