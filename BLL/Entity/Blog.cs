using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        [Required]
        public string Name { get; set;}
        public string Description { get; set;} = string.Empty;
        public string Type { get; set;} = string.Empty;
        [Required]
        public string Date { get; set; }
    }
}
