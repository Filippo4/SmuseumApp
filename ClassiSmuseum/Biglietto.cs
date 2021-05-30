using System;
using System.Collections.Generic;
using System.Text;

namespace ClassiSmuseum
{
    public class Biglietto
    {
        public Visitatore v { get; set; }
        public DateTime data { get; set; }
        public string formato { get; set; }

        public Biglietto(Visitatore v, DateTime data, string formato)
        {
            this.v = v;
            this.data = data;
            this.formato = formato;
        }
        public Visitatore GetVisitatore()
        {
            return v;
        }
        public DateTime GetData()
        {
            return data;
        }

    }
}
