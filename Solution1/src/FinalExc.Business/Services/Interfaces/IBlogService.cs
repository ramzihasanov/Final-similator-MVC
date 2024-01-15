using FinalExp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExc.Business.Services.Interfaces
{
    public interface IBlogService
    {
        Task Create(Blog blog);
        void DeleteAsync(int id);
        Task Update(Blog blog);
        Task<Blog> GetAsync(int id);
        Task<List<Blog>> GetBlogs();

    }
}
