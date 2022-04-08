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
    }
}
