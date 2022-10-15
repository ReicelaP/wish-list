using System.Linq;
using WishList.Core.Models;
using WishList.Core.Services;

namespace WishList.Services
{
    public class UserService : IUserService
    {
        public string GetNames(UserList list)
        {
            var result = list.Users.Select(user => user.Name).ToArray();
            return string.Join(", ", result);
        }
    }
}
