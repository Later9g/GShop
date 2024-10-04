namespace GShop.Api.Controllers;

using AutoMapper;
using GShop.Services.UserAccount;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("v{version:apiVersion}/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ILogger<AccountController> logger;
    private readonly IUserAccountService userAccountService;

    public AccountController(IMapper mapper, ILogger<AccountController> logger, IUserAccountService userAccountService)
    {
        this.mapper = mapper;
        this.logger = logger;
        this.userAccountService = userAccountService;
    }

    [HttpPost("")]
    public async Task<UserResponceDTO> Register([FromQuery] UserRegisterRequestDTO request)
    {
        var userModel = UserDtoMapper.UserRegisterRequestDtoToRegisterUserAccountModel(request);

        var user = await userAccountService.Create(userModel);

        var responce = UserDtoMapper.UserAccountModelToUserResponceDto(user);

        return responce;
    }

    [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
    {
        var user = await userAccountService.GetUser(id);

        if(user == null) { return NotFound(); }

        var result = UserDtoMapper.UserAccountModelToUserResponceDto(user);

        return Ok(result);
    }

    [Authorize]
    [HttpPut("{id:Guid}")]
    public async Task Update([FromRoute] Guid id, UpdateUserAccountModel request)
    {
        await userAccountService.Update(id, request);
    }

    [Authorize]
    [HttpDelete("")]
    public async Task Delete()
    {
        await userAccountService.Delete();
    }

    [Authorize]
    [HttpPut("")]
    public async Task ConfirmEmail()
    {
        var baseUrl = $"{Request.Scheme}://{Request.Host}";

        await userAccountService.SendEmailConfirmation(baseUrl);
    }

}
    