using Microsoft.Win32;
using StartU.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace StartU.UserControls
{
    /// <summary>
    /// Interaction logic for AboutItemUC.xaml
    /// </summary>
    public partial class AboutItemUC : UserControl
    {
        public AboutItemUC()
        {
            InitializeComponent();
            DataContext = new
            {
                list = ((MainWindow)Application.Current.MainWindow).ItemList,
                model = new ItemViewModel()
            };
        }
    }
}
