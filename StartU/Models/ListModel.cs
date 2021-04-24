using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace StartU.Model
{
    public class ListModel : INotifyPropertyChanged
    {
        private string name;
        private ObservableCollection<string> listOfTargets = new ObservableCollection<string>();

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public ObservableCollection<string> ListOfTargets
        {
            get { return listOfTargets; }
            set
            {
                value = listOfTargets;
                OnPropertyChanged("ListOfTargets");
            }
        }

        public CheckBox ItemCheckBox { get; set; } = new CheckBox()
        {
            Margin = new Thickness(10, 10, 10, 10),
            Width = 160,
            Height = 30,
            FontSize = 16,
            HorizontalAlignment = HorizontalAlignment.Left,
            Style = null
        };

        public Button ItemButton { get; set; } = new Button()
        {
            Margin = new Thickness(10, 5, 10, 15),
            Content = "Paths",
            Width = 100,
            Height = 30,
            HorizontalAlignment = HorizontalAlignment.Right
        };

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
