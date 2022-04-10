using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPP.Domain.Entities
{
    public class SearchHistory : BaseEntity
    {
        public double ProductionCost { get; private set; }
        public virtual City City { get; private set; }
        public virtual List<Module> Modules { get; private set; } = new List<Module>();

        public SearchHistory() { }

        /// <summary>
        /// Creates and calculates production cost search history.
        /// </summary>
        /// <param name="city">production city</param>
        /// <param name="modules">device modules</param>
        /// <returns>search history entry</returns>
        public static SearchHistory Create(City city, List<Module> modules)
        {
            var history = new SearchHistory()
            {
                City = city,
                Modules = modules,
            };

            history.CalculateCost();

            return history;
        }

        /// <summary>
        /// Calculates production cost 
        /// </summary>
        public void CalculateCost()
        {
            ProductionCost = (City.TrasportCost + Modules.Sum(x => x.Price) + Modules.Sum(x => x.AssemblyTime) * City.CostOfWorkingHour) * 1.3;
        } 
    }
}
