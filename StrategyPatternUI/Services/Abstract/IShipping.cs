namespace StrategyPattern.Services.Abstract
{
    public interface IShipping
    {
        void SetStrategy(IStrategy strategy);

        decimal ExecuteStrategy(decimal orderTotal);
    }
}
