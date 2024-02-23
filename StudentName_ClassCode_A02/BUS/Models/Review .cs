using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        [Required]
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        [Required]
        public int RoomID { get; set; }
        [ForeignKey("RoomID")]
        public virtual RoomInformation Room { get; set; }

        [Required]
        public int ReviewStar { get; set; }

        public string Comment { get; set; }
    }
}
