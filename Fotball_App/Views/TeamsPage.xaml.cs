using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Controls;

using Fotball_App.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Fotball_App.Views
{
    public sealed partial class TeamsPage : Page
    {
        public TeamsViewModel ViewModel { get; }

        public TeamsPage()
        {
            ViewModel = Ioc.Default.GetService<TeamsViewModel>();
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
