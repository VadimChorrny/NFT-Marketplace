using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using BLL.Services;
using BLL.Validations;
using DAL.Entity;
using DAL.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class ServiceException
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
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
