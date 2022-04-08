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
    public class GetCitiesQuery : IRequestHandler<GetCitiesQuery.Request, IEnumerable<CityDto>>
    {
        public class Request : IRequest<IEnumerable<CityDto>>
        { }

        private readonly IUnitOfWork unitOfWork;
        public GetCitiesQuery(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CityDto>> Handle(Request request, CancellationToken cancellationToken)
        {
            return unitOfWork.CityRepository.GetAll().Select(x =>
            {
                return CityDtoMapper.For(x).Map();
            }).ToList();
        }

    }
}
