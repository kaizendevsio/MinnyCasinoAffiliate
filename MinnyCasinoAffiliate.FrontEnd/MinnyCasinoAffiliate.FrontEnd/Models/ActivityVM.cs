using System;

namespace MinnyCasinoAffiliate.FrontEnd.Models
{
    public class ActivityVM : UserVM
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
