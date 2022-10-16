using System.Collections.Generic;
using System.Linq;
using WishList.Core.Models;

namespace WishList.Core.Services
{
    public interface IEntityService<T> where T : Entity
    {
        ServiceResult Create(T entity);
        ServiceResult Update(T entity);
        ServiceResult Delete(T entity);
        T GetById(int id);
        List<T> GetAll();
        IQueryable<T> Query();
    }
}
