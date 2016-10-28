namespace CarsFactory.Models
{
    public class TotalRevenueByDealer
    {
        public string Dealer { get; set; }

        public string Town { get; set; }

        public decimal? TotalRevenue { get; set; }

        public int TotalOrders { get; set; }
    }
}
