using StrategyPattern.Services.Abstract;

namespace StrategyPattern.Services.Concrete
{
    public class WorldwideShippingStrategy : IStrategy
    {
        public decimal CalculateFinalTotal(decimal orderTotal) => orderTotal + 20;
    }
}
