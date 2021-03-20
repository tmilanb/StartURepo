using CommandTestProject.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CommandTestProject.ViewModels
{
    public class ViewModel
    {
        // public string Name { get; set; }

        public Actions DisplayMCommand { get; private set; }

        public ViewModel()
        {
            DisplayMCommand = new Actions(DisplayM);
        }

        public void DisplayM(object m)
        {
            var data = m as object[];
            var d1 = data[0] as string;
            var d2 = data[1] as string;
            MessageBox.Show($"{d1} and the other is the {d2}");
        }
    }
}
