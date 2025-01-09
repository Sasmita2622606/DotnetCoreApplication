namespace Business.Models
{
    public class SubCategory
    {
        public int SubCategoryID { get; set; } // Primary key
        public string SubCategoryName { get; set; } = string.Empty; // Not nullable
        public int CategoryID { get; set; } // Foreign key

        public Category Category { get; set; } = null!; // Ensures non-null category
        public ICollection<Busines> Businesses { get; set; } = new List<Busines>();
    }
}
