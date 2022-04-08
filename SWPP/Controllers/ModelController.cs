using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPP.Core.Command.Module;
using SWPP.Core.Query.Module;
using SWPP.Infrastructure.Dto.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWPP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ModelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ModelController>
        [HttpGet]
        public Task<IEnumerable<ModuleDetailsDto>> GetAll()
        {
            return _mediator.Send(new GetModulesQuery.Request());
        }

        // GET api/<ModelController>/5
        [HttpGet("{id}")]
        public Task<ModuleDetailsDto> Get(Guid id)
        {
            return _mediator.Send(new GetModuleQuery.Request() { ModuleId = id});
        }

        // POST api/<ModelController>
        [HttpPost]
        public Task<bool> Post([FromBody] ModuleDetailsDto model)
        {
            return _mediator.Send(new AddNewModuleCommand.Request()
            {
                AssemblyTime = model.AssemblyTime,
                Code = model.Code,
                Description = model.Description,
                Name = model.Name,
                Price = model.Price,
                Weight = model.Weight,
            });
        }

        // PUT api/<ModelController>/5
        [HttpPut("{id}")]
        public Task<bool> Put(Guid id, [FromBody] ModuleDetailsDto model)
        {
            return _mediator.Send(new UpdateModuleCommand.Request()
            {
                AssemblyTime = model.AssemblyTime,
                Code = model.Code,
                Description = model.Description,
                Name = model.Name,
                Price = model.Price,
                Weight = model.Weight,
                Id = id
            });
        }

        // DELETE api/<ModelController>/5
        [HttpDelete("{id}")]
        public Task<bool> Delete(Guid id)
        {
            return _mediator.Send(new DeleteModuleCommand.Request() { Id = id });
        }
    }
}
