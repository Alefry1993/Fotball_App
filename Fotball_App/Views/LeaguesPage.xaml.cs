using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Controls;

using Fotball_App.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Fotball_App.Views
{
    public sealed partial class LeaguesPage : Page
    {
        public LeaguesViewModel ViewModel { get; }

        public LeaguesPage()
        {
            ViewModel = Ioc.Default.GetService<LeaguesViewModel>();
            InitializeComponent();
        }

        private void OnViewStateChanged(object sender, ListDetailsViewState e)
        {
            if (e == ListDetailsViewState.Both)
            {
                ViewModel.EnsureItemSelected();
            }
        }
    }
}
