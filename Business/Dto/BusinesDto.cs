namespace Business.Dto
{
    public class BusinesDto
    {
        public int BusinessID { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string? EmailId { get; set; }
        public string? Password { get; set; }
        public string? Description { get; set; } 
        public string? Location { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public IFormFile VisitingCard { get; set; }
       

        public int SubCategoryID { get; set; } 
        //public string? SubCategoryName { get; set; } 
        public int? CategoryID { get; set; } 
        //public string? CategoryName { get; set; } 
    }
}
