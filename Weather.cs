namespace ODataIssue
{
    public class Weather
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }

        public City City { get; set; }
    }

    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}