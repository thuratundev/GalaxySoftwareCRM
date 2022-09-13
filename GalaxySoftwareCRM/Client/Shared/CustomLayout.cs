using MudBlazor;

namespace GalaxySoftwareCRM.Client.Shared
{
    public class CustomLayout : MudTheme
    {
        public CustomLayout()
        {
            this.Palette = new Palette()
            {
                Primary = "#554994",
                Secondary = "#325374",
                AppbarBackground = "#554994",
            };

            this.PaletteDark = new Palette() { Primary = Colors.Blue.Lighten1 };

            this.LayoutProperties = new LayoutProperties() 
            {
                DrawerWidthLeft = "260px",
                DrawerWidthRight = "300px"
            };


        }
    }
}
