using StrategyPattern.Services.Abstract;

namespace StrategyPattern.Services.Concrete
{
    public class Shippings : IShipping
    {
        private IStrategy _strategy;
        public Shippings(IStrategy strategy) => _strategy = strategy;

        public decimal ExecuteStrategy(decimal orderTotal) => _strategy.CalculateFinalTotal(orderTotal);

        public void SetStrategy(IStrategy strategy) =>  _strategy = strategy;
    }
}
