using System;

namespace MinnyCasinoAffiliate.FrontEnd.Models
{
    public class AgentVM
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
