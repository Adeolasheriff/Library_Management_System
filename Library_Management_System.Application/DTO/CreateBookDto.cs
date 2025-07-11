namespace Library_Management_System.Application.DTO;

public class CreateBookDto
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string ISBN { get; set; }
    public DateTime PublishedDate { get; set; }
}
