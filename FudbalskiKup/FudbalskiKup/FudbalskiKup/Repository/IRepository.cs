using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalskiKup.Models
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity FindByID(object id);
        List<TEntity> GetList();
        void Insert(TEntity entity);
        void Delete(object id);
        void Update(TEntity entityToUpdate);


    }
}
