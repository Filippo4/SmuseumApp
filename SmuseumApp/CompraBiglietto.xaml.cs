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
            if (nome == " " || cognome==" ")
            {
                MessageBox.Show("Non puoi lasciare questi campi liberi !", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            DateTime data = DateTime.Parse(dtp_data.Text);
            if(data < DateTime.Now)
            {
                MessageBox.Show("Non puoi prenotare il biglietto per una data antecedente a quella odierna!", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Warning);
            }else
            {
                Biglietto b = new Biglietto(vis, data, "online");
                vis.AddBiglietto(b);
                lsb_Prenotazioni.Items.Add($" {nome} {cognome}, {b.GetData().ToShortDateString()}, 5,00€");
            }
        }
    }
}