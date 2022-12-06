using System.Threading.Tasks;
using JHipsterNet.Core.Pagination;
using araujo.Domain.Entities;

namespace araujo.Domain.Services.Interfaces
{
    public interface IBlogService
    {
        Task<Blog> Save(Blog blog);

        Task<IPage<Blog>> FindAll(IPageable pageable);

        Task<Blog> FindOne(long id);

        Task Delete(long id);
    }
}
