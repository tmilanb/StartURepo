using StartU.Logic;
using StartU.Model;
using StartU.UserControls;
using StartU.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace StartU.ViewModels
{
    public class BaseViewModel
    {

        public ICommand RunProcessCommand { get; private set; }

        public ICommand RemoveItemCommand { get; private set; }

        private readonly Actions _actions = new Actions();

        public BaseViewModel()
        {
            Lista = new ObservableCollection<ItemModel>();
            RunProcessCommand = new RelayCommand(RunItems);
            RemoveItemCommand = new RelayCommand(RemoveItem);
        }

        public void RunItems(object msg)
        {
            MessageBox.Show("Run");
            _actions.RunItems(((MainWindow)Application.Current.MainWindow).ItemList);
        }

        public void RemoveItem(object msg)
        {
            foreach (var a in ((MainWindow)Application.Current.MainWindow).ItemList)
            {
                Console.WriteLine(a.Name + " " + a.Target + "\n-----------------");
            }

            _actions.RemoveItem(((MainWindow)Application.Current.MainWindow).ItemList, ((MainWindow)Application.Current.MainWindow).ListCollection, ((MainWindow)Application.Current.MainWindow).CheckBoxStackPanel, ((MainWindow)Application.Current.MainWindow).ButtonStackPanel);

            foreach (var a in ((MainWindow)Application.Current.MainWindow).ItemList)
            {
                Console.WriteLine(a.Name + " " + a.Target + "\n-----------------");
            }
        }



        private ObservableCollection<ItemModel> _lista;
        public ObservableCollection<ItemModel> Lista { get { return _lista; } set { _lista = value; } }
    }
}
