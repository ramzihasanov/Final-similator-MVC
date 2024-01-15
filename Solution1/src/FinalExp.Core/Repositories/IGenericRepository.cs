using FinalExp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalExp.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
       public DbSet<T> Table { get; }
        Task Create(T entity);  
        void Delete(T entity);
        Task<T>GetById(Expression<Func<T, bool>> expression,params string[] includes);
        Task <List<T>> GetAll(Expression<Func<T, bool>>? expression=null, params string[]? includes);
        Task<int> CommitAsync();


    }
}
