using MediatR;
using SWPP.Infrastructure;
using SWPP.Infrastructure.Dto.Model;
using SWPP.WebApi.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPP.Core.Query.Module
{
  
    public class GetModulesQuery : IRequestHandler<GetModulesQuery.Request, IEnumerable<ModuleDetailsDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetModulesQuery(IUnitOfWork unitOfWork)
        { 
            this.unitOfWork = unitOfWork;
        }

        public class Request : IRequest<IEnumerable<ModuleDetailsDto>>
        {
        }

        public async Task<IEnumerable<ModuleDetailsDto>> Handle(Request request, CancellationToken cancellationToken)
        {
            return unitOfWork.ModuleRepository.GetAll().Select(x =>
            {
                return ModelDtoMapper.For(x).Map();
            });
        }
    }
}
