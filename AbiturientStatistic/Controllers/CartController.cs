using BLL.Interfaces;
using DAL.Entity;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet]
        public async Task<IEnumerable<Cart>> Get()
        {
            return await _cartService.Get();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cart>> Get(int id)
        {
            return await _cartService.GetCartByIdAsync(id);
        }
        [HttpPost]
        public ActionResult Create(Cart cart)
        {
            if (cart == null) return BadRequest();

            _cartService.Create(cart);

            return Ok("Successfully created new cart!");
        }

        [HttpPut]
        public ActionResult Edit(Cart cart)
        {
            if(cart == null) return BadRequest();

            _cartService.Edit(cart);

            return Ok("Successfully updated selected cart!");
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            if(id == 0) return BadRequest();

            _cartService.Delete(id);

            return Ok("Successfully deleted selected cart");
        }
    }
}
