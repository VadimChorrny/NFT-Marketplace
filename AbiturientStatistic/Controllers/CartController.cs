using Core.DTOs;
using Core.Interfaces;
using Core.Entity;
using Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public readonly ICartService _cartService;
        public readonly ILogger<CartController> _logger;
        public CartController(ICartService cartService, ILogger<CartController> logger)
        {
            _cartService = cartService;
            _logger = logger;
        }
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public async Task<IEnumerable<CartDTO>> Get()
        {
            return await _cartService.Get();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CartDTO>> Get(int id)
        {
            _logger.LogInformation($"Got a cart with id {id}");
            return await _cartService.GetCartByIdAsync(id);
        }
        [HttpPost]
        public ActionResult CreateCart(CartDTO cart)
        {
            if (cart == null) return BadRequest();

            _cartService.Create(cart);

            _logger.LogInformation($"Was created new cart!");

            return Ok("Successfully created new cart!");
        }
        [HttpPut]
        public ActionResult Edit(CartDTO cart)
        {
            if(cart == null) return BadRequest();

            _cartService.Edit(cart);

            _logger.LogInformation($"Was edited cart!");

            return Ok("Successfully updated selected cart!");
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            if(id == 0) return BadRequest();

            _cartService.Delete(id);

            _logger.LogInformation($"Was delited cart!");

            return Ok("Successfully deleted selected cart");
        }
    }
}
