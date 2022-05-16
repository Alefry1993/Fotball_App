using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Controls;

using Fotball_App.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Fotball_App.Views
{
    public sealed partial class PlayersPage : Page
    {
        public PlayersViewModel ViewModel { get; }

        public PlayersPage()
        {
            ViewModel = Ioc.Default.GetService<PlayersViewModel>();
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
