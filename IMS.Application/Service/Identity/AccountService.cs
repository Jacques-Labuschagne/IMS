using IMS.Application.DTO.Request.Identity;
using IMS.Application.DTO.Response;
using IMS.Application.DTO.Response.Identity;
using IMS.Application.Interface.Identity;

namespace IMS.Application.Service.Identity;

public class AccountService(IAccount account) : IAccountService
{
    public async Task<ServiceResponse> CreateUserAsync(CreateUserRequestDTO model)
        => await account.CreateUserAsync(model);

    public async Task<IEnumerable<GetUsersWithClaimsResponseDTO>> GetUsersWithClaimsAsync()
        => await account.GetUsersWithClaimsAsync();

    public async Task<ServiceResponse> LoginAsync(LoginUserRequestDTO model)
        => await account.LoginAsync(model);

    public async Task SetUpAsync() => await account.SetUpAsync();

    public async Task<ServiceResponse> UpdateUserAsync(ChangeUserClaimRequestDTO model)
        => await account.UpdateUserAsync(model);
}