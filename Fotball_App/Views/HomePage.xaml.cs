using CommunityToolkit.Mvvm.DependencyInjection;

using Fotball_App.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Fotball_App.Views
{
    public sealed partial class HomePage : Page
    {
        public HomeViewModel ViewModel { get; }

        public HomePage()
        {
            ViewModel = Ioc.Default.GetService<HomeViewModel>();
            InitializeComponent();
        }
    }
}
