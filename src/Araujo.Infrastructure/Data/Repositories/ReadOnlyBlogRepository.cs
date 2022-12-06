using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JHipsterNet.Core.Pagination;
using JHipsterNet.Core.Pagination.Extensions;
using araujo.Domain.Entities;
using araujo.Domain.Repositories.Interfaces;
using araujo.Infrastructure.Data.Extensions;

namespace araujo.Infrastructure.Data.Repositories
{
    public class ReadOnlyBlogRepository : ReadOnlyGenericRepository<Blog, long>, IReadOnlyBlogRepository
    {
        public ReadOnlyBlogRepository(IUnitOfWork context) : base(context)
        {
        }
    }
}
