using CatalogServiceNetAdvanced.Application.Common.Models;
using CatalogServiceNetAdvanced.Application.ProductItems.Commands.CreateProductItem;
using CatalogServiceNetAdvanced.Application.ProductItems.Commands.DeleteProductItem;
using CatalogServiceNetAdvanced.Application.ProductItems.Commands.UpdateProductItem;
using CatalogServiceNetAdvanced.Application.ProductItems.Queries;
using CatalogServiceNetAdvanced.WebAPI.RabbitMQ;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CatalogServiceNetAdvanced.WebAPI.Controllers
{
    public class ProductItemController : ApiControllerBase
    {
        private readonly ILogger<ProductItemController> _logger;
        private readonly IRabitMQProducer _rabitMQProducer;

        public ProductItemController(ILogger<ProductItemController> logger, IRabitMQProducer rabitMQProducer)
        {
            _logger = logger;
            _rabitMQProducer = rabitMQProducer;
        }

        /// <summary>
        /// Return list of ProductItems regardin task by CategoryId and with pagination
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<PaginatedList<ProductItemBriefDto>>> GetProductItem([FromQuery] GetProductItemsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        /// <summary>
        /// Create ProductItem object
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<int>> Create(CreateProductItemCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Update ProductItem object
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, UpdateProductItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            _rabitMQProducer.SendProductMessage(command);

            return Ok();
        }

        /// <summary>
        /// Delete ProductItem object
        /// </summary>
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int Id)
        {
            await Mediator.Send(new DeleteProductItemCommand(Id));

            return Ok();
        }
    }
}