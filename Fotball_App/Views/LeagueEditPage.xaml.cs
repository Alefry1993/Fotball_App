using Fotball_App.ViewModels;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fotball_App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LeagueEditPage : Page
    {
        public LeagueEditViewModel LeagueEditViewModel { get; }

        public LeagueEditPage(LeagueEditViewModel viewModel)
        {
            LeagueEditViewModel = viewModel;
            this.InitializeComponent();
        }
    }
}
