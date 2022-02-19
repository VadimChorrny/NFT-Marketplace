using AutoMapper;
using BLL.DTOs;
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
        private readonly IMapper _mapper;
        public CartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async void Create(CartDTO cart)
        {
            if(cart == null) throw new HttpException($"Error with create cart!", HttpStatusCode.NotFound);
             await _unitOfWork.CartRepository.Insert(_mapper.Map<Cart>(cart));
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

        public void Edit(CartDTO cart)
        {
            if (cart == null) throw new HttpException($"Error with edit cart!", HttpStatusCode.NotFound);
            _unitOfWork.CartRepository.Update(_mapper.Map<Cart>(cart));
            _unitOfWork.Save();
        }

        public async Task<IEnumerable<CartDTO>> Get()
        {
            return _mapper.Map<IEnumerable<CartDTO>>( await _unitOfWork.CartRepository.Get());
        }

        public async Task<CartDTO> GetCartByIdAsync(int id)
        {
            if(id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadRequest);
            var cart = _unitOfWork.CartRepository.GetById(id);
            if(cart == null) throw new HttpException($"Cart Not Found!", HttpStatusCode.NotFound);
            return _mapper.Map<CartDTO>(await cart);
        }
    }
}
