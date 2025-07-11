using Library_Management_System.Domain.Entities;

namespace Library_Management_System.Application.AuthInterface;

public interface IJwtUtils
{
    string GenerateToken(User user);
}