using SWPP.Domain.Entities;
using SWPP.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPP.Infrastructure
{
    public interface IUnitOfWork
    {
        void Save();
        Repository<Module> ModuleRepository { get; }
        Repository<City> CityRepository { get; }
        Repository<SearchHistory> SearchHistoryRepository { get; }
    }
}
