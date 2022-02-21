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
    public class AnimationService : IAnimationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AnimationService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateAsync(AnimationDTO animation)
        {
            if (animation == null) throw new HttpException($"Error with create blog!", HttpStatusCode.NotFound);
            await _unitOfWork.AnimationRepository.Insert(_mapper.Map<Animation>(animation));
            _unitOfWork.Save();
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadRequest);
            var animation = _unitOfWork.AnimationRepository.GetById(id);
            if (animation != null)
                await _unitOfWork.AnimationRepository.Delete(animation);
            _unitOfWork.Save();
        }

        public void Edit(AnimationDTO animation)
        {
            if (animation == null) throw new HttpException($"Error with edit blog!", HttpStatusCode.NotFound);
            _unitOfWork.AnimationRepository.Update(_mapper.Map<Animation>(animation));
            _unitOfWork.Save();
        }

        public async Task<IEnumerable<AnimationDTO>> Get()
        {
            return _mapper.Map<IEnumerable<AnimationDTO>>(await _unitOfWork.AnimationRepository.Get());
        }

        public async Task<AnimationDTO> GetAnimationByIdAsync(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadRequest);
            var animation = _unitOfWork.AnimationRepository.GetById(id);
            if (animation == null) throw new HttpException($"Cart Not Found!", HttpStatusCode.NotFound);
            return _mapper.Map<AnimationDTO>(await animation);
        }
    }
}
