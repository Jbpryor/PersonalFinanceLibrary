namespace PersonalFinanceLibrary.Models
{
    public class DashboardModel
    {
        public int Id { get; set; }
        public DateTime DateUpdated { get; set; }
        public decimal TotalBalance { get; set; }
        public decimal GasBalance { get; set; }
        public decimal GroceriesBalance { get; set; }
        public decimal BillsTotal { get; set; }
    }
}
