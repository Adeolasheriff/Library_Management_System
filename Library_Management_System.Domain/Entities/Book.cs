namespace Library_Management_System.Domain.Entities;

public class Book
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string ISBN { get; set; }
    public DateTime PublishedDate { get; set; }

    // Soft Delete
    public bool IsDeleted { get; set; } = false;
    public DateTime DeletedAt { get; set; }
}
