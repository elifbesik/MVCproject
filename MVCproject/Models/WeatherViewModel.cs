namespace MVCproject.Models
{
    public class WeatherViewModel
    {  public string City { get; set; }
        public string Country { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Description { get; set; }
        public string Humidity { get; set; }
        public string TempFeelsLike { get; set; }
        public string Temp { get; set; }
        public string TempMax { get; set; }
        public string TempMin { get; set; }
        public string WeatherIcon { get; set; }
        public string Cloud { get; set; }
        public string WindSpeed { get; set; }
       
    }
    public class Coord
    {   public string Lon { get; set; }
        public string Lat { get; set; }
    }
    public class Weather
    {
        public string Description { get; set; }
        public string Icon { get; set; }
    }
    public class Main
    {
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public double Temp_min { get; set; }
        public double Temp_max { get; set; }
        public int Humidity { get; set; }
    }
    public class Wind
    {
        public double Speed { get; set; }
    }
    public class Clouds
    {
        public int All { get; set; }
    }
    public class Sys
    {
        public string Country { get; set; }
    }
    public class RootObject
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public Sys Sys { get; set; }
        public string Name { get; set; }
    }
}
