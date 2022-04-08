using SWPP.Domain.Entities;
using SWPP.Infrastructure.Repositories;

namespace SWPP.Infrastructure
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private SWPPContext context;
        private Repository<Module> moduleRepository;
        private Repository<City> cityRepository;
        private SearchHistoryRepository searchHistoryRepository;

        public UnitOfWork(SWPPContext context) { this.context = context; }

        public Repository<Module> ModuleRepository
        {
            get
            {
                if (this.moduleRepository == null)
                {
                    this.moduleRepository = new Repository<Module>(context);
                }
                return moduleRepository;
            }
        }
        public Repository<City> CityRepository
        {
            get
            {
                if (this.cityRepository == null)
                {
                    this.cityRepository = new Repository<City>(context);
                }
                return cityRepository;
            }
        }
        public SearchHistoryRepository SearchHistoryRepository
        {
            get
            {
                if (this.searchHistoryRepository == null)
                {
                    this.searchHistoryRepository = new SearchHistoryRepository(context);
                }
                return searchHistoryRepository;
            }
        }       

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
