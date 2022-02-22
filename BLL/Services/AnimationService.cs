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
    public class AnimationService : IAnimationService   
    {
        private readonly IRepository<Animation> _animationsRepository;
        private readonly IMapper _mapper;
        public AnimationService(IRepository<Animation> repository,IMapper mapper)
        {
            _animationsRepository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(AnimationDTO animation)
        {
            if (animation == null) throw new HttpException($"Error with create blog!", HttpStatusCode.NotFound);
            await _animationsRepository.Insert(_mapper.Map<Animation>(animation));
            await _animationsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadRequest);
            var animation = _animationsRepository.GetById(id);
            if (animation != null)
                await _animationsRepository.Delete(animation);
            await _animationsRepository.SaveChangesAsync();
        }

        public void Edit(AnimationDTO animation)
        {
            if (animation == null) throw new HttpException($"Error with edit blog!", HttpStatusCode.NotFound);
            _animationsRepository.Update(_mapper.Map<Animation>(animation));
            _animationsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<AnimationDTO>> Get()
        {
            return _mapper.Map<IEnumerable<AnimationDTO>>(await _animationsRepository.Get());
        }

        public async Task<AnimationDTO> GetAnimationByIdAsync(int id)
        {
            if (id < 0) throw new HttpException($"Invalid id!", HttpStatusCode.BadRequest);
            var animation = _animationsRepository.GetById(id);
            if (animation == null) throw new HttpException($"Cart Not Found!", HttpStatusCode.NotFound);
            return _mapper.Map<AnimationDTO>(await animation);
        }
    }
}
