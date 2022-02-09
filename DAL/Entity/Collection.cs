using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; } // NEED CALCULATE COUNT COLLECTION (.Count())
        public virtual ICollection<Cart> Carts { get;}
    }
}
