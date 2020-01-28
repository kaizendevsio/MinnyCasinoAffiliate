using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using MinnyCasinoAffiliate.Entities.DTO;

namespace MinnyCasinoAffiliate.Wrapper.Models
{
   public class SessionBO
    {
        public TblUserInfo UserInfo { get; set; }
        public CookieCollection SessionCookies { get; set; }
    }
}
