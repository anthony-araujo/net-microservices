using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JHipsterNet.Core.Pagination;
using JHipsterNet.Core.Pagination.Extensions;
using araujo.Domain.Entities;
using araujo.Domain.Repositories.Interfaces;
using araujo.Infrastructure.Data.Extensions;

namespace araujo.Infrastructure.Data.Repositories
{
    public class BlogRepository : GenericRepository<Blog, long>, IBlogRepository
    {
        public BlogRepository(IUnitOfWork context) : base(context)
        {
        }

    }
}
