using Blazor.Test.Grid.Core.Services;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Test.Grid.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<Core.Components.App>("app");
        }
    }
}
