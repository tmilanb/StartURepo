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
    public class ItemViewModel : BaseViewModel
    {
        #region Commands

        // create the Commands
        public RelayCommand CreaItemModelCommand { get; private set; }
        public ICommand OpenAboutWindowCommand { get; private set; }
        public ICommand OpenAddWindowCommand { get; private set; }
        public ICommand ChangeTheItemPropsCommand { get; private set; }

        #endregion

        // for the methods
        private readonly Actions _actions = new Actions();

        public ItemViewModel()
        {
            OpenAboutWindowCommand = new RelayCommand(OpenAboutWindow);
            CreaItemModelCommand = new RelayCommand(CreaItemModel);
            OpenAddWindowCommand = new RelayCommand(OpenAddWindow);
            ChangeTheItemPropsCommand = new RelayCommand(ChangeTheItemProps);
        }

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
        
        // Create the item with two parameters
        public void CreaItemModel(object parameter)
        {
            var data = parameter as object[];
            var name = data[0] as string;
            var target = data[1] as string;

            _actions.CreaItemModel(((MainWindow)Application.Current.MainWindow).ItemList, name, target, ((MainWindow)Application.Current.MainWindow).CheckBoxStackPanel, ((MainWindow)Application.Current.MainWindow).ButtonStackPanel);
        }

        // Change the properties of the opened ItemModel
        public void ChangeTheItemProps(object msg)
        {
            //AboutItemUC aboutItemUC = new AboutItemUC();
            //var item = new ItemModel();

            //_actions.ChangeTheItemProps(aboutItemUC.textBoxName.Text, aboutItemUC.textBoxTarget.Text, item);

            foreach (var a in ((MainWindow)Application.Current.MainWindow).ItemList)
            {
                Console.WriteLine(a.Name + a.Target + "\n-----------------");
            }
        }

        // Open the window + uc in order to create and add new item
        public void OpenAddWindow(object msg)
        {
            AddItemWindow addItemWin = new AddItemWindow();
            AddItemUC addItemUC = new AddItemUC();
            _actions.OpenAddWindow(addItemWin, addItemUC);
        }
         
        // Open the window + uc in order to see and modify the values of the item
        public void OpenAboutWindow(object msg)
        {
            AboutItemWindow aboutItemWin = new AboutItemWindow();
            AboutItemUC aboutItemUC = new AboutItemUC();
            _actions.OpenAboutWindow(aboutItemWin, aboutItemUC);            
        }


    }
}
