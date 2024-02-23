using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string Mobile { get; set; }

        public DateTime Birthday { get; set; }

        public string IdentityCard { get; set; }

        public string LicenceNumber { get; set; }

        public DateTime LicenceDate { get; set; }

        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<BookingReservation> BookingReservations { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
