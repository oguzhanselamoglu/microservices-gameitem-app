using Game.Ordering.Application.Contracts;
using Game.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Ordering.Application.Contracts
{
    public interface IOrderRepository : IRepository<Ordering.Domain.OrderAggregate.Order>
    {

    }
   
}
