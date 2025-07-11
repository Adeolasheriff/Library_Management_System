using Library_Management_System.Application.DTO;

namespace Library_Management_System.Application.Services.Interface;

public interface IBookService
{
    Task<PagedResultDto<BookDto>> GetAllBooksAsync(string? search, int pageNumber, int pageSize);
    Task<BookDto?> GetBookByIdAsync(Guid id);
    Task<BookDto> CreateBookAsync(CreateBookDto dto);
    Task UpdateBookAsync(Guid id, UpdateBookDto dto);
    Task DeleteBookAsync(Guid id);
}