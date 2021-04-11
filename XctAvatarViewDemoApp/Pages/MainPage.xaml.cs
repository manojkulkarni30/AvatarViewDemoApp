using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using XctAvatarViewDemoApp.ViewModels;

namespace XctAvatarViewDemoApp.Pages
{
    public partial class MainPage : ContentPage
    {
        internal static Color[] ForeGroundColors = new Color[]
        {
            Color.FromRgb(0, 0, 0),
            Color.FromRgb(119, 78, 133),
            Color.FromRgb(211, 153, 184),
            Color.FromRgb(249, 218, 231),
            Color.FromRgb(223, 196, 208),
            Color.FromRgb(209, 158, 180),
            Color.FromRgb(171, 116, 139),
            Color.FromRgb(143, 52, 87)
        };

        internal static Color[] BackGroundColors = new Color[]
        {
            Color.FromRgb(0, 8, 20),
            Color.FromRgb(0, 29, 61),
            Color.FromRgb(0, 53, 102),
            Color.FromRgb(255, 195, 0),
            Color.FromRgb(255, 214, 10)
        };

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }

    public static class MyColorSchemes
    {
        public static readonly IColorTheme Theme1 = new ColorTheme(MainPage.ForeGroundColors, MainPage.BackGroundColors);
    }
}
