using Fotball_App.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;

namespace Fotball_App.Views
{
    public sealed partial class TeamsDetailControl : UserControl
    {

        public TeamEditViewModel ListDetailsMenuItem
        {
            get { return GetValue(ListDetailsMenuItemProperty) as TeamEditViewModel; }
            set { SetValue(ListDetailsMenuItemProperty, value); }
        }

        public static readonly DependencyProperty ListDetailsMenuItemProperty = DependencyProperty.Register("ListDetailsMenuItem", typeof(TeamEditViewModel), typeof(TeamsDetailControl), new PropertyMetadata(null, OnListDetailsMenuItemPropertyChanged));

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
