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
    public class BlogService : IBlogService
    {
        private readonly IRepository<Blog> _blogRepository;
        private readonly IMapper _mapper;
        public BlogService(IRepository<Blog> repository, IMapper mapper)
        {
            _blogRepository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(BlogDTO blog)
        {
            if (blog == null) throw new HttpException($"Error with create blog!", HttpStatusCode.NotFound);
            await _blogRepository.Insert(_mapper.Map<Blog>(blog));
            await _blogRepository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadRequest);
            var blog = _blogRepository.GetById(id);
            if (blog != null)
                await _blogRepository.Delete(blog);
            await _blogRepository.SaveChangesAsync();
        }
        public void Edit(BlogDTO blog)
        {
            if (blog == null) throw new HttpException($"Error with edit blog!", HttpStatusCode.NotFound);
            _blogRepository.Update(_mapper.Map<Blog>(blog));
            _blogRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<BlogDTO>> Get()
        {
            return _mapper.Map<IEnumerable<BlogDTO>>(await _blogRepository.Get());
        }
        public async Task<BlogDTO> GetBlogByIdAsync(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadRequest);
            var blog = _blogRepository.GetById(id);
            if (blog == null) throw new HttpException($"Cart Not Found!", HttpStatusCode.NotFound);
            return _mapper.Map<BlogDTO>(await blog);
        }
        public async Task<IEnumerable<BlogPreviewDTO>> GetBlogByTitle()
        {
            return _mapper.Map<IEnumerable<BlogPreviewDTO>>(await _blogRepository.Get());
        }
    }
}
