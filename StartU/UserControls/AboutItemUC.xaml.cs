using Microsoft.Win32;
using StartU.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace StartU.UserControls
{
    /// <summary>
    /// Interaction logic for AboutItemUC.xaml
    /// </summary>
    public partial class AboutItemUC : UserControl
    {
        public AboutItemUC()
        {
            InitializeComponent();
            DataContext = new ItemViewModel();
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
