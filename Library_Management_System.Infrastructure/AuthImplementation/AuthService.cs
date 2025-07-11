using AutoMapper;
using Library_Management_System.Application.AuthInterface;
using Library_Management_System.Application.DTO;
using Library_Management_System.Domain.Entities;
using Library_Management_System.Infrastructure.AuthImplementation;
using Library_Management_System.Infrastructure.Repository;

namespace Library_Management_System.Application.AuthImplementation;

public class AuthService : IAuthService
{
    private readonly IRepository<User> _userRepo;
    private readonly IMapper _mapper;
    private readonly IJwtUtils _jwtUtils;
    public AuthService(IRepository<User> repository, IMapper mapper, IJwtUtils jwtUtils)
    {
        _userRepo = repository;
        _mapper = mapper;
        _jwtUtils = jwtUtils;
    }
    public async Task<AuthResponseDto> LoginAsync(UserDto dto)
    {
        var user = (await _userRepo.GetAllAsync()).FirstOrDefault(u => u.Username == dto.Username);

        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid credentials");

        return new AuthResponseDto
        {
            Token = _jwtUtils.GenerateToken(user)
        };
    }

    public async Task<string> RegisterAsync(UserDto dto)
    {
        if ((await _userRepo.GetAllAsync()).Any(u => u.Username == dto.Username))
            throw new ArgumentException("Username already taken");

        var user = _mapper.Map<User>(dto);
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        await _userRepo.AddAsync(user);
        await _userRepo.SaveChangesAsync();


        return "User registered";
    }
}
