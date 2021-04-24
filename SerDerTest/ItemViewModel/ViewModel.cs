using SerDerTest.ItemModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerDerTest.ItemViewModel
{

    public class ViewModel
    {
        private Model _itemmodel;
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

        public bool IsChecked
        {
            get { return _itemmodel.IsChecked; }
            set
            {
                _itemmodel.IsChecked = value;
            }
        }

        //public CheckBox ItemCheckBox => _itemmodel.ItemCheckBox = new CheckBox()
        //{
        //    Margin = new Thickness(10, 10, 10, 10),
        //    Width = 160,
        //    Height = 30,
        //    FontSize = 16,
        //    HorizontalAlignment = HorizontalAlignment.Left,
        //};



    }
}
