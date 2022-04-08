using Microsoft.EntityFrameworkCore;
using SWPP.Domain.Entities;

namespace SWPP.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected SWPPContext _context;
        protected DbSet<TEntity> dbSet;
        public Repository(SWPPContext context)
        {
            _context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void Delete(Guid id)
        {
            var entity = this.dbSet.FirstOrDefault(x => x.Id == id);
            if (entity != null)
                this.dbSet.Remove(entity);
        }

        public TEntity Get(Guid id)
        {
            return this.dbSet.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.dbSet;
        }
       
    }
}
