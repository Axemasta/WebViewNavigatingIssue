using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace WebViewCancelExample.Platform
{
    public class PlatformHelper
    {
        public static void SetPlatformStyling(Xamarin.Forms.TabbedPage tabbedPage)
        {
            tabbedPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            tabbedPage.On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}
