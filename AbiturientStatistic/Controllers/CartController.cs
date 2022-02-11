using DAL.Entity;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IEnumerable<Cart> Get()
        {
            return _unitOfWork.CartRepository.Get().ToList();
        }
        [HttpPost]
        public ActionResult Create(Cart cart)
        {
            if (cart == null) return BadRequest();

            _unitOfWork.CartRepository.Insert(cart);
            _unitOfWork.Save();

            return Ok("Successfully created new cart!");
        }

        [HttpPut]
        public ActionResult Edit(Cart cart)
        {
            if(cart == null) return BadRequest();

            _unitOfWork.CartRepository.Update(cart);
            _unitOfWork.Save();

            return Ok("Successfully updated selected cart!");
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var cartToRemove = _unitOfWork.CartRepository.GetById(id);

            if(cartToRemove == null) return BadRequest();

            _unitOfWork.CartRepository.Delete(cartToRemove);
            _unitOfWork.Save();

            return Ok("Successfully deleted selected cart");
        }
    }
}
