using Bloomcoding.Common.Models.Pagination;
using Bloomcoding.Dal.Interfaces;
using Bloomcoding.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bloomcoding.Dal.Repositories
{
    public class HomeworkRepository : IHomeworkRepository
    {
        public Task Add(Homework entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountWhere(Expression<Func<Homework, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Homework> FirstOrDefault(Expression<Func<Homework, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Homework>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Homework> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public PagedList<Homework> GetPagedList(FiltersOptions filtersOptions)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Homework>> GetWhere(Expression<Func<Homework, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Homework entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Homework entity)
        {
            throw new NotImplementedException();
        }
    }
}
