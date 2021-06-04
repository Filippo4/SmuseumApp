using System;
using System.Collections.Generic;

namespace ClassiSmuseum
{
    public class Visitatore
    {
        public string email { get; private set; }
        public string password { get; private set; }
        public string nome { get; set;}
        public string cognome { get; set; }

        public List<Biglietto> biglietti = new List<Biglietto>();
        public Visitatore(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public string GetEmail()
        {
            return email;
        }

        public string GetPassword()
        {
            return password;
        }
        public void AddBiglietto(Biglietto b)
        {
            biglietti.Add(b);
        }
        public List<Biglietto> GetBiglietti()
        {
            return biglietti;
        }
        public string GetNome()
        {
            return nome;
        }
        public void SetNome( string n)
        {
            nome = n;
        }
        public string GetCognome()
        {
            return cognome;
        }
        public void SetCognome(string c)
        {
            cognome = c;
        }
    }
}
