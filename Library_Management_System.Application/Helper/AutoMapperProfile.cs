using AutoMapper;
using Library_Management_System.Application.DTO;
using Library_Management_System.Domain.Entities;

namespace Library_Management_System.Domain.Helper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateBookDto, Book>();
        CreateMap<UpdateBookDto, Book>();
        //CreateMap<User, AuthResponseDto>();
        CreateMap<User, UserDto>().ReverseMap();
    }
}
