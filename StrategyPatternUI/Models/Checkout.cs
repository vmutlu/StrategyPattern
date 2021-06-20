using System.Collections.Generic;

namespace StrategyPattern.Models
{
    public class Checkout
    {
        public int SelectedMethod { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal FinalTotal { get; set; }
        public List<Shipping> Shipping { get; set; }
    }
}
