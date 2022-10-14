using System.Collections.Generic;
using System.Linq;
using WishList.Core.Models;

namespace WishList.Core.Services
{
    public interface IEntityService<T> where T : Entity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        List<T> GetAll();
        IQueryable<T> Query();
    }
}
