namespace P_Finance.Core.Models
{
    public class DashboardModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalBalance { get; set; }
        public decimal GasBalance { get; set; }
        public decimal GroceriesBalance { get; set; }
        public decimal BillsTotal { get; set; }
    }
}
