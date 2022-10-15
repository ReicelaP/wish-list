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

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
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
