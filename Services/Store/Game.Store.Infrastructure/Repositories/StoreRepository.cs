using Game.Store.Application.Contracts;
using Game.Store.Domain.Entities;
using Game.Store.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Store.Infrastructure.Repositories
{
    public class StoreRepository: RepositoryBase<GameItem>, IStoreRepository
    {
        public StoreRepository(GameStoreContext dbContext) : base(dbContext)
        {

        }
    }
}
