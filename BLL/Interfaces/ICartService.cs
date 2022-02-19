using BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<CartDTO>> Get();
        Task<CartDTO> GetCartByIdAsync(int id);
        void Create(CartDTO cart);
        void Edit(CartDTO cart);
        void Delete(int id);
    }
}
