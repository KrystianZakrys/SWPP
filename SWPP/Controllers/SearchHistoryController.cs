using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWPP.Core.Command.SearchHistory;
using SWPP.Infrastructure.Dto.SearchHistory;

namespace SWPP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SearchHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public Task<SearchResultDto> Post([FromBody] SearchDto request)
        {
            return _mediator.Send(new SearchDeviceCostCommand.Request()
            {
                ModuleIds = request.ModuleIds,
                CityId = request.CityId,
            });
        }
    }
}
