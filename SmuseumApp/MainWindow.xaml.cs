using ClassiSmuseum;
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

namespace SmuseumApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HashSet<String> emails = new HashSet<string>();
        List<Visitatore> visitatori = new List<Visitatore>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Registrati_Click(object sender, RoutedEventArgs e)
        {
            string email = txt_email.Text;
            string pass = txt_pass.Text;
            if (email != "" && pass != "")
            {
                if (emails.Contains(email))
                {
                    MessageBox.Show("l'email è gia stata usata!", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Visitatore v = new Visitatore(email, pass);
                    visitatori.Add(v);
                    emails.Add(email);
                    MessageBox.Show("Sei stato registrato correttamente!", "Informazione", MessageBoxButton.OK, MessageBoxImage.Information);
                    new CompraBiglietto(v).Show();
                    this.Close();
                }
            }
            else
                MessageBox.Show("Non sono stati inseriti dati!", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btn_Accedi_Click(object sender, RoutedEventArgs e)
        {
            string email = txt_email.Text;
            string pass = txt_pass.Text;
            if (email != "" && pass != "")
            {
                if (emails.Contains(email))
                {
                    for (int i = 0; i < visitatori.Count; i++)
                    {
                        if (email == visitatori[i].GetEmail())
                            if (pass == visitatori[i].GetPassword())
                            {
                                new CompraBiglietto(visitatori[i]).Show();
                                this.Close();
                            }
                            else
                                MessageBox.Show("la password non è corretta", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("l'email non è mai stata usata! Registrati!", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                MessageBox.Show("Non sono stati inseriti dati!", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Error);

        }
    }
}
