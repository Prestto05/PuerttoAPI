namespace Core.Puertto
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public class Example
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Data { get; set; }
    }
}