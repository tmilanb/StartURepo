using StartU.Logic;
using StartU.Model;
using StartU.UserControls;
using StartU.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StartU.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        #region Commands

        public RelayCommand CreateListCommand { get; private set; }
        public ICommand OpenAboutWindowCommand { get; private set; }
        public ICommand OpenAddWindowCommand { get; private set; }
        public ICommand AddTargetToListViewCommand { get; private set; }
        public ICommand AddTargetToNewListViewCommand { get; private set; }
        public ICommand CreateListModelCommand { get; private set; }


        // other way to implement ICommand
        private ICommand _removeTargetFromListCommand;
        public ICommand RemoveTargetFromListCommand
        {
            get
            {
                return _removeTargetFromListCommand ?? (_removeTargetFromListCommand = new RelayCommand(x =>
                {
                    RemoveTargetFromList(x as string);
                }));
            }
        }

        private ICommand _removeTargetFromNewListCommand;
        public ICommand RemoveTargetFromNewListCommand
        {
            get
            {
                return _removeTargetFromNewListCommand ?? (_removeTargetFromNewListCommand = new RelayCommand(x =>
                {
                    RemoveTargetFromNewList(x as string);
                }));
            }
        }

        #endregion

        // for the methods
        private readonly Actions _actions = new Actions();

        public ListViewModel()
        {
            OpenAboutWindowCommand = new RelayCommand(OpenAboutWindow);
            OpenAddWindowCommand = new RelayCommand(OpenAddWindow);
            AddTargetToListViewCommand = new RelayCommand(AddTargetToListView);
            AddTargetToNewListViewCommand = new RelayCommand(AddTargetToNewListView);
            CreateListModelCommand = new RelayCommand(CreateListModel);
        }

        #region Properties

        private ListModel _listmodel;

        public string Name
        {
            get { return _listmodel.Name; }
            set { _listmodel.Name = value; }
        }
        public ObservableCollection<string> ListOfTargets
        {
            get { return _listmodel.ListOfTargets; }
            set { _listmodel.ListOfTargets = value; }
        }

        public CheckBox ItemCheckBox => _listmodel.ItemCheckBox = new CheckBox()
        {
            Margin = new Thickness(10, 10, 10, 10),
            Width = 160,
            Height = 30,
            FontSize = 16,
            HorizontalAlignment = HorizontalAlignment.Left,
        };

        public Button ItemButton => _listmodel.ItemButton = new Button()
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
        public void CreateListModel(object parameter)
        {
            var data = parameter as object[];
            var name = data[0] as string;

            _actions.CreateListModel(((MainWindow)Application.Current.MainWindow).ListCollection, name, ((MainWindow)Application.Current.MainWindow).CheckBoxStackPanel, ((MainWindow)Application.Current.MainWindow).ButtonStackPanel);

            ((MainWindow)Application.Current.MainWindow).temporaryListOfTargets.Clear();
        }

        public void AddTargetToListView(object parameter)
        {
            var data = parameter as object[];
            var target = data[0] as string;

            _actions.AddTargetToListView(((MainWindow)Application.Current.MainWindow).temporaryListOfTargets, target);
        }

        public void AddTargetToNewListView(object parameter)
        {
            var data = parameter as object[];
            var target = data[0] as string;

            _actions.AddTargetToNewListView(((MainWindow)Application.Current.MainWindow).ListCollection[0].ListOfTargets, target);

        }

        // Remove the item from the ListViewes
        public void RemoveTargetFromList(object msg)
        {
            ((MainWindow)Application.Current.MainWindow).temporaryListOfTargets.Remove(msg as string);
        }
        public void RemoveTargetFromNewList(object msg)
        {
            ((MainWindow)Application.Current.MainWindow).ListCollection[0].ListOfTargets.Remove(msg as string);
        }

        // Open the window + uc in order to create and add new item
        public void OpenAddWindow(object msg)
        {
            AddListWindow addListWin = new AddListWindow();
            AddListUC addListUC = new AddListUC();
            _actions.OpenAddWindow(addListWin, addListUC);
        }

        // Open the window + uc in order to see and modify the values of the item
        public void OpenAboutWindow(object msg)
        {
            AboutListWindow aboutListWin = new AboutListWindow();
            AboutListUC aboutListUC = new AboutListUC();
            _actions.OpenAboutWindow(aboutListWin, aboutListUC);
        }



    }
}
