using Game.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Store.Application.Contracts
{
    public interface IStoreRepository : IRepository<GameItem>
    {

    }
   
}
