using AutoMapper;
using Core.DTOs;
using Core.Exceptions;
using Core.Interfaces;
using Core.Entity;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IMapper _mapper;
        public CartService(IRepository<Cart> cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }
        public async void Create(CartDTO cart)
        {
            if(cart == null) throw new HttpException($"Error with create cart!", HttpStatusCode.NotFound);
            await _cartRepository.Insert(_mapper.Map<Cart>(cart));
            await _cartRepository.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadRequest);
            var cart = _cartRepository.GetById(id);
            if(cart != null)
                await _cartRepository.Delete(cart);
            await _cartRepository.SaveChangesAsync();
        }

        public async void Edit(CartDTO cart)
        {
            if (cart == null) throw new HttpException($"Error with edit cart!", HttpStatusCode.NotFound);
            _cartRepository.Update(_mapper.Map<Cart>(cart));
            await _cartRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CartDTO>> Get()
        {
            return _mapper.Map<IEnumerable<CartDTO>>( await _cartRepository.Get());
        }

        public async Task<CartDTO> GetCartByIdAsync(int id)
        {
            if(id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadRequest);
            var cart = _cartRepository.GetById(id);
            if(cart == null) throw new HttpException($"Cart Not Found!", HttpStatusCode.NotFound);
            return _mapper.Map<CartDTO>(await cart);
        }
    }
}
