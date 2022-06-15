using AutoMapper;
using Game.Store.Application.Models;
using Game.Store.Application.Store.Commands;
using Game.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Store.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GameItem, GameItemDto>().ReverseMap();
            CreateMap<GameItem, CreateGameItemCommand>().ReverseMap();


        }
    }
}
