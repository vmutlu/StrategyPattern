using StrategyPattern.Services.Abstract;

namespace StrategyPattern.Services.Concrete
{
    public class LocalShippingStrategy : IStrategy
    {
        public decimal CalculateFinalTotal(decimal orderTotal) =>  orderTotal + 10;
    }
}
