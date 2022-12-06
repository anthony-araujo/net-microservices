
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using JHipsterNet.Core.Pagination;
using araujo.Domain.Entities;
using araujo.Crosscutting.Exceptions;
using araujo.Dto;
using araujo.Web.Extensions;
using araujo.Web.Filters;
using araujo.Web.Rest.Utilities;
using AutoMapper;
using System.Linq;
using araujo.Domain.Repositories.Interfaces;
using araujo.Domain.Services.Interfaces;
using araujo.Infrastructure.Web.Rest.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace araujo.Controllers
{
    [Authorize]
    [Route("api/blogs")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private const string EntityName = "blog";
        private readonly ILogger<BlogsController> _log;
        private readonly IMapper _mapper;
        private readonly IBlogService _blogService;

        public BlogsController(ILogger<BlogsController> log,
        IMapper mapper,
        IBlogService blogService)
        {
            _log = log;
            _mapper = mapper;
            _blogService = blogService;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult<BlogDto>> CreateBlog([FromBody] BlogDto blogDto)
        {
            _log.LogDebug($"REST request to save Blog : {blogDto}");
            if (blogDto.Id != 0)
                throw new BadRequestAlertException("A new blog cannot already have an ID", EntityName, "idexists");

            Blog blog = _mapper.Map<Blog>(blogDto);
            await _blogService.Save(blog);
            return CreatedAtAction(nameof(GetBlog), new { id = blog.Id }, blog)
                .WithHeaders(HeaderUtil.CreateEntityCreationAlert(EntityName, blog.Id.ToString()));
        }

        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateBlog(long id, [FromBody] BlogDto blogDto)
        {
            _log.LogDebug($"REST request to update Blog : {blogDto}");
            if (blogDto.Id == 0) throw new BadRequestAlertException("Invalid Id", EntityName, "idnull");
            if (id != blogDto.Id) throw new BadRequestAlertException("Invalid Id", EntityName, "idinvalid");
            Blog blog = _mapper.Map<Blog>(blogDto);
            await _blogService.Save(blog);
            return Ok(blog)
                .WithHeaders(HeaderUtil.CreateEntityUpdateAlert(EntityName, blog.Id.ToString()));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogDto>>> GetAllBlogs(IPageable pageable)
        {
            _log.LogDebug("REST request to get a page of Blogs");
            var result = await _blogService.FindAll(pageable);
            var page = new Page<BlogDto>(result.Content.Select(entity => _mapper.Map<BlogDto>(entity)).ToList(), pageable, result.TotalElements);
            return Ok(((IPage<BlogDto>)page).Content).WithHeaders(page.GeneratePaginationHttpHeaders());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog([FromRoute] long id)
        {
            _log.LogDebug($"REST request to get Blog : {id}");
            var result = await _blogService.FindOne(id);
            BlogDto blogDto = _mapper.Map<BlogDto>(result);
            return ActionResultUtil.WrapOrNotFound(blogDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog([FromRoute] long id)
        {
            _log.LogDebug($"REST request to delete Blog : {id}");
            await _blogService.Delete(id);
            return NoContent().WithHeaders(HeaderUtil.CreateEntityDeletionAlert(EntityName, id.ToString()));
        }
    }
}
