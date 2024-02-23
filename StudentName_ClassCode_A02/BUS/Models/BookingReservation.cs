using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Models
{
    public class BookingReservation
    {
        [Key]
        public int ReservationID { get; set; }

        [Required]
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        [Required]
        public int RoomID { get; set; }
        [ForeignKey("RoomID")]
        public virtual RoomInformation Room { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal ActualPrice { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
