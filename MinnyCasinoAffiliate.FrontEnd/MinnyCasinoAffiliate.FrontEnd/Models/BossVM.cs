using System;

namespace MinnyCasinoAffiliate.FrontEnd.Models
{
    public class BossVM
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
