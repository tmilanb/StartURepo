using StartU.Model;
using StartU.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace StartU.Logic
{
    public class Actions
    {
        // Create the Item
        public void CreateItem(ObservableCollection<ItemModel> obs, string name, string target, StackPanel spCheckBox, StackPanel spButton)
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
            buttonCommandBinding.Path = new PropertyPath("OpenAboutItemWindowCommand");
            BindingOperations.SetBinding(item.ItemButton, Button.CommandProperty, buttonCommandBinding);

            Binding buttonNameBinding = new Binding();
            buttonNameBinding.Source = item;
            buttonNameBinding.Path = new PropertyPath("Name");
            buttonNameBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(item.ItemButton, Button.NameProperty, buttonNameBinding);

            #endregion

            // Add to the ItemViewModel.ObservableCollection
            obs.Add(item);

            // Add the UIElements to the StackPanels
            spCheckBox.Children.Add(item.ItemCheckBox);
            spButton.Children.Add(item.ItemButton);

        }

        // Run the Process
        public Process StartTheProcess()
        {
            using (Process prc = new Process())
            {
                try
                {
                    string fileName = @"C:\Users\z003x60a\Desktop\Development\C#\MemoryAllocation1.jpg";
                    prc.StartInfo.FileName = fileName;
                    prc.Start();
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("The file can not be found");
                }
                return prc;
            }
        }

        // Open the Window with the UserControl for add new Item to the list
        public void OpenAddItemWindow(Window win, UserControl uc)
        {
            win.Name = "OpenedWindow";
            win.Owner = Window.GetWindow(System.Windows.Application.Current.MainWindow);
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Add the usercontrol to the window
            win.Content = uc;

            win.ShowDialog();
        }

        // Open the Window with the UserControl for modifying of properties of the item
        public void OpenAboutItemWindow(Window win, UserControl uc)
        {
            win.Name = "OpenedWindow";
            win.Owner = Window.GetWindow(System.Windows.Application.Current.MainWindow);
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            

            win.Content = uc;
            win.ShowDialog();
        }

        // Show the properties of the Item
        public void ShowProperties(ObservableCollection<ItemModel> obs)
        {
            foreach (var item in obs)
            {
                Console.WriteLine(item.Target);
            }
        }
       
    }
}
