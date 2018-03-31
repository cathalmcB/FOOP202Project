using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FOOP202Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] ComboOptions = { "Networking", "Database", "Internet", "Scams"};
        ObservableCollection<Entry> EntriesList = new ObservableCollection<Entry>();
        Networking Test1 = new Networking("Test", "http://www.facebook.com", "Test 1 Description");
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EntriesList.Add(Test1);
            LstBxMain.ItemsSource = EntriesList;
            CmboxFilter.ItemsSource = ComboOptions;
            CmboxFilter.SelectedIndex = 0;
        }

        private void LstBxMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Entry selectedItem = LstBxMain.SelectedItem as Entry;
            if (selectedItem != null)
            {
                LblName.Content = selectedItem.Name;
                LblType.Content = selectedItem.GetType();
                TxtBlckDesc.Text = selectedItem.Description;
                Img.Source = new BitmapImage(selectedItem.Image);

            }
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Entry selectedItem = LstBxMain.SelectedItem as Entry;
            if (selectedItem != null)
            {
                System.Diagnostics.Process.Start(selectedItem.Source);
            }
        }
    }
}
