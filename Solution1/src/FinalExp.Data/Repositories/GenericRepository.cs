using FinalExp.Core.Entities;
using FinalExp.Core.Repositories;
using FinalExp.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinalExp.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            this._context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<int> CommitAsync()
        {
           return await _context.SaveChangesAsync();
        }

        public async Task Create(T entity)
        {
             await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            Table.Remove( entity);
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>>? expression = null, params string[]? includes)
        {
            var guery = GetQuery(includes);
            return expression is not null? await guery.Where(expression).ToListAsync():await guery.ToListAsync();
            
        }

        public async Task<T> GetById(Expression<Func<T, bool>> expression, params string[] includes)
        {
            var guery = GetQuery(includes);
            return expression is not null ? await guery.Where(expression).FirstOrDefaultAsync() : await guery.FirstOrDefaultAsync();
        }

        private IQueryable<T> GetQuery(string[] includes)
        {
            var query = Table.AsQueryable();
            if(includes is not null)
            {
                foreach (var inculude in includes)
                {
                    query = query.Include(inculude);
                }
            }
            return query;
        }
    }
}
