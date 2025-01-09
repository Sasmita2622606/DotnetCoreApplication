using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class Customer
    {
        [Key]
        public int Cus_Id { get; set; }
        public string? Cus_EmailId { get; set; }
        public string? Cus_Password { get; set; }
        public string? Cus_Location { get; set; }
    }
}
