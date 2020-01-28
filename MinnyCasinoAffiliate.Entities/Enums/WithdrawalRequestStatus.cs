using System;
using System.Collections.Generic;
using System.Text;

namespace MinnyCasinoAffiliate.Entities.Enums
{
    public enum WithdrawalRequestStatus : byte
    {
        None = 0,
        Pending = 1,
        Completed = 2,
        Rejected = 10
    }

}
