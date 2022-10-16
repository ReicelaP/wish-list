using System.Collections.Generic;
using WishList.Core.Interfaces;

namespace WishList.Core.Services
{
    public class ServiceResult
    {
        public ServiceResult(bool success)
        {
            Success = success;
            Errors = new List<string>();
        }

        public ServiceResult SetEntity(IEntity entity)
        {
            Entity = entity;
            return this;
        }

        public ServiceResult AddError(string error)
        {
            Errors.Add(error);
            return this;
        }

        public bool Success { get; private set; }
        
        public IEntity Entity { get; private set; }

        public IList<string> Errors { get; private set; }

        public string ErrorMessage => string.Join(",", Errors);
    }
}
