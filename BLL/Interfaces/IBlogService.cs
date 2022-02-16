using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> Get();
        Task<Blog> GetBlogByIdAsync(int id);
        Task CreateAsync(Blog blog);
        void Edit(Blog blog);
        Task DeleteAsync(int id);
    }
}
