using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrSU.ProcessExplorer.Data.Interfaces
{
    public class IRepository<TEntity>
    {
        TEntity Get(object id);

        IQueryable<TEntity> GetAll();

        TEntity Add(TEntity entity);
    }
}
