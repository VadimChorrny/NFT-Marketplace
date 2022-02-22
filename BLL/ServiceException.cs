using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Core.Services;
using Core.Validations;
using Core.Entity;
using Core.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class ServiceException
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IAnimationService, AnimationService>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var configures = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Cart, CartDTO>().ReverseMap();
                mc.CreateMap<Blog, BlogDTO>().ReverseMap();
                mc.CreateMap<Blog, BlogPreviewDTO>().ReverseMap();
                mc.CreateMap<Animation, AnimationDTO>().ReverseMap();
            });
            IMapper mapper = configures.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<CartValidator>());
        }
    }
}
