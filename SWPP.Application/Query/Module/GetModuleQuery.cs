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
  
    public class GetModuleQuery : IRequestHandler<GetModuleQuery.Request, ModuleDetailsDto>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetModuleQuery(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public class Request : IRequest<ModuleDetailsDto>
        {
            public Guid ModuleId { get; set; }

        }

        public async Task<ModuleDetailsDto> Handle(Request request, CancellationToken cancellationToken)
        {
            var module = unitOfWork.ModuleRepository.Get(request.ModuleId);
            if(module != null)
            {
                return ModelDtoMapper.For(module).Map();
            }

            return new ModuleDetailsDto();
        }
    }
}
