namespace Banking_Application.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // Use hashed passwords in production
    }
}
