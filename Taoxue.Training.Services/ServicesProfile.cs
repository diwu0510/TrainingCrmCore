using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Taoxue.Training.Services
{
    public class ServicesProfile : Profile
    {
        public ServicesProfile()
        {
            CreateMap<OrderCreateDto, OrderEntity>();
            CreateMap<OrderDetailsCreateDto, OrderDetailsEntity>()
                .ForMember(t => t.GoodsType, opt => {
                    opt.MapFrom(s => (int)s.GoodsType);
                });
        }
    }
}
