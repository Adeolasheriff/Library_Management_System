//namespace Library_Management_System.Domain.Entities
//{
//    public class User
//    {
//        public Guid Id { get; set; } = Guid.NewGuid();
//        public required string Username { get; set; }
//        public required string PasswordHash { get; set; }
//    }
//}


namespace Library_Management_System.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
    }
}
