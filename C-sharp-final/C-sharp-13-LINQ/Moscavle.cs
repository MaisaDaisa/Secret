using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_13_LINQ
{
    // Moscavle კლასი შემდეგ ველებს შეიცავს: გვარი, კლასის ნომერი, საგანი, ქულა.
    internal class Moscavle
    {
        public string gvari;
        public int klasis_nomeri;
        public string sagani;
        public double qula;

        public Moscavle(string gvari, int klasis_nomeri, string sagani, double qula) {
            this.gvari = gvari;
            this.klasis_nomeri  = klasis_nomeri;
            this.sagani = sagani;
            this.qula = qula;

        }
    }
}
