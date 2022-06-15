using AutoMapper;
using Game.Store.Application.Contracts;
using Game.Store.Application.Models;
using GameStore.Infrastructure.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game.Store.Application.Store.Queries
{
     
    public class GetStoreItemQuery :IRequest<ActionResponse<List<GameItemDto>>>
    {

    }

    public class GetStoreItemQueryHandler : IRequestHandler<GetStoreItemQuery, ActionResponse<List<GameItemDto>>>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public GetStoreItemQueryHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<ActionResponse<List<GameItemDto>>> Handle(GetStoreItemQuery request, CancellationToken cancellationToken)
        {
            var games =await _storeRepository.GetAllAsync();
            if (!games.Any())
            {
                return ActionResponse<List<GameItemDto>>.Success(new List<GameItemDto>(), 200);
            }

            var result = _mapper.Map<List<GameItemDto>>(games);

            return ActionResponse<List<GameItemDto>>.Success(result, 200);
        }
    }
}
