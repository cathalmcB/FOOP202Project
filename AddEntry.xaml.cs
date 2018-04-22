using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;

namespace FOOP202Project
{
    /// <summary>
    /// Interaction logic for AddEntry.xaml
    /// </summary>
    public partial class AddEntry : Window
    {
        string[] ComboOptions = {"Networking","Database","Internet", "Scams" };
        List<string> keywords = new List<string>();
        string[] keywordsArray;

        public AddEntry()
        {
            InitializeComponent();
            CmbxType.ItemsSource = ComboOptions;
           
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = Owner as MainWindow;
            int choosenType = CmbxType.SelectedIndex;

            if (CmbxType.SelectedValue != null)
            {
               
                switch (choosenType)
                {

                    case 0:
                        //keywordsArray = TxtBxKeywords.Text.Split(',');
                        //for (int i = 0; i < keywordsArray.Length; i++)
                        //{
                        //    keywords.Add(keywordsArray[i].ToLower());
                        //}
                        
                        //keywords.Add("networking");
                        
                        main.EntriesList.Add(new Networking(TxtBxName.Text, TxtBxSource.Text, TxtBxDesc.Text, TxtBxKeywords.Text));
                        main.JsonListAdd.Add(new Networking(TxtBxName.Text, TxtBxSource.Text, TxtBxDesc.Text, TxtBxKeywords.Text));
                        break;
                    case 1:
                        //keywordsArray = TxtBxKeywords.Text.Split(',');
                        //for (int i = 0; i < keywordsArray.Length; i++)
                        //{
                        //    keywords.Add(keywordsArray[i].ToLower());
                        //}

                        //keywords.Add("database");
                        

                        main.EntriesList.Add(new Database(TxtBxName.Text, TxtBxSource.Text, TxtBxDesc.Text, TxtBxKeywords.Text));
                        main.JsonListAdd.Add(new Database(TxtBxName.Text, TxtBxSource.Text, TxtBxDesc.Text, TxtBxKeywords.Text));
                        break;
                    case 2:
                        //keywordsArray = TxtBxKeywords.Text.Split(',');
                        //for (int i = 0; i < keywordsArray.Length; i++)
                        //{
                        //    keywords.Add(keywordsArray[i].ToLower());
                        //}

                        //keywords.Add("internet");
                        main.EntriesList.Add(new Internet(TxtBxName.Text, TxtBxSource.Text, TxtBxDesc.Text, TxtBxKeywords.Text));
                        main.JsonListAdd.Add(new Internet(TxtBxName.Text, TxtBxSource.Text, TxtBxDesc.Text, TxtBxKeywords.Text));
                        break;
                    case 3:
                        //keywordsArray = TxtBxKeywords.Text.Split(',');
                        //for (int i = 0; i < keywordsArray.Length; i++)
                        //{
                        //    keywords.Add(keywordsArray[i].ToLower());
                        //}

                        //keywords.Add("scams");
                        main.EntriesList.Add(new Scams(TxtBxName.Text, TxtBxSource.Text, TxtBxDesc.Text, TxtBxKeywords.Text));
                        main.JsonListAdd.Add(new Scams(TxtBxName.Text, TxtBxSource.Text, TxtBxDesc.Text, TxtBxKeywords.Text));
                        break;

                }

                
            }

            this.Close();
        }
            

        private void CmbxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

