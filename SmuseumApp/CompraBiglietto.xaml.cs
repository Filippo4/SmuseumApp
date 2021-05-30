using ClassiSmuseum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SmuseumApp
{
    /// <summary>
    /// Logica di interazione per CompraBiglietto.xaml
    /// </summary>
    public partial class CompraBiglietto : Window
    {
        public static Visitatore vis;

        public CompraBiglietto(Visitatore v)
        {
            InitializeComponent();
            vis = v;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nome = txt_nome.Text;
            string cognome = txt_cognome.Text;
            DateTime data = DateTime.Parse(dtp_data.Text);
            Biglietto b = new Biglietto(vis, data, "online");
            vis.AddBiglietto(b);
            //for(int i =0;i<vis.biglietti.Count;i++)
            foreach (Biglietto b1 in vis.GetBiglietti())
            {
                lsb_Prenotazioni.Items.Add($"{nome} {cognome} {data}");
            }

        }
    }
}
