using StartU.Model;
using StartU.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

            DataContext = new
            {
                ItemList,
                ListCollection,
                itemViewModel = new ItemViewModel(),
                listViewModel = new ListViewModel()
            };         
        }

        // Temporary list for the 
        public ObservableCollection<string> temporaryListOfTargets = new ObservableCollection<string>();

        #region Collections

        // Collection for the items
        private ObservableCollection<ItemModel> itemList = new ObservableCollection<ItemModel>();
        public ObservableCollection<ItemModel> ItemList { get { return itemList; } set { itemList = value; OnPropertyChanged("ItemList"); } }

        // Collection for the lists
        private ObservableCollection<ListModel> listCollection = new ObservableCollection<ListModel>();
        public ObservableCollection<ListModel> ListCollection { get { return listCollection; } set { listCollection = value; OnPropertyChanged("ListCollection"); } }

        #endregion

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
