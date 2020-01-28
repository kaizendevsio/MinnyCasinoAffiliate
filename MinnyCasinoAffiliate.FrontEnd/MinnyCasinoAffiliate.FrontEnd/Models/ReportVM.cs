using System;

namespace MinnyCasinoAffiliate.FrontEnd.Models
{
    public class ReportVM
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
