using System.Threading.Tasks;
using JHipsterNet.Core.Pagination;
using araujo.Domain.Entities;
using araujo.Domain.Services.Interfaces;
using araujo.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace araujo.Domain.Services;

public class BlogService : IBlogService
{
    protected readonly IBlogRepository _blogRepository;

    public BlogService(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public virtual async Task<Blog> Save(Blog blog)
    {
        await _blogRepository.CreateOrUpdateAsync(blog);
        await _blogRepository.SaveChangesAsync();
        return blog;
    }

    public virtual async Task<IPage<Blog>> FindAll(IPageable pageable)
    {
        var page = await _blogRepository.QueryHelper()
            .GetPageAsync(pageable);
        return page;
    }

    public virtual async Task<Blog> FindOne(long id)
    {
        var result = await _blogRepository.QueryHelper()
            .GetOneAsync(blog => blog.Id == id);
        return result;
    }

    public virtual async Task Delete(long id)
    {
        await _blogRepository.DeleteByIdAsync(id);
        await _blogRepository.SaveChangesAsync();
    }
}
