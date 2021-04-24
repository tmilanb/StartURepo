using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using SerDerTest.ItemModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace SerDerTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        public ObservableCollection<CheckBox> chbs = new ObservableCollection<CheckBox>();
        public ObservableCollection<Button> btns = new ObservableCollection<Button>();
        public ObservableCollection<Model> models = new ObservableCollection<Model>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            Button btn = new Button()
            {
                Width = 30,
                Height = 30,
                Content = "test"
            };
            btns.Add(btn);
            stackPanel.Children.Add(btn);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            var m = new Model()
            {
                Name = "Test",
                Target = "target",
                IsChecked = true
            };

            if (m.IsChecked == true)
            {
                CheckBox chb = new CheckBox();
                chb.Content = m.Name;

                stackPanel.Children.Add(chb);
                chbs.Add(chb);
            }

            models.Add(m);
        }

        public void PartSeri()
        {
            //XmlSerializer seri = new XmlSerializer(typeof(Model));
            //using (TextWriter tw = new StreamWriter(@"C:\Users\z003x60a\Desktop\Development\C#\Practice"))
            //{
            //    seri.Serialize(tw, ml);
            //}
            //ml = null;

            // deserializer

            //TextReader reader = new StreamReader(@"C:\Users\z003x60a\Desktop\Development\C#\Practice");
            //object obj = deseri.Deserialize(reader);
            //ml = (Model)obj;
            //reader.Close();
            string file = @"C:\Users\z003x60a\Desktop\Development\C#\Practice\models.xml";

            if (File.Exists(file))
            {
                XmlSerializer deseri = new XmlSerializer(typeof(ObservableCollection<Model>));
                using (FileStream fs = File.OpenRead(@"C:\Users\z003x60a\Desktop\Development\C#\Practice\models.xml"))
                {
                    models = (ObservableCollection<Model>)deseri.Deserialize(fs);
                }
            }
            else
            {
                File.Create(file);
            }

            //XmlSerializer deseri = new XmlSerializer(typeof(ObservableCollection<Model>));
            //using (FileStream fs = File.OpenRead(@"C:\Users\z003x60a\Desktop\Development\C#\Practice\models.xml"))
            //{
            //    models = (ObservableCollection<Model>)deseri.Deserialize(fs);
            //}


        }

        private void SerBtn_Click(object sender, RoutedEventArgs e)
        { 
            using (Stream sr = new FileStream(@"C:\Users\z003x60a\Desktop\Development\C#\Practice\models.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer seri = new XmlSerializer(typeof(ObservableCollection<Model>));
                seri.Serialize(sr, models);
            }
            models = null;

        }

        private void DerBtn_Click(object sender, RoutedEventArgs e)
        {
            PartSeri();
        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HelloMesageBoxTest");
        }
    }
}
