using IMS.Application.DTO.Request.Identity;
using IMS.Application.DTO.Response;
using IMS.Application.DTO.Response.Identity;

namespace IMS.Application.Interface.Identity;

public interface IAccount {

    Task<ServiceResponse> LoginAsync(LoginUserRequestDTO model);

    Task<ServiceResponse> CreateUserAsync(CreateUserRequestDTO model);

    Task<IEnumerable<GetUsersWithClaimsResponseDTO>> GetUsersWithClaimsAsync();

    Task SetUpAsync();

    Task<ServiceResponse> UpdateUserAsync(ChangeUserClaimRequestDTO model);
}
