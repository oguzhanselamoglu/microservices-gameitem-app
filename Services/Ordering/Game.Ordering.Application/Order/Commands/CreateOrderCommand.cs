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

namespace Game.Ordering.Application.Order.Commands
{
    public class CreateOrderCommand:IRequest<int>
    {
        public string BuyerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }

        public AddressDto Address { get; set; }
    }


    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newOrder = new Ordering.Domain.OrderAggregate.Order(request.BuyerId, new Domain.OrderAggregate.Address(request.Address.Province, request.Address.District, request.Address.Street, request.Address.ZipCode, request.Address.Line));
            request.OrderItems.ForEach(x =>
            {
                newOrder.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureUrl);
            });

            await _orderRepository.AddAsync(newOrder);
            return newOrder.Id;
        }
    }
}
