using Microsoft.AspNetCore.Mvc;
using WishList.Core.Models;
using WishList.Core.Services;
using WishList.Core.Validations;

namespace wish_list.Controllers
{
    [Route("api/wish")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        private readonly IEntityService<Wish> _entityService;

        public AdminApiController(IEntityService<Wish> entityService)
        {
            _entityService = entityService;
        }

        [Route("{id}")]
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

        [HttpGet]
        public IActionResult GetWishList(int id)
        {
            var wishes = _entityService.GetAll();

            return Ok(wishes);
        }

        [HttpPost]
        public IActionResult AddWish(Wish wish)
        {
            if (!WishTitleValidator.IsValid(wish))
            {
                return BadRequest();
            }

            var result = _entityService.Create(wish);
            
            if (result.Success)
            {
                return Created("", wish);
            }

            return Problem(result.ErrorMessage);
        }

        [HttpPut]
        public IActionResult UpdateWish(int id, Wish wish)
        {
            var selectWish = _entityService.GetById(id);

            if (selectWish == null)
            {
                return NotFound();
            }

            selectWish.Title = wish.Title;
            var result = _entityService.Update(selectWish);

            if (result.Success)
            {
                return Ok(wish);
            }

            return Problem(result.ErrorMessage);
        }

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
