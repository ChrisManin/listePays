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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListePaysCapitales
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string ligne;
            Char caractere = ';';

            System.IO.StreamReader fichier = new System.IO.StreamReader(@"C:\Users\dell-optilex-3010\Documents\liste_pays.csv");

            while ((ligne = fichier.ReadLine()) != null)
            {
                String[] substrings = ligne.Split(caractere);
                lbCountry.Items.Add(substrings[0]);
                lbCity.Items.Add(substrings[1]);
            }

            fichier.Close();



        }

        private void lbCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbCountry.SelectedIndex > 0)
            {
                string selectedCountry = lbCountry.SelectedItem.ToString();
                tbCountry.Text = selectedCountry;
                int index = lbCountry.SelectedIndex;
                lbCity.SelectedIndex = index;
                string selectedCity = lbCity.SelectedItem.ToString();
                tbCity.Text = selectedCity;
            }

        }

        public bool verif(string item, ListBox lst)
        {
            foreach (string s in lst.Items)
            {
                if (item == s)
                {
                    bool verif = true;
                    return verif;
                }
            }
            return false;
        }


        private void btAjout_Click(object sender, RoutedEventArgs e)
        {
            if (!verif(tbCountry.Text.ToString(), lbCountry) && !verif(tbCity.Text.ToString(), lbCity))
            {
                lbCountry.Items.Add(tbCountry.Text.ToString());
                lbCity.Items.Add(tbCity.Text.ToString());
            }
        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            lbCountry.Items.Remove(lbCountry.SelectedItem);
            lbCity.Items.Remove(lbCity.SelectedItem);
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            System.IO.StreamWriter save = new System.IO.StreamWriter(@"C:\Users\dell-optilex-3010\Documents\liste_pays.csv");

            for(int i = 0; i < lbCountry.Items.Count; i++)
            {
                lbCountry.SelectedItem = lbCountry.Items[i];
                lbCity.SelectedItem = lbCity.Items[i];
                save.WriteLine(lbCountry.Items[i].ToString() + ";" + lbCity.Items[i].ToString());
            }
            save.Close();
        }
    }
}
