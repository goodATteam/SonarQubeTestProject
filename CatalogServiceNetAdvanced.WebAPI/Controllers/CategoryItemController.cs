using CatalogServiceNetAdvanced.Application.CategoryItems.Commands.CreateCategoryItem;
using CatalogServiceNetAdvanced.Application.CategoryItems.Commands.DeleteCategoryItem;
using CatalogServiceNetAdvanced.Application.CategoryItems.Commands.UpdateCategoryItem;
using CatalogServiceNetAdvanced.Application.CategoryItems.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CatalogServiceNetAdvanced.WebAPI.Controllers
{
    public class CategoryItemController : ApiControllerBase
    {
        /// <summary>
        /// Return list of items regardin task for CategoryItem
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<CategoryItemsDto>> GetCategoryItem([FromQuery] GetCategoryItemsQuery query)
        {
            return await Mediator.Send(query);
        }

        /// <summary>
        /// Create CategoryItem object
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<int>> Create(CreateCategoryItemCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Update CategoryItem object
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, UpdateCategoryItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return Ok();
        }

        /// <summary>
        /// Delete CategoryItem and all related ProductItems
        /// </summary>
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int Id)
        {
            await Mediator.Send(new DeleteCategoryItemCommand(Id));

            return Ok();
        }
    }
}