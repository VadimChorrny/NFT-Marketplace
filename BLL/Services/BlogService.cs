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
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BlogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateAsync(BlogDTO blog)
        {
            if (blog == null) throw new HttpException($"Error with create blog!", HttpStatusCode.NotFound);
            await _unitOfWork.BlogRepository.Insert(_mapper.Map<Blog>(blog));
            _unitOfWork.Save();
        }
        public async Task DeleteAsync(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadRequest);
            var blog = _unitOfWork.BlogRepository.GetById(id);
            if (blog != null)
                await _unitOfWork.BlogRepository.Delete(blog);
            _unitOfWork.Save();
        }
        public void Edit(BlogDTO blog)
        {
            if (blog == null) throw new HttpException($"Error with edit blog!", HttpStatusCode.NotFound);
            _unitOfWork.BlogRepository.Update(_mapper.Map<Blog>(blog));
            _unitOfWork.Save();
        }
        public async Task<IEnumerable<BlogDTO>> Get()
        {
            return _mapper.Map<IEnumerable<BlogDTO>>(await _unitOfWork.BlogRepository.Get());
        }
        public async Task<BlogDTO> GetBlogByIdAsync(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadRequest);
            var blog = _unitOfWork.BlogRepository.GetById(id);
            if (blog == null) throw new HttpException($"Cart Not Found!", HttpStatusCode.NotFound);
            return _mapper.Map<BlogDTO>(await blog);
        }
        public async Task<IEnumerable<BlogPreviewDTO>> GetBlogByTitle()
        {
            return _mapper.Map<IEnumerable<BlogPreviewDTO>>(await _unitOfWork.BlogRepository.Get());
        }
    }
}
