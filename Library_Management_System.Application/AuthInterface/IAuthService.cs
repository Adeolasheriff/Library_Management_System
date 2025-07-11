using Library_Management_System.Application.DTO;

namespace Library_Management_System.Application.AuthInterface
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(UserDto dto);
        Task<AuthResponseDto> LoginAsync(UserDto dto);
    }
}
