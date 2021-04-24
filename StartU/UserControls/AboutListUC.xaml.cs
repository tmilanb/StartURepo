using StartU.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace StartU.UserControls
{
    /// <summary>
    /// Interaction logic for AboutListUC.xaml
    /// </summary>
    public partial class AboutListUC : UserControl
    {
        public AboutListUC()
        {
            InitializeComponent();

            DataContext = new
            {
                list = ((MainWindow)Application.Current.MainWindow).ListCollection,
                model = new ListViewModel()
            };

            listViewItem.ItemsSource = ((MainWindow)Application.Current.MainWindow).ListCollection[0].ListOfTargets;
        }
    }
}
