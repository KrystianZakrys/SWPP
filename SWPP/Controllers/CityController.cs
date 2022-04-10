using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPP.Core.Command.City;
using SWPP.Core.Query.City;
using SWPP.Infrastructure.Dto.City;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWPP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CityController>
        [HttpGet]
        public Task<IEnumerable<CityDto>> Get()
        {
            return _mediator.Send(new GetCitiesQuery.Request());
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public Task<CityDto> Get(Guid id)
        {
            return _mediator.Send(new GetCityQuery.Request(){ Id = id});
        }

        // POST api/<CityController>
        [HttpPost]
        public Task<bool> Post([FromBody] CityDto value)
        {
            return _mediator.Send(new AddNewCityCommand.Request(){
                CostOfWorkingHour = value.CostOfWorkingHour,
                Name = value.Name,
                TrasportCost = value.TrasportCost,
            });
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public Task<bool> Put(Guid id, [FromBody] CityDto value)
        {
            return _mediator.Send(new UpdateCityCommand.Request(){
                TrasportCost = value.TrasportCost,
                Name = value.Name,
                CostOfWorkingHour=value.CostOfWorkingHour,
                Id = id
            });
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public Task<bool> Delete(Guid id)
        {
            return _mediator.Send(new DeleteCityCommand.Request(){ Id = id});
        }
    }
}
