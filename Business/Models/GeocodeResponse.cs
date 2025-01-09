namespace Business.Models
{
    public class GeocodeResponse
    {
        public string status { get; set; }
        public Result[] results { get; set; }
        public string ErrorMessage { get; set; }
    }
}
