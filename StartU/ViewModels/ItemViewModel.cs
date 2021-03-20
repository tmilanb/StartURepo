using StartU.Logic;
using StartU.Model;
using StartU.UserControls;
using StartU.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StartU.ViewModels
{

    public class ItemViewModel
    {
        // create the Commands
        public RelayCommand FirstCommandRelay { get; private set; }
        public RelayCommand CreateItemCommand { get; private set; }
        public ICommand RunProcessCommand { get; private set; }
        public ICommand OpenAddItemWindowCommand { get; private set; }
        public ICommand OpenAboutItemWindowCommand { get; private set; }
        
        // for methods
        private readonly Actions _actions = new Actions();

        public ItemViewModel()
        {
            Temp = new ObservableCollection<ItemModel>();
            RunProcessCommand = new RelayCommand(RunProcess);
            OpenAddItemWindowCommand = new RelayCommand(OpenAddItemWindow);
            OpenAboutItemWindowCommand = new RelayCommand(OpenAboutItemWindow);
            CreateItemCommand = new RelayCommand(CreateItem);
        }

        public ObservableCollection<ItemModel> Temp { get { return _listOfItems; } set { _listOfItems = value; OnPropertyChanged("ListOfItems"); } }

        private ObservableCollection<ItemModel> _listOfItems;
        public ObservableCollection<ItemModel> ListOfItems { get { return _listOfItems; } set { _listOfItems = value; OnPropertyChanged("ListOfItems"); } }

        #region Properties

        private ItemModel _itemmodel;
        public string Name
        {
            get { return _itemmodel.Name; }
            set { _itemmodel.Name = value; }
        }
        public string Target
        {
            get { return _itemmodel.Target; }
            set { _itemmodel.Target = value; }
        }

        public CheckBox ItemCheckBox => _itemmodel.ItemCheckBox = new CheckBox()
        {
            Margin = new Thickness(10, 10, 10, 10),
            Width = 160,
            Height = 30,
            FontSize = 16,
            HorizontalAlignment = HorizontalAlignment.Left,
        };

        public Button ItemButton => _itemmodel.ItemButton = new Button()
        {
            Margin = new Thickness(10, 5, 10, 15),
            Content = "Target",
            Width = 100,
            Height = 30,
            HorizontalAlignment = HorizontalAlignment.Right
        };

        #endregion                                                         

        /// <summary>                     
        /// Functions for the Commands
        /// </summary>
        /// <param name="parameter"></param>
        
        // Create the item with two parameters
        public void CreateItem(object parameter)
        {
            var data = parameter as object[];
            var name = data[0] as string;
            var target = data[1] as string;

            _actions.CreateItem(ListOfItems, name, target, ((MainWindow)Application.Current.MainWindow).CheckBoxStackPanel, ((MainWindow)Application.Current.MainWindow).ButtonStackPanel);

        }
        
        // Run the Process
        public void RunProcess(object msg)
        {
            //_actions.StartTheProcess();
            MessageBox.Show(ListOfItems.Count.ToString());
            //_actions.ShowProperties(ListOfItems);
        }

        // Open the window + uc in order to create and add new item
        public void OpenAddItemWindow(object msg)
        {
            AddItemWindow addItemWin = new AddItemWindow();
            AddItemUC addItemUC = new AddItemUC();
            _actions.OpenAddItemWindow(addItemWin, addItemUC);
        }

        // Open the window + uc in order to see and modify the values of the item
        public void OpenAboutItemWindow(object msg)
        {
            AboutItemWindow aboutItemWin = new AboutItemWindow();
            AboutItemUC aboutItemUC = new AboutItemUC();
            _actions.OpenAboutItemWindow(aboutItemWin, aboutItemUC);
            
        }




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
