using SWPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPP.Infrastructure.Repositories
{
    public class SearchHistoryRepository : Repository<SearchHistory>, ISearchHistoryRepository
    {
        public SearchHistoryRepository(SWPPContext context) : base(context)
        {
        }

        public IEnumerable<SearchHistory> GetByCityAndModules(Guid cityId, List<Guid> moduleIds)
        {
            return this.dbSet.Where(x => x.City.Id == cityId && !x.Modules.Any(y => moduleIds.Contains(y.Id)));
        }
    }
}
