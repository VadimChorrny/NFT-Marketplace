using BLL.Interfaces;
using DAL.Entity;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async void Create(Cart cart)
        {
            await _unitOfWork.CartRepository.Insert(cart);
            _unitOfWork.Save();
        }

        public async void Delete(int id)
        {
            var cart = _unitOfWork.CartRepository.GetById(id);
            if(cart != null)
                await _unitOfWork.CartRepository.Delete(cart);
            _unitOfWork.Save();
        }

        public void Edit(Cart cart)
        {
            _unitOfWork.CartRepository.Update(cart);
            _unitOfWork.Save();
        }

        public async Task<IEnumerable<Cart>> Get()
        {
            return await _unitOfWork.CartRepository.Get();
        }

        public async Task<Cart> GetCartByIdAsync(int id)
        {
            var cart = _unitOfWork.CartRepository.GetById(id);
            if(cart == null) return null;
            return await cart;
        }
    }
}
