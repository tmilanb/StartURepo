using StartU.Model;
using StartU.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace StartU.Logic
{
    public class Actions
    {
        #region BaseViewModel

        //// For BaseViewModel: 

        // Run the Process
        public static Process StartTheProcess(string target)
        {
            using (Process prc = new Process())
            {
                try
                {
                    prc.StartInfo.FileName = target;
                    prc.Start();
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("The file can not be found");
                }
                return prc;
            }
        }
        public void RunItems(ObservableCollection<ItemModel> obs, ObservableCollection<ListModel> obsL)
        {
            foreach (var item in obs)
            {
                if (item.ItemCheckBox.IsChecked == true)
                {
                    StartTheProcess(item.Target);
                }
            }

            foreach (var item in obsL)
            {
                if (item.ItemCheckBox.IsChecked == true)
                {
                    foreach (var target in item.ListOfTargets)
                    {
                        StartTheProcess(target);
                    }                    
                }
            }
        }

        // Remove the item from the collection
        public void RemoveItem(ObservableCollection<ItemModel> obsItem, ObservableCollection<ListModel> obsList, StackPanel sp1, StackPanel sp2)
        {
            // remove from the ItemCollection
            for (var i = 0; i < obsItem.Count; i++)
            {
                if (obsItem[i].ItemCheckBox.IsChecked == true)
                {
                    sp1.Children.Remove(obsItem[i].ItemCheckBox);
                    sp2.Children.Remove(obsItem[i].ItemButton);
                    obsItem.Remove(obsItem[i]);
                }
            }

            // remove from the ListCollection
            for (var i = 0; i < obsList.Count; i++)
            {
                if (obsList[i].ItemCheckBox.IsChecked == true)
                {
                    sp1.Children.Remove(obsList[i].ItemCheckBox);
                    sp2.Children.Remove(obsList[i].ItemButton);
                    obsList.Remove(obsList[i]);
                }
            }
        }

        #endregion

        #region ItemViewModel + ListViewModel

        //// For the ItemViewModel + ListViewModel

        /// <summary>
        /// Create the Models
        /// </summary>

        // Create the Item
        public void CreaItemModel(ObservableCollection<ItemModel> obs, string name, string target, StackPanel spCheckBox, StackPanel spButton)
        {
            var item = new ItemModel()
            {
                Name = name,
                Target = target
            };

            // Create the ItemCheckbox with Binding                        
            #region ItemCheckBox

            Binding checkBoxBinding = new Binding();
            checkBoxBinding.Source = item;
            checkBoxBinding.Path = new PropertyPath("Name");
            checkBoxBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(item.ItemCheckBox, CheckBox.ContentProperty, checkBoxBinding);
            #endregion

            // create the Button with the Command + Name Binding
            #region ItemButton
            Binding buttonCommandBinding = new Binding();
            buttonCommandBinding.Source = new ItemViewModel();
            buttonCommandBinding.Path = new PropertyPath("OpenAboutWindowCommand");
            BindingOperations.SetBinding(item.ItemButton, Button.CommandProperty, buttonCommandBinding);

            Binding buttonNameBinding = new Binding();
            buttonNameBinding.Source = item;
            buttonNameBinding.Path = new PropertyPath("Name");
            buttonNameBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(item.ItemButton, Button.NameProperty, buttonNameBinding);

            #endregion

            item.ItemButton.Click += ItemButton_ClickItemButton;

            // Add to the ItemViewModel.ObservableCollection
            obs.Add(item);

            // Add the UIElements to the StackPanels
            spCheckBox.Children.Add(item.ItemCheckBox);
            spButton.Children.Add(item.ItemButton);

        }
        // Event for the ItemButton to show ......
        private void ItemButton_ClickItemButton(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Name.ToString();
            int currentPosition = 0;

            for (int i = 0; i < ((MainWindow)Application.Current.MainWindow).ItemList.Count; i++)
            {
                if (((MainWindow)Application.Current.MainWindow).ItemList[i].Name == content)
                {
                    // move the current item to the 0. position of the collection 
                    // in order to bind the name + target of the item
                    currentPosition = ((MainWindow)Application.Current.MainWindow).ItemList.IndexOf(((MainWindow)Application.Current.MainWindow).ItemList[i]);
                    ((MainWindow)Application.Current.MainWindow).ItemList.Move(currentPosition, 0);
                }
            }
        }        

        // some other function for the part of creation of the List

        public void AddTargetToListView(ObservableCollection<string> obs, string target)
        {
            obs.Add(target);
        }

        public void AddTargetToNewListView(ObservableCollection<string> obs, string target)
        {
            obs.Add(target);
        }

        // Create the List
        public void CreateListModel(ObservableCollection<ListModel> obs, string name, StackPanel spCheckBox, StackPanel spButton)
        {
            var listModel = new ListModel()
            {
                Name = name,             
            };

            // Create the ItemCheckbox with Binding                        
            #region ItemCheckBox

            Binding checkBoxBinding = new Binding();
            checkBoxBinding.Source = listModel;
            checkBoxBinding.Path = new PropertyPath("Name");
            checkBoxBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(listModel.ItemCheckBox, CheckBox.ContentProperty, checkBoxBinding);
            #endregion

            // create the Button with the Command + Name Binding
            #region ItemButton
            Binding buttonCommandBinding = new Binding();
            buttonCommandBinding.Source = new ListViewModel();
            buttonCommandBinding.Path = new PropertyPath("OpenAboutWindowCommand");
            BindingOperations.SetBinding(listModel.ItemButton, Button.CommandProperty, buttonCommandBinding);

            Binding buttonNameBinding = new Binding();
            buttonNameBinding.Source = listModel;
            buttonNameBinding.Path = new PropertyPath("Name");
            buttonNameBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(listModel.ItemButton, Button.NameProperty, buttonNameBinding);

            #endregion

            // Add to the ListViewModel.ObservableCollection
            obs.Add(listModel);

            //// Add to the elements from the temporaryList to the ListOfTargets
            CreateTargetList(((MainWindow)Application.Current.MainWindow).temporaryListOfTargets, listModel.ListOfTargets);

            // create an event for button 
            listModel.ItemButton.Click += ItemButton_ClickListButton;

            // Add the UIElements to the StackPanels
            spCheckBox.Children.Add(listModel.ItemCheckBox);
            spButton.Children.Add(listModel.ItemButton);

        }

        private void ItemButton_ClickListButton(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Name.ToString();
            int currentPosition = 0;

            for (int i = 0; i < ((MainWindow)Application.Current.MainWindow).ListCollection.Count; i++)
            {
                if (((MainWindow)Application.Current.MainWindow).ListCollection[i].Name == content)
                {
                    // move the current item to the 0. position of the collection 
                    // in order to bind the name + target of the item
                    currentPosition = ((MainWindow)Application.Current.MainWindow).ListCollection.IndexOf(((MainWindow)Application.Current.MainWindow).ListCollection[i]);
                    ((MainWindow)Application.Current.MainWindow).ListCollection.Move(currentPosition, 0);
                }
            }
        }

        // Create the List of targets for the ItemModel
        public void CreateTargetList(ObservableCollection<string> obs, ObservableCollection<string> listOfTargets)
        {
            foreach (var item in obs)
            {
                listOfTargets.Add(item);
            }
        }

        #region Windows and UserControls
        /// <summary>
        /// Open the Windows + Usercontrols
        /// </summary>

        // Open the Window with the UserControl for add new Item to the list
        public void OpenAddWindow(Window win, UserControl uc)
        {
            win.Name = "OpenedWindow";
            win.Owner = Window.GetWindow(System.Windows.Application.Current.MainWindow);
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Add the usercontrol to the window
            win.Content = uc;
            win.ShowDialog();
        }

        // Open the Window with the UserControl for modifying of properties of the item
        public void OpenAboutWindow(Window win, UserControl uc)
        {
            win.Name = "OpenedWindow";
            win.Owner = Window.GetWindow(System.Windows.Application.Current.MainWindow);
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            win.Content = uc;
            win.ShowDialog();
        }

        /// <summary>
        /// Change the properties of the opened Models
        /// </summary>

        // Change the properties of the opened ItemModel
        public void ChangeTheItiemProps(string name, string target, ItemModel im)
        {
            im = ((MainWindow)Application.Current.MainWindow).ItemList[0];

            im.Name = name;
            im.Target = target;
            
        }

        // Change the properties of the opened ListModel
        public void ChangeTheListProps(string name, string target, ListModel im)
        {
            

        }

        #endregion

        #endregion
    }
}
