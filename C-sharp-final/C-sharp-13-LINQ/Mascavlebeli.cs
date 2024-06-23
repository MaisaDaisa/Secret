using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_13_LINQ
{
    // Mascavlebeli კლასი შემდეგ ველებს შეიცავს: გვარი, საგანი, ხელფასი.
    internal class Mascavlebeli
    {
        public string gvari;
        public string sagani;
        public double xelfasi;
        public Mascavlebeli(string gvari, string sagani, double xelfasi) {
            this.gvari = gvari;
            this.sagani = sagani;
            this.xelfasi = xelfasi;
        }
    }
}
