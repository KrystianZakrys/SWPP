using MediatR;
using SWPP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPP.Core.Command.City
{
    public class DeleteCityCommand : IRequestHandler<DeleteCityCommand.Request, bool>
    {
        public class Request : IRequest<bool>
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public double TrasportCost { get; set; }
            public double CostOfWorkingHour { get; set; }
        }

        private readonly IUnitOfWork unitOfWork;

        public DeleteCityCommand(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(Request request, CancellationToken cancellationToken)
        {
            unitOfWork.CityRepository.Delete(request.Id);
            unitOfWork.Save();
            return Task.FromResult(true);
        }
    }
}
