using SWPP.Domain.Entities;
using SWPP.Infrastructure.Dto.SearchHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPP.Infrastructure.Mappers
{
    public class SearchHistoryMapper
    {
        private SearchHistory SearchHistory;

        public static SearchHistoryMapper For(SearchHistory searchHistory)
        {
            return new SearchHistoryMapper()
            {
                SearchHistory = searchHistory
            };
        }

        public SearchResultDto Map()
        {
            return new SearchResultDto()
            {
                Cost = SearchHistory.ProductionCost
            };
        }
    }
}
