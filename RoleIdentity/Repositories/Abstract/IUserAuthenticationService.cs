using RoleIdentity.Models.DTO;

namespace RoleIdentity.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(Login model);
        Task<Status> RegistrationAsync(Registration model);
        Task LogoutAsync();
    }
}
