using CommandTestProject.Model;
using CommandTestProject.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace CommandTestProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }


        private ObservableCollection<List<ItemModel>> listoflist = new ObservableCollection<List<ItemModel>>();
        public ObservableCollection<List<ItemModel>> ListOfList { get { return listoflist; } set { listoflist = value; OnPropertyChanged("ListOfList"); } }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected internal void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
