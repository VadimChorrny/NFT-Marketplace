using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AnimationDTO
    {
        public int AnimationId { get; set; }
        public string Image { get; set; }
        public int? CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
