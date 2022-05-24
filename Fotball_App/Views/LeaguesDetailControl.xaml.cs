using Fotball_App.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Fotball_App.Views
{
    public sealed partial class LeaguesDetailControl : UserControl
    {
        public LeagueEditViewModel ListDetailsMenuItem
        {
            get { return GetValue(ListDetailsMenuItemProperty) as LeagueEditViewModel; }
            set { SetValue(ListDetailsMenuItemProperty, value); }
        }

        public static readonly DependencyProperty ListDetailsMenuItemProperty = DependencyProperty.Register("ListDetailsMenuItem", typeof(LeagueEditViewModel), typeof(LeaguesDetailControl), new PropertyMetadata(null, OnListDetailsMenuItemPropertyChanged));

        public LeaguesDetailControl()
        {
            InitializeComponent();
        }

        private static void OnListDetailsMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as LeaguesDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
