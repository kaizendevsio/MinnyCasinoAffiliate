﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MinnyCasinoAffiliate.Entities.BO
{
   public class WalletBO : BaseAuditBO
    {
        public string xPub{ get; set; }
        public string xPriv { get; set; }
        public string Address { get; set; }
    }
}
