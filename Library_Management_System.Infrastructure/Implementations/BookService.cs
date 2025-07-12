using AutoMapper;
using Library_Management_System.Application.DTO;
using Library_Management_System.Application.Services.Interface;
using Library_Management_System.Domain.Entities;
using Library_Management_System.Infrastructure.Repository;

namespace Library_Management_System.Application.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepo;
        private readonly IMapper _mapper;
        public BookService(IRepository<Book> bookRepo,IMapper mapper)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;

        }
        public async Task<BookDto> CreateBookAsync(CreateBookDto dto)
        {
            if ((await _bookRepo.GetAllAsync()).Any(u => u.Title == dto.Title))
                throw new ArgumentException("Title already taken");

            var book = _mapper.Map<Book>(dto);
            var created = await _bookRepo.AddAsync(book);
            await _bookRepo.SaveChangesAsync();
            return _mapper.Map<BookDto>(created);
        }

        public async Task DeleteBookAsync(Guid id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book == null) throw new KeyNotFoundException("Book not found");

            book.IsDeleted = true;
            book.DeletedAt = DateTime.UtcNow;

            await _bookRepo.UpdateAsync(book);
            await _bookRepo.SaveChangesAsync();
        }

        public async Task<PagedResultDto<BookDto>> GetAllBooksAsync(string? search, int pageNumber, int pageSize)
        {
            var query = (await _bookRepo.GetAllAsync()).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(b => b.Title.Contains(search) || b.Author.Contains(search));

            var totalCount = query.Count();
            var items = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResultDto<BookDto>
            {
                Items = _mapper.Map<IEnumerable<BookDto>>(items),
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<BookDto?> GetBookByIdAsync(Guid id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            return book == null ? null : _mapper.Map<BookDto>(book);
        }

        public async Task UpdateBookAsync(Guid id, UpdateBookDto dto)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book == null) throw new KeyNotFoundException("Book not found");
           

            _mapper.Map(dto, book);
            await _bookRepo.UpdateAsync(book);
            await _bookRepo.SaveChangesAsync();
        }
    }
}






