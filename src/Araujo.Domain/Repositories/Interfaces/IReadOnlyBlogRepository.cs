
using araujo.Domain.Entities;

namespace araujo.Domain.Repositories.Interfaces
{

    public interface IReadOnlyBlogRepository : IReadOnlyGenericRepository<Blog, long>
    {
    }

}
