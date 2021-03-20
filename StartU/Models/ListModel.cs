using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace StartU.Model
{
    public class ListModel
    {
        public string Name { get; set; }

        public string Target { get; set; }

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

        public List<string> ListOfTargets { get; set; } = new List<string>();

    }
}
