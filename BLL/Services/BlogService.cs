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
        public BlogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateAsync(Blog blog)
        {
            if (blog == null) throw new HttpException($"Error with create blog!", HttpStatusCode.NotFound);
            await _unitOfWork.BlogRepository.Insert(blog);
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
        public void Edit(Blog blog)
        {
            if (blog == null) throw new HttpException($"Error with edit blog!", HttpStatusCode.NotFound);
            _unitOfWork.BlogRepository.Update(blog);
            _unitOfWork.Save();
        }
        public async Task<IEnumerable<Blog>> Get()
        {
            return await _unitOfWork.BlogRepository.Get();
        }
        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadRequest);
            var blog = _unitOfWork.BlogRepository.GetById(id);
            if (blog == null) throw new HttpException($"Cart Not Found!", HttpStatusCode.NotFound);
            return await blog;
        }
    }
}
