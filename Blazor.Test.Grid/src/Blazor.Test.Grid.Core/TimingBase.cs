using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Blazor.Test.Grid.Core.Components;
using Microsoft.AspNetCore.Components;

namespace Blazor.Test.Grid.Core
{

  public class TimingBase : ComponentBase
  {
    [Inject] public TimingService timingService { get; set; }

    //private long _time = Stopwatch.GetTimestamp();
    private DateTime _time = DateTime.UtcNow;
    public TimingBase() : base()
    {
			//_time = Stopwatch.GetTimestamp();
			_time = DateTime.UtcNow;
      if (GetType().Name == typeof(App).Name) Console.WriteLine($"Starting Render: {DateTime.Now:hh:mm:ss.fff}");
    }
    protected override bool ShouldRender()
    {
      //_time = Stopwatch.GetTimestamp();
			_time = DateTime.UtcNow;
			return base.ShouldRender();
    }
    protected new void StateHasChanged()
    {
			_time = DateTime.UtcNow;
      base.StateHasChanged();
		}
    protected override void OnAfterRender(bool firstRender)
    {
      //var _end = Stopwatch.GetTimestamp();
      var _end = DateTime.UtcNow;
      timingService.AddTiming(this, _time, _end, _end - _time);
      if (GetType().Name == typeof(App).Name) Console.WriteLine($"Ending Render: {DateTime.Now:hh:mm:ss.fff}");
      base.OnAfterRender(firstRender);
    }
  }
  public class TimingService
  {
    private List<(string componentName, IComponent component, DateTime start, DateTime end, TimeSpan duration)> _renderTimes = new List<(string componentName, IComponent component, DateTime start, DateTime end, TimeSpan duration)>();
    public (string componentName, IComponent component, DateTime start, DateTime end, TimeSpan duration)[] GetTimingHistory() => _renderTimes.ToArray();
    public void AddTiming(IComponent component, DateTime start, DateTime end, TimeSpan duration)
    {
      _renderTimes.Add((component.GetType().Name, component, start, end, duration));
    }
    public void ClearHistory() => _renderTimes.Clear();

    public void DumpTimingSummary()
		{
			var data = _renderTimes;
			foreach (var item in data.GroupBy(d => d.componentName))
			{
				var maxDuration = item.Select(i => i.duration).Max();
				var minDuration = item.Select(i => i.duration).Min();
				var avgDuration = TimeSpan.FromMilliseconds(item.Select(i => i.duration.TotalMilliseconds).Average());
				Console.WriteLine($"{item.Key} : Count {item.Count():N0} : Slowest {maxDuration:ss\\.fff}(s) Quickest {minDuration:ss\\.fff}(s) Average {avgDuration:ss\\.fff}(s)");
			}
			Console.WriteLine($"Summary: Start Rendering {data.First().start:hh:mm:ss.fff} End Rendering {data.Last().end:hh:mm:ss.fff}");
		}
	}
}