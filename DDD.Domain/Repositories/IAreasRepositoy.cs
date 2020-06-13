using DDD.Domain.Entities;
using System.Collections.Generic;

namespace DDD.Domain.Repositories
{
    public interface IAreasRepositoy
    {
        IReadOnlyList<AreaEntity> GetData();
    }
}
