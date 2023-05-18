using System;
using System.Collections.Generic;
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

namespace WpfKektura
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Szakasz> szakaszok = new();

        public MainWindow()
        {
            InitializeComponent();
            szakaszok = File.ReadAllLines("kektura.txt").Select(x => new Szakasz(x)).ToList();
            dgSzakaszok.ItemsSource = szakaszok;
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Convert.ToString(szakaszok.Count));
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            int maxIdo = Convert.ToInt32(txt6.Text);
            List<Szakasz> szurtSzakaszok = szakaszok.Where(x => x.Ido <= maxIdo).ToList();
            dgSzakaszok.ItemsSource = szurtSzakaszok;
            lbl6.Content = szurtSzakaszok.Count;
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Math.Round(szakaszok.Where(x => x.Leiras.Contains("Pilis")).Average(x => x.Ido)) + " perc");
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            Szakasz leghosszabb = szakaszok.Find(x => x.Tavolsag == szakaszok.Max(x => x.Tavolsag));
            MessageBox.Show($"{leghosszabb.Leiras}\n{leghosszabb.Tavolsag} km\n{leghosszabb.Ido} perc");
        }

        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllLines("utvonal.txt", szakaszok.Select(x => $"{x.Leiras},{x.Tavolsag},{x.Magassag},{x.Nehezseg()}"));
        }
    }
}
