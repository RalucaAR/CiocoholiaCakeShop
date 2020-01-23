using AutoMapper;
using CakeShop.API.ViewModels;
using Ciocoholia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciocoholia.API.Services
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderViewModel, Order>();
        }
    }
}
