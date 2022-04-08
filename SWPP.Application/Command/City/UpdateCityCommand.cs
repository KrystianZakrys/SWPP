﻿using MediatR;
using SWPP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPP.Core.Command.City
{
    public class UpdateCityCommand : IRequestHandler<UpdateCityCommand.Request, Unit>
    {
        public class Request : IRequest<Unit>
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public double TrasportCost { get; set; }
            public double CostOfWorkingHour { get; set; }
        }

        private readonly IUnitOfWork unitOfWork;

        public UpdateCityCommand(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<Unit> Handle(Request request, CancellationToken cancellationToken)
        {
            var entity = unitOfWork.CityRepository.Get(request.Id);
            if(entity != null)
            {
                entity.Update(request.Name, request.TrasportCost, request.CostOfWorkingHour);
                unitOfWork.Save();
            }
            return null;
        }
    }
}
