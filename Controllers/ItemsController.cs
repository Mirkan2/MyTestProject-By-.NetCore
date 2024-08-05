using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyTestProject.Commands;
using MyTestProject.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace MyTestProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateItemCommand command)
        {
         
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _mediator.Send(new GetItemsQuery());
            if (items == null || !items.Any())
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var items = await _mediator.Send(new GetItemsQuery());
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID does not match.");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteItemCommand { Id = id });
            return NoContent();
        }
    }
}
