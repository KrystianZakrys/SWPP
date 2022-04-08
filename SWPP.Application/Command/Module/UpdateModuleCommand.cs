using MediatR;
using SWPP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPP.Core.Command.Module
{
    public class UpdateModuleCommand : IRequestHandler<UpdateModuleCommand.Request, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        public UpdateModuleCommand(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public class Request : IRequest<bool>
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public double AssemblyTime { get; set; }
            public double Weight { get; set; }
            public string Description { get; set; }
            public Guid Id { get; set; }
        }

        public Task<bool> Handle(Request request, CancellationToken cancellationToken)
        {
            var model = unitOfWork.ModuleRepository.Get(request.Id);

            if(model != null)
            {
                model.Update(request.Code, request.Name, request.Price, request.AssemblyTime, request.Weight, request.Description);
                unitOfWork.Save();
            }

            return Task.FromResult(true);
        }

    }
}
