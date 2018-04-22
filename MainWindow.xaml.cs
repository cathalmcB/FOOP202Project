using Newtonsoft.Json;
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
        public EntryDBEntities db = new EntryDBEntities();
        public string[] ComboOptions = {"All", "Networking", "Database", "Internet", "Scams"};
        public ObservableCollection<AppEntry> EntriesList = new ObservableCollection<AppEntry>();
        ObservableCollection<AppEntry> FilteredList = new ObservableCollection<AppEntry>();
       
        
        //Networking Test1 = new Networking("Test", "http://www.facebook.com", "Test 1 Description");

        
        internal ObservableCollection<AppEntry> JsonList = new ObservableCollection<AppEntry>();
        internal ObservableCollection<AppEntry> JsonListAdd = new ObservableCollection<AppEntry>();


        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EntryDBAppCreator();
            //EntriesList.Add(Test1);
            LstBxMain.ItemsSource = EntriesList;
            CmboxFilter.ItemsSource = ComboOptions;
            CmboxFilter.SelectedIndex = 0;
        }

        private void LstBxMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AppEntry selectedItem = LstBxMain.SelectedItem as AppEntry;
            if (selectedItem != null)
            {
                LblName.Content = selectedItem.Name;
                LblType.Content = selectedItem.GetType().Name;
                TxtBlckDesc.Text = selectedItem.Description;
                Img.Source = new BitmapImage(selectedItem.Image);

            }
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppEntry selectedItem = LstBxMain.SelectedItem as AppEntry;
            if (selectedItem != null)
            {
                System.Diagnostics.Process.Start(selectedItem.Source);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEntry AE = new AddEntry();
            AE.Owner = this;
            AE.ShowDialog();
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {

            using (StreamReader r = new StreamReader(GetJsonFilePath()))
            {

                JsonSerializerSettings settings = new JsonSerializerSettings
                {

                    TypeNameHandling = TypeNameHandling.All

                };

                string json = r.ReadToEnd();

                JsonList = JsonConvert.DeserializeObject<ObservableCollection<AppEntry>>(json, settings);

                foreach (AppEntry element in JsonList)
                {
                    EntriesList.Add(element);
                    //JsonListAdd.Add(element); //Double check for increment add rather than complete list readd
                }
            }

            LstBxMain.ItemsSource = "";
            LstBxMain.ItemsSource = EntriesList;
        }


        public string GetJsonFilePath()
        {
            string jsonDirectory = "";
            string currentDir = Directory.GetCurrentDirectory();
            DirectoryInfo parent = Directory.GetParent(currentDir);
            DirectoryInfo grandParent = Directory.GetParent(parent.FullName);

            jsonDirectory = currentDir + "\\ListOfEntries.json";

            return jsonDirectory;
        }

        private void SaveAdditions_Click(object sender, RoutedEventArgs e)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            JsonList.Clear();
            using (StreamReader r = new StreamReader(GetJsonFilePath()))
            {
                string json = r.ReadToEnd();

                JsonList = JsonConvert.DeserializeObject<ObservableCollection<AppEntry>>(json, settings);

                foreach (AppEntry element in JsonList)
                {

                    JsonListAdd.Add(element); //Double check for increment add rather than complete list readd
                }
            }
            using (StreamWriter sw = new StreamWriter(GetJsonFilePath()))
            {
                string json = JsonConvert.SerializeObject(JsonListAdd, Formatting.Indented, settings);
                sw.Write(json);
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = TxtBxSearch.Text;
            FilteredList.Clear();
            foreach (AppEntry entry in EntriesList)
            {
                if (entry.Name.ToUpper().Contains(searchTerm.ToUpper()))
                {
                    FilteredList.Add(entry);
                }
                else
                {
                    foreach (string keyterm in entry.Keywords)
                    {
                        if (keyterm.ToUpper().Contains(searchTerm.ToUpper()))
                        {
                            FilteredList.Add(entry);
                            break;
                        }
                    }
                }
            }
            LstBxMain.ItemsSource = "";
            LstBxMain.ItemsSource = FilteredList;

        }

        private void CmboxFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = CmboxFilter.SelectedIndex;
            FilteredList.Clear();
            LstBxMain.ItemsSource = "";
            switch (selectedIndex)
            {
                case 0:
                    LstBxMain.ItemsSource = EntriesList;
                    break;
                case 1:
                    foreach(AppEntry entry in EntriesList)
                    {
                        if (entry.GetType().Equals(typeof(Networking)))
                        {
                            FilteredList.Add(entry);
                        }
                    }
                    LstBxMain.ItemsSource = FilteredList;
                    break;
                case 2:
                    foreach (AppEntry entry in EntriesList)
                    {
                        if (entry.GetType().Equals(typeof(Database)))
                        {
                            FilteredList.Add(entry);
                        }
                    }
                    LstBxMain.ItemsSource = FilteredList;
                    break;
                case 3:
                    foreach (AppEntry entry in EntriesList)
                    {
                        if (entry.GetType().Equals(typeof(Internet)))
                        {
                            FilteredList.Add(entry);
                        }
                    }
                    LstBxMain.ItemsSource = FilteredList;
                    break;
                case 4:
                    foreach (AppEntry entry in EntriesList)
                    {
                        if (entry.GetType().Equals(typeof(Scams)))
                        {
                            FilteredList.Add(entry);
                        }
                    }
                    LstBxMain.ItemsSource = FilteredList;
                    break;
            }

            
            
        }

        public void EntryDBAppCreator()
        {
            foreach(var e in db.Entries)
            {
                if (e.TypeTypeId == 1)
                {
                    EntriesList.Add(new Networking(e.Name, e.Source, e.Description, e.Keywords));
                }
                else if (e.TypeTypeId == 2)
                {
                    EntriesList.Add(new Database(e.Name, e.Source, e.Description, e.Keywords));
                }
                else if (e.TypeTypeId == 3)
                {
                    EntriesList.Add(new Internet(e.Name, e.Source, e.Description, e.Keywords));
                }
                else if (e.TypeTypeId ==4)
                {
                    EntriesList.Add(new Scams(e.Name, e.Source, e.Description, e.Keywords));
                }
                else
                {
                    EntriesList.Add(new AppEntry(e.Name, e.Source, e.Description, e.Keywords));
                }
            }



        }
    }
}
