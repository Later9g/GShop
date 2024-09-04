namespace GShop.api.Controllers;

using AutoMapper;
using GShop.Services.UserAccount;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using GShop.Services.Gadgets;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("v{version:apiVersion}/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ILogger<AccountsController> logger;
    private readonly IUserAccountService userAccountService;

    public AccountsController(IMapper mapper, ILogger<AccountsController> logger, IUserAccountService userAccountService)
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
        public async Task<UserResponceDTO> Get(Guid id)
    {
        var user = await userAccountService.GetUser(id);

        if(user == null) { return null; }

        var result = UserDtoMapper.UserAccountModelToUserResponceDto(user);

        return result;
    }

    [Authorize]
    [HttpDelete("")]
    public async Task Delete()
    {
        await userAccountService.Delete();
    }

}
    