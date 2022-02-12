using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<Cart>> Get();
        Task<Cart> GetCartByIdAsync(int id);
        void Create(Cart cart);
        void Edit(Cart cart);
        void Delete(int id);
    }
}
