using Fotball_App.Core.Models;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Fotball_App.Views
{
    public sealed partial class LeaguesDetailControl : UserControl
    {
        public SampleOrder ListDetailsMenuItem
        {
            get { return GetValue(ListDetailsMenuItemProperty) as SampleOrder; }
            set { SetValue(ListDetailsMenuItemProperty, value); }
        }

        public static readonly DependencyProperty ListDetailsMenuItemProperty = DependencyProperty.Register("ListDetailsMenuItem", typeof(SampleOrder), typeof(LeaguesDetailControl), new PropertyMetadata(null, OnListDetailsMenuItemPropertyChanged));

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
