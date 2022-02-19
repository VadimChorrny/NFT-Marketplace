using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAnimationService
    {
        Task<IEnumerable<BlogDTO>> Get();
        Task<BlogDTO> GetBlogByIdAsync(int id);
        Task<IEnumerable<BlogPreviewDTO>> GetBlogByTitle();
        Task CreateAsync(BlogDTO blog);
        void Edit(BlogDTO blog);
        Task DeleteAsync(int id);
    }
}
