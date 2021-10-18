using Bloomcoding.Common.Dtos.Groups;
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
    public class GroupRepository : IGroupRepository
    {
        private readonly BloomcodingDbContext _context;
        private DbSet<Group> _table;

        public GroupRepository(BloomcodingDbContext context)
        {
            _context = context;
            _table = _context.Set<Group>();
        }

        public async Task Add(Group entity)
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAll()
        {
            return await _table.CountAsync();
        }

        public async Task<int> CountWhere(Expression<Func<Group, bool>> predicate)
        {
            return await _table.CountAsync(predicate);
        }

        public async Task<Group> FirstOrDefault(Expression<Func<Group, bool>> predicate)
        {
            return await _table.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Group>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<Group> GetById(int id)
        {
            return await _table.FindAsync(id);
        }

        public PagedList<Group> GetPagedList(FiltersOptions filtersOptions)
        {
            return PagedList<Group>.ToPagedList(_table.OrderBy(x => x.Id), filtersOptions.PageNumber, filtersOptions.PageSize);
        }

        public async Task<List<Group>> GetUserGroups(int id)
        {
            return await _table.Where(x => x.Users.Any(y => y.Id == id)).ToListAsync();
        }

        public async Task<IEnumerable<Group>> GetWhere(Expression<Func<Group, bool>> predicate)
        {
            return await _table.Where(predicate).ToListAsync();
        }

        public Task Remove(Group entity)
        {
            _table.Remove(entity);
            return _context.SaveChangesAsync();
        }

        public Task Update(Group entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
