using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerDerTest.ItemModel
{
    [Serializable()]
    public class Model : ISerializable
    {
        private string name;
        private string target;
        private bool isChecked;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Target
        {
            get { return target; }
            set
            {
                target = value;
                OnPropertyChanged("Target");
            }
        }
        public bool IsChecked
        {
            get { return isChecked = true; }
            set
            {
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }
        

        //public CheckBox ItemCheckBox { get; set; } = new CheckBox()
        //{
        //    Margin = new Thickness(10, 10, 10, 10),
        //    Width = 160,
        //    Height = 30,
        //    FontSize = 16,
        //    HorizontalAlignment = HorizontalAlignment.Left,
        //    Style = null
        //};

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Target", Target);
            info.AddValue("IsChecked", IsChecked);
        }

        //public Model(SerializationInfo info, StreamingContext context)
        //{
        //    Name = (string)info.GetValue("Name", typeof(string));
        //    Target = (string)info.GetValue("Target", typeof(string));
        //    IsChecked = (bool)info.GetValue("IsChecked", typeof(bool));
        //}


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
