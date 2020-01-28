using System;

namespace MinnyCasinoAffiliate.FrontEnd.Models
{
    public class DashboardVM : UserVM

    {
    public int TotalCustomer { get; set; }
        public int TotalHits { get; set; }
        public int TotalSignUps { get; set; }
        public int TotalFirstDeposit { get; set; }
        public int TotalIncome { get; set; }
    }
}
