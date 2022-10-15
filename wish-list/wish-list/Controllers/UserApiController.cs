using Microsoft.AspNetCore.Mvc;
using WishList.Core.Models;
using WishList.Core.Services;

namespace wish_list.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private IUserService _userService;

        public UserApiController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("names")]
        [HttpPost]
        public IActionResult GetNames(UserList userList)
        {
            var names = _userService.GetNames(userList);

            if (names == null)
            {
                return NotFound();
            }

            return Ok(names);
        }
    }
}
