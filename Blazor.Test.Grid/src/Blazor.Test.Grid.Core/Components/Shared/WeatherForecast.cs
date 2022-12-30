using System;
using System.Linq;

namespace Blazor.Test.Grid.Core.Components.Shared
{

	public class WeatherForecast
	{
		public DateTime LastRendered => DateTime.UtcNow;
		public DateTime Date { get; set; }

		public int TemperatureC { get; set; }

		public string Summary { get; set; }

		public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

		public static readonly WeatherForecast[] Data = Enumerable.Range(1,2).Select(i=>
			new WeatherForecast
			{
				 Date = DateTime.Parse("2018-05-06").AddDays(i),
				 TemperatureC = new Random().Next(-20,50),
				 Summary = i == 1 ? "_Single line" : i % 3 == 0 ? "Freezing" : i % 5 == 0 ? "Chilly" : i % 7 == 0 ? "Balmy" : "Chilly"
			}).ToArray();
	}
}
