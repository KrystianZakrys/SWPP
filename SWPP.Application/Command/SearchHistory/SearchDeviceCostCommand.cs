using MediatR;
using SWPP.Infrastructure;
using SWPP.Infrastructure.Dto.SearchHistory;
using SWPP.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPP.Core.Command.SearchHistory
{
    public class SearchDeviceCostCommand : IRequestHandler<SearchDeviceCostCommand.Request, SearchResultDto>
    {
        private readonly IUnitOfWork unitOfWork;
        
        public SearchDeviceCostCommand(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public class Request : IRequest<SearchResultDto> 
        {
            public IEnumerable<Guid> ModuleIds { get; set; }
            public Guid CityId { get; set; }
        }

        //Cost = (transportcost + modules cost sum + time of assembly sum * cos of 1h) * 1.3
        public async Task<SearchResultDto> Handle(Request request, CancellationToken cancellationToken)
        {
            var search = unitOfWork.SearchHistoryRepository.GetByCityAndModules(request.CityId, request.ModuleIds.ToList()).FirstOrDefault();
            if (search == null)
            {
                var city = unitOfWork.CityRepository.Get(request.CityId);
                
                var modules = request.ModuleIds.Select(x =>
                {
                    return unitOfWork.ModuleRepository.Get(x);
                }).ToList();

                search = Domain.Entities.SearchHistory.Create(city, modules);

                unitOfWork.SearchHistoryRepository.Add(search);
                unitOfWork.Save();                
            }

            return SearchHistoryMapper.For(search).Map();
        }

    }
}
