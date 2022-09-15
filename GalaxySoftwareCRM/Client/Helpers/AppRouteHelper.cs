using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace GalaxySoftwareCRM.Client.Helpers
{
    public class AppRouteHelper : RouteView
    {
        protected override void Render(RenderTreeBuilder builder)
        {
            var authorize = Attribute.GetCustomAttribute(RouteData.PageType, typeof(AuthorizeAttribute)) != null;
            base.Render(builder);
        }
    }
}
