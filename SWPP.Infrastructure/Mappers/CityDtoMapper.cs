using SWPP.Domain.Entities;
using SWPP.Infrastructure.Dto.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPP.Infrastructure.Mappers
{
    public class CityDtoMapper
    {
        private City City;

        public static CityDtoMapper For(City city)
        {
            return new CityDtoMapper()
            {
                City = city
            };
        }

        public CityDto Map()
        {
            return new CityDto()
            {
                Name = City.Name,
                CostOfWorkingHour = City.CostOfWorkingHour,
                TrasportCost = City.TrasportCost,
            };
        }
    }
}
