using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.CompilerServices;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections.Generic;

namespace Blazor.Test.Grid.Core.Components
{
    public partial class Tag : ComponentBase
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string Name { get; set; }
        [Parameter(CaptureUnmatchedValues =true)] public Dictionary<string,object> attributes { get; set; }
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(1, Name);
            builder.AddMultipleAttributes(2, RuntimeHelpers.TypeCheck<IEnumerable<KeyValuePair<string, object>>>(attributes));
            ChildContent(builder);
            builder.CloseElement();
        }
    }
}
