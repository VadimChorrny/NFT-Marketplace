using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimationController : ControllerBase
    {
        private readonly IAnimationService _service;
        public AnimationController(IAnimationService animationService)
        {
            _service = animationService;
        }
        [HttpGet]
        public async Task<IEnumerable<AnimationDTO>> Get()
        {
            return await _service.Get();
        }
    }
}
