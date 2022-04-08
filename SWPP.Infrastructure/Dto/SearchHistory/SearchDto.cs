using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPP.Infrastructure.Dto.SearchHistory
{    
    public class SearchDto
    {
        public List<Guid> ModuleIds { get; set; }
        public Guid CityId { get; set; }
    }
}
