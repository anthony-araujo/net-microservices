using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JHipsterNet.Core.Pagination;
using JHipsterNet.Core.Pagination.Extensions;
using araujo.Domain.Entities;
using araujo.Security;
using araujo.Domain.Services.Interfaces;
using araujo.Dto;
using araujo.Web.Extensions;
using araujo.Web.Filters;
using araujo.Web.Rest.Problems;
using araujo.Web.Rest.Utilities;
using araujo.Crosscutting.Constants;
using araujo.Crosscutting.Exceptions;
using araujo.Infrastructure.Web.Rest.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace araujo.Controllers;


[Route("api/users")]
[ApiController]
public class PublicUsersController : ControllerBase
{
    private readonly ILogger<UsersController> _log;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public PublicUsersController(ILogger<UsersController> log, IUserService userService, IMapper mapper)
    {
        _log = log;
        _userService = userService;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAllPublicUsers(IPageable pageable)
    {
        _log.LogDebug("REST request to get a page of Users");
        var page = await _userService.GetAllPublicUsers(pageable);
        var userDtos = page.Content.Select(user => _mapper.Map<UserDto>(user));
        var headers = page.GeneratePaginationHttpHeaders();
        return Ok(userDtos).WithHeaders(headers);
    }

}
