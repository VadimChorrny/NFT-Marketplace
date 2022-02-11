using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Animation
    {

        public int AnimationId { get; set; }
        [Required]
        public string Image { get; set; }
        [ForeignKey("Cart")]
        public int? CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
