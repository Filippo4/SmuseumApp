using ClassiSmuseum;
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

namespace SmuseumApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> emails = new List<string>();
        private List<string> passwords = new List<string>();
        Visitatore v;
        List<Visitatore> visitatori = new List<Visitatore>();
        public MainWindow()
        {
            InitializeComponent();

            using (StreamReader sr = new StreamReader("fileAccounts.txt", Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    emails.Add(line);
                }
            }
            using (StreamReader sr = new StreamReader("filePasswords.txt", Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    passwords.Add(line);
                }
            }
        }

        private void btn_Registrati_Click(object sender, RoutedEventArgs e)
        {
            string email = txt_email.Text;
            string pass = txt_pass.Text;
            if (email != "" && pass != "")
            {
                if (IsValidEmail(email) == true)
                {
                    if (emails.Contains(email))
                    {
                        MessageBox.Show("l'email è gia stata registata!", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {

                        Visitatore v = new Visitatore(email, pass);
                        visitatori.Add(v);
                        emails.Add(email);
                        passwords.Add(pass);
                        MessageBox.Show("Sei stato registrato correttamente!", "Informazione", MessageBoxButton.OK, MessageBoxImage.Information);

                        using (StreamWriter sw = new StreamWriter("fileAccounts.txt", true, Encoding.UTF8))
                        {

                            sw.WriteLine(email);

                        }

                        using (StreamWriter sw = new StreamWriter("filePasswords.txt", true, Encoding.UTF8))
                        {

                            sw.WriteLine(pass);

                        }

                        new CompraBiglietto(v).Show();
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("l'email non è valida", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Error);

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
                if (IsValidEmail(email) == true)
                {
                    for (int i = 0; i < emails.Count; i++)
                    {
                        if (emails[i].Contains(email) && passwords[i].Contains(pass))
                        {
                            new CompraBiglietto(v).Show();
                            this.Close();

                        }
                    }

                }
                else
                    MessageBox.Show("l'email non è valida", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
                MessageBox.Show("Non sono stati inseriti dati!", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
