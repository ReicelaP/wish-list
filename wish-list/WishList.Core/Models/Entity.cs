using WishList.Core.Interfaces;

namespace WishList.Core.Models
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }    
    }
}
