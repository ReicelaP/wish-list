using Microsoft.AspNetCore.Mvc;
using WishList.Core.Models;
using WishList.Core.Services;
using WishList.Core.Validations;

namespace wish_list.Controllers
{
    [Route("api")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        private readonly IEntityService<Wish> _entityService;

        public AdminApiController(IEntityService<Wish> entityService)
        {
            _entityService = entityService;
        }

        [Route("wish/{id}")]
        [HttpGet]
        public IActionResult GetWish(int id)
        {
            var wish = _entityService.GetById(id);

            if (wish == null)
            {
                return NotFound();
            }

            return Ok(wish);
        }

        [Route("wishes")]
        [HttpGet]
        public IActionResult GetWishList(int id)
        {
            var wishes = _entityService.GetAll();

            return Ok(wishes);
        }

        [Route("wish")]
        [HttpPut]
        public IActionResult AddWish(Wish wish)
        {
            if (WishTitleValidator.IsValid(wish))
            {
                _entityService.Create(wish);
                return Created("", wish);
            }
            
            return BadRequest();
        }

        [Route("wish/delete")]
        [HttpDelete]
        public IActionResult DeleteWish(int id)
        {
            var wish = _entityService.GetById(id);
            
            if (wish != null)
            {
                _entityService.Delete(wish);
            }

            return Ok();
        }
    }
}
