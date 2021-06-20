using StrategyPattern.Services.Abstract;

namespace StrategyPattern.Services.Concrete
{
    public class FreeShippingStrategy : IStrategy
    {
        public decimal CalculateFinalTotal(decimal orderTotal) => orderTotal;
    }
}
