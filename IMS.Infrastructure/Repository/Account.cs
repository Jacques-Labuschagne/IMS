using IMS.Application.DTO.Request.Identity;
using IMS.Application.DTO.Response;
using IMS.Application.DTO.Response.Identity;
using IMS.Application.Extension.Identity;
using IMS.Application.Interface.Identity;
using IMS.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Identity;

namespace IMS.Infrastructure.Repository;

public class Account (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context) : IAccount {
    
    public Task<ServiceResponse> CreateUserAsync(CreateUserRequestDTO model) {

        throw new NotImplementedException();
    }

    public Task<IEnumerable<GetUsersWithClaimsResponseDTO>> GetUsersWithClaimsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse> LoginAsync(LoginUserRequestDTO model)
    {
        throw new NotImplementedException();
    }

    public async Task SetUpAsync() => await CreateUserAsync(new CreateUserRequestDTO() {
        Name = "Administrator",
        Email = "admin@admin.com",
        Password = "Admin@123",
        Policy = Policy.AdminPolicy
    });

    public Task<ServiceResponse> UpdateUserAsync(ChangeUserClaimRequestDTO model)
    {
        throw new NotImplementedException();
    }
}