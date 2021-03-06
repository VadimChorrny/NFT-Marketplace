using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService service)
        {
            _blogService = service;
        }
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public async Task<IEnumerable<BlogDTO>> Get()
        {
            return await _blogService.Get();
        }
        //[HttpGet]
        //public async Task<IEnumerable<BlogPreviewDTO>> GetBlogByTitle()
        //{
        //    return await _blogService.GetBlogByTitle();
        //}
    }
}
