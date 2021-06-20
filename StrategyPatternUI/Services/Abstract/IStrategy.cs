namespace StrategyPattern.Services.Abstract
{
    public interface IStrategy
    {
        decimal CalculateFinalTotal(decimal orderTotal);
    }
}
