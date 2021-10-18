using Bloomcoding.Common.Models.Pagination;
using Bloomcoding.Dal.Interfaces;
using Bloomcoding.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bloomcoding.Dal.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private BloomcodingDbContext _context;
        private DbSet<Course> _table;

        public CourseRepository(BloomcodingDbContext context)
        {
            _context = context;
            _table = _context.Set<Course>();
        }
        public async Task Add(Course entity)
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task<int> CountAll()
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountWhere(Expression<Func<Course, bool>> predicate)
        {
            return await _table.CountAsync(predicate);
        }

        public Task<Course> FirstOrDefault(Expression<Func<Course, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Course> GetById(int id)
        {
            return await _table.Include(x => x.Group).FirstOrDefaultAsync(x => x.Id == id);
        }

        public PagedList<Course> GetPagedList(FiltersOptions filtersOptions)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetWhere(Expression<Func<Course, bool>> predicate)
        {
            return await _table.Where(predicate).ToListAsync();
        }

        public Task Remove(Course entity)
        {
            _table.Remove(entity);
            return _context.SaveChangesAsync();
        }

        public Task Update(Course entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
