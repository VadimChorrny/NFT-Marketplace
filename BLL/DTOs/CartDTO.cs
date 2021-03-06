using DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CartDTO
    {
        [Key]
        public int CartId { get; set; }
        [Required(ErrorMessage = "You must enter a title")]
        public string Title { get; set; }
        public string CreateDate { get; set; } = DateTime.Now.ToString(); // IN FUTURE NEED CHANGE
        [Range(0, (double.MaxValue))]
        public decimal? Price { get; set; }

        // ANIMATION
        public List<AnimationDTO> Animations { get; set; }

        // CATEGORY
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        // COLLECTION
        public int? CollectionId { get; set; }
        public Collection Collection { get; set; }

    }
}
