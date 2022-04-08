using MediatR;
using SWPP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPP.Core.Command.Module
{
    public class DeleteModuleCommand : IRequestHandler<DeleteModuleCommand.Request, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteModuleCommand(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public class Request : IRequest<bool>
        {
           public Guid Id { get; set; }
        }

        public Task<bool> Handle(Request request, CancellationToken cancellationToken)
        {
            unitOfWork.ModuleRepository.Delete(request.Id);
            unitOfWork.Save();

            return Task.FromResult(true);
        }

    }
}
