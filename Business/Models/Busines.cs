using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class Busines
    {
        [Key]
        public int BusinessID { get; set; } // Primary key
        public string Name { get; set; } = string.Empty; // Not nullable
        public string EmailId { get; set; } = string.Empty; // Not nullable
        public string? Password { get; set; }  // Not nullable
        public string? Description { get; set; } // Nullable
        public string? Location { get; set; } // Nullable
        public string? VisitingCard { get; set; } // Nullable
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int? CategoryID { get; set; } // Not nullable
        public int SubCategoryID { get; set; } // Foreign key

        // Navigation property
        public SubCategory SubCategory { get; set; } = null!;
    }
}
