using BLL.Exceptions;
using BLL.Interfaces;
using DAL.Entity;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            if(cart == null) throw new HttpException($"Error with create cart!", HttpStatusCode.NotFound);
            await _unitOfWork.CartRepository.Insert(cart);
            _unitOfWork.Save();
        }

        public async void Delete(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadRequest);
            var cart = _unitOfWork.CartRepository.GetById(id);
            if(cart != null)
                await _unitOfWork.CartRepository.Delete(cart);
            _unitOfWork.Save();
        }

        public void Edit(Cart cart)
        {
            if (cart == null) throw new HttpException($"Error with edit cart!", HttpStatusCode.NotFound);
            _unitOfWork.CartRepository.Update(cart);
            _unitOfWork.Save();
        }

        public async Task<IEnumerable<Cart>> Get()
        {
            return await _unitOfWork.CartRepository.Get();
        }

        public async Task<Cart> GetCartByIdAsync(int id)
        {
            if(id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadRequest);
            var cart = _unitOfWork.CartRepository.GetById(id);
            if(cart == null) throw new HttpException($"Cart Not Found!", HttpStatusCode.NotFound);
            return await cart;
        }
    }
}
