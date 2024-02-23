using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Models
{
    public class RoomType
    {
        [Key]
        public int RoomTypeID { get; set; }

        [Required]
        public string RoomTypeName { get; set; }

        public string RoomDescription { get; set; }

        public virtual ICollection<RoomInformation> RoomInformations { get; set; }
    }
}
