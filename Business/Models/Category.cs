namespace Business.Models
{
    public class Category
    {
        public int CategoryID { get; set; } // Primary key
        public string CategoryName { get; set; } = string.Empty; // Not nullable
        public ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
    }
}
