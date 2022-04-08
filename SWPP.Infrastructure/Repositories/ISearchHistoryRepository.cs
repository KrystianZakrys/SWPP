using SWPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPP.Infrastructure.Repositories
{
    public interface ISearchHistoryRepository
    {
        IEnumerable<SearchHistory> GetByCityAndModules(Guid cityId, List<Guid> moduleIds);
    }
}
