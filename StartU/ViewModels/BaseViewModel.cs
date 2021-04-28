using StartU.Logic;
using StartU.Model;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml;

namespace StartU.ViewModels
{
    public class BaseViewModel
    {

        public ICommand RunProcessCommand { get; private set; }
        public ICommand RemoveItemCommand { get; private set; }
        public ICommand SaveItemsCommand { get; private set; }

        private readonly Actions _actions = new Actions();

        public BaseViewModel()
        {
            RunProcessCommand = new RelayCommand(RunItems);
            RemoveItemCommand = new RelayCommand(RemoveItem);
            SaveItemsCommand = new RelayCommand(Ser);
        }

        public void RunItems(object msg)
        {
            _actions.RunItems(((MainWindow)Application.Current.MainWindow).ItemList, ((MainWindow)Application.Current.MainWindow).ListCollection);
        }

        public void RemoveItem(object msg)
        {            
            _actions.RemoveItem(((MainWindow)Application.Current.MainWindow).ItemList, ((MainWindow)Application.Current.MainWindow).ListCollection, ((MainWindow)Application.Current.MainWindow).CheckBoxStackPanel, ((MainWindow)Application.Current.MainWindow).ButtonStackPanel);
        }

        // Under construction
        public void Ser(object msg)
        {
            string file = @"models.xaml";

            XmlWriterSettings settings = new XmlWriterSettings();

            using (XmlWriter writer = XmlWriter.Create(file, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("ItemModel");

                foreach (var item in ((MainWindow)Application.Current.MainWindow).ItemList)
                {
                    XamlWriter.Save(item, writer);
                }

                writer.WriteEndElement();
            }

            using (XmlWriter writer = XmlWriter.Create(file, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("ListModel");

                foreach (var item in ((MainWindow)Application.Current.MainWindow).ListCollection)
                {
                    XamlWriter.Save(item, writer);
                }

                writer.WriteEndElement();
            }
        }

        // Under construction
        public void Der()
        {
            StringReader sr = new StringReader("models.xaml");

            XmlReader reader = XmlReader.Create(sr);

            //Content = XamlReader.Load(File.OpenRead(@"\models.xaml"));

            ItemModel dynamicButton = (ItemModel)XamlReader.Load(reader);

            //stackPanel.Children.Add(dynamicButton.ItemCheckBox);

            reader.Close();
        }
    }
}
