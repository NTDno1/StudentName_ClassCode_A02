﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.DTO
{
    public class CustomerDTO
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Mobile { get; set; }

        public DateTime Birthday { get; set; }

        public string IdentityCard { get; set; }

        public string LicenceNumber { get; set; }

        public DateTime LicenceDate { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
