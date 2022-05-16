using Fotball_App.Core.Models;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Fotball_App.Views
{
    public sealed partial class TeamsDetailControl : UserControl
    {
        public SampleOrder ListDetailsMenuItem
        {
            get { return GetValue(ListDetailsMenuItemProperty) as SampleOrder; }
            set { SetValue(ListDetailsMenuItemProperty, value); }
        }

        public static readonly DependencyProperty ListDetailsMenuItemProperty = DependencyProperty.Register("ListDetailsMenuItem", typeof(SampleOrder), typeof(TeamsDetailControl), new PropertyMetadata(null, OnListDetailsMenuItemPropertyChanged));

        public TeamsDetailControl()
        {
            InitializeComponent();
        }

        private static void OnListDetailsMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as TeamsDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
