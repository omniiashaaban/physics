using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.DAL.Models.Entities
{
    public class AlertRecipient
    {

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int AlertId { get; set; } // لازم يتحدد
        public Alert Alert { get; set; }
    }
}
