using StartU.ViewModels;
using System.Windows;

namespace StartU
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ItemViewModel();
        }
    }
}
