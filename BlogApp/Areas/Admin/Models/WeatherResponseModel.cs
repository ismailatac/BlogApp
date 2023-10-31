namespace BlogApp.Areas.Admin.Models
{
    public class WeatherResponseModel
    {
        public CoordModel coord { get; set; }
        public List<WeatherModel> weather { get; set; }
        public MainModel main { get; set; }
        public int id { get; set; }
        public string name { get; set; }

    }
}
