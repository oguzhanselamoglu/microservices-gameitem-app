using AutoMapper;
using Game.Ordering.Application.Contracts;
using Game.Ordering.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game.Ordering.Application.Order.Queries
{
    public class GetOrderQuery :IRequest<List<OrderDto>>
    {

    }

    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<OrderDto>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {

            var orders = await _orderRepository.GetAllAsync();

            var ordersDto = _mapper.Map<List<OrderDto>>(orders);

            return ordersDto;
        }
    }
}
