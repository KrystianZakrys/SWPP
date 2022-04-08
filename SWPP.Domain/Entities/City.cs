using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPP.Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; private set; }
        public double TrasportCost { get; private set; }
        public double CostOfWorkingHour { get; private set; }

        public City() { }

        public static City Create(string name, double transportCost, double costOfWorkingHour)
        {
            return new City()
            {
                Name = name,
                CostOfWorkingHour = costOfWorkingHour,
                TrasportCost = transportCost
            };
        }

        public void Update(string name, double transportCost, double costOfWorkingHour)
        {
            Name = name;
            CostOfWorkingHour = costOfWorkingHour;
            TrasportCost *= transportCost;
        }

    }
}
