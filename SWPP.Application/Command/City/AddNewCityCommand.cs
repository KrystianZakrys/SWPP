using MediatR;
using SWPP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPP.Core.Command.City
{
    public class AddNewCityCommand : IRequestHandler<AddNewCityCommand.Request, Unit>
    {
        public class Request : IRequest<Unit>
        {
            public string Name { get; set; }
            public double TrasportCost { get; set; }
            public double CostOfWorkingHour { get; set; }
        }

        private readonly IUnitOfWork unitOfWork;

        public AddNewCityCommand(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<Unit> Handle(Request request, CancellationToken cancellationToken)
        {
            var city = Domain.Entities.City.Create(request.Name, request.TrasportCost, request.CostOfWorkingHour);
            unitOfWork.CityRepository.Add(city);
            unitOfWork.Save();
            return null;
        }
    }
}
