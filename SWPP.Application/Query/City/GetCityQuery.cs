using MediatR;
using SWPP.Infrastructure;
using SWPP.Infrastructure.Dto.City;
using SWPP.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPP.Core.Query.City
{
    public class GetCityQuery :  IRequestHandler<GetCityQuery.Request, CityDto>
    {
        public class Request : IRequest<CityDto> 
        {
            public Guid Id { get; set; }
        }

        private readonly IUnitOfWork unitOfWork;

        public GetCityQuery(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CityDto> Handle(Request request, CancellationToken cancellationToken)
        {
            var city = unitOfWork.CityRepository.Get(request.Id);
            return CityDtoMapper.For(city).Map();
        }
    }
}
