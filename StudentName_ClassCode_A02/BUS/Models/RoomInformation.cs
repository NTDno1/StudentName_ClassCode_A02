using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Models
{
    public class RoomInformation
    {
        [Key]
        public int RoomID { get; set; }

        [Required]
        public string RoomName { get; set; }

        public int RoomCapacity { get; set; }

        public string RoomDescription { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int RoomTypeID { get; set; }
        [ForeignKey("RoomTypeID")]
        public virtual RoomType RoomType { get; set; }

        [Required]
        public decimal BookingPrice { get; set; }

        [Required]
        public string Status { get; set; }

        public virtual ICollection<BookingReservation> BookingReservations { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

    }
}
