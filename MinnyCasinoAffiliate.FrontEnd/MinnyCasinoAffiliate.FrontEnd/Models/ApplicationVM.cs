using System;
using System.Collections.Generic;

namespace MinnyCasinoAffiliate.FrontEnd.Models
{
    public class ApplicationVM
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }
        public string Passsword { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string CompanyName { get; set; }
        public string WebURL { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Contact { get; set; }
        public List<byte[]> FileByte { get; set; }

        public List<string> FileName { get; set; }
  


    }
}
