using System;
using System.ComponentModel.DataAnnotations;

namespace MinnyCasinoAffiliate.FrontEnd.Models
{
    public class LogInVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PasswordString { get; set; }
    }
}
