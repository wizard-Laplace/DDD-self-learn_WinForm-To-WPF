using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.SQLite
{
    public sealed class AreasSQLite : IAreasRepository
    {
        public IReadOnlyList<AreaEntity> GetData()
        {
            string sql = @"
select AreaId,
       AreaName
from Areas";

            return SQLiteHelper.Query(sql,
                reader =>
                {
                    return new AreaEntity(Convert.ToInt32(reader["AreaId"]),
                                Convert.ToString(reader["AreaName"]));
                });
        }
    }
}
