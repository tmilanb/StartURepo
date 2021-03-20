using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;

namespace StartU.UserControls
{
    /// <summary>
    /// Interaction logic for AddItemUC.xaml
    /// </summary>
    public partial class AddItemUC : UserControl
    {
        public AddItemUC()
        {
            InitializeComponent();
        }

        private void BtnFileExplorer_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Filter = "All Files|*.*";
            Nullable<bool> dialogOK = fileDialog.ShowDialog();

            if (dialogOK == true)
            {
                string sfiles = "";

                foreach (string sfile in fileDialog.FileNames)
                {
                    sfiles += ";" + sfile;
                }

                sfiles = sfiles.Substring(1);

                textBoxTarget.Text = sfiles;
            }           

        }
    }
}
