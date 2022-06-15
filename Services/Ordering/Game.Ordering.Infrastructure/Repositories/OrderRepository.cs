using Game.Ordering.Application.Contracts;
using Game.Ordering.Domain.OrderAggregate;
using Game.Ordering.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Ordering.Infrastructure.Repositories
{
    public class OrderRepository: RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(GameStoreContext dbContext) : base(dbContext)
        {

        }
    }
}
