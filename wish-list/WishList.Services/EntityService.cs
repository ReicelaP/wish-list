using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WishList.Core.Models;
using WishList.Core.Services;
using WishList.Data;

namespace WishList.Services
{
    public class EntityService<T> : IEntityService<T> where T : Entity
    {
        protected IWishListDbContext _context;

        public EntityService (IWishListDbContext context)
        {
            _context = context;
        }

        public ServiceResult Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            
            return new ServiceResult(true).SetEntity(entity);
        }

        public ServiceResult Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            
            return new ServiceResult(true).SetEntity(entity);
        }

        public ServiceResult Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            
            return new ServiceResult(true);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}
