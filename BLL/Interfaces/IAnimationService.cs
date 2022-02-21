using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAnimationService
    {
        Task<IEnumerable<AnimationDTO>> Get();
        Task<AnimationDTO> GetAnimationByIdAsync(int id);
        Task CreateAsync(AnimationDTO animation);
        void Edit(AnimationDTO animation);
        Task DeleteAsync(int id);
    }
}
