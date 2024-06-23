using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 
1.1. შექმენით ინტერფეისი, რომელიც ორ მეთოდს შეიცავს. I მეთოდი გამოთვლის და
აბრუნებს პარამეტრის კვადრატს, II კი - პარამეტრის კუბს. მოახდინეთ ამ ინტერფეისის
რეალიზება.
1.2. შექმენით ინტერფეისი, რომელიც ერთ თვისებას შეიცავს. თვისება პრივატულ ცვლადს ლუწ
მნიშვნელობებს ანიჭებს. მოახდინეთ ამ ინტერფეისის რეალიზება.
1.3. შექმენით ინტერფეისი, რომელიც ერთ ინდექსატორს შეიცავს. ინდექსატორი 5 მთელ
რიცხვთან მუშაობს, ანიჭებს მათ კენტ მნიშვნელობებს და გასცემს მათ მნიშვნელობებს.
მოახდინეთ ამ ინტერფეისის რეალიზება.
1.4. შექმენით ინტერფეისი, რომელიც ერთ მოვლენას შეიცავს. მოვლენა აღიძვრება მაშინ, როცა
ერთგანზომილებიანი მასივის მაქსიმალური ელემენტი 25-ს გადააჭარბებს. მოახდინეთ ამ
ინტერფეისის რეალიზება.
1.5. შექმენით ინტერფეისი, რომელიც ერთ მეთოდს შეიცავს. მეთოდი გამოთვლის და აბრუნებს
პარამეტრის კუბს; შეიცავს ერთ თვისებას, რომელიც პრივატულ ცვლადს დადებით
მნიშვნელობებს ანიჭებს; შეიცავს ერთ ინდექსატორს, რომელიც 4 მთელ რიცხვთან მუშაობს და
ანიჭებს მათ 7-ის ჯერად მნიშვნელობებს; შეიცავს ერთ მოვლენას, რომელიც აღიძვრება მაშინ,
როცა ერთგანზომილებიანი მასივის მინიმალური ელემენტი იქნება 10-ზე ნაკლები.
*/

namespace C_sharp_9_interface
{

    // 1.1
    interface interface1
    {
        int Metodi1(int ric);
        int Metodi2(int ric);
    }

    class class1int : interface1
    {
        public int Metodi1(int ric)
        {
            return ric * ric;
        }

        public int Metodi2(int ric)
        {
            return ric * ric * ric;
        }
    }

    // 1.2

    interface interface2
    {
        int Tviseba { get; set; }
    }

    class clas2int : interface2
    {
        private int tvisebisRicxvi;
        public int Tviseba
        {
            get 
            {
                return tvisebisRicxvi;
            }

            set
            {
                if (value % 2 == 0)
                {
                    tvisebisRicxvi = value;
                }
            }
        }
    }

    // 1.3

    interface interface3
    {
        int this[int indexator] { get; set; }
    }

    class class3int : interface3
    {
        private int[] mas = { 1, 4, 5, 1, 2 };
        public int this[int indexator]
        {
            get {
                if (indexator < 5)
                {
                    return mas[indexator];
                }
                else return 0;
            }
            set {
                if (indexator < 5 && value % 2 == 1)
                {
                    mas[indexator] = value;
                }
            }
        }
    }

    // 1.4 

    delegate void delinterf4(Label lab); 
    interface interface4
    {
        event delinterf4 Movlena;
    }

    class class4 : interface4
    {
        public event delinterf4 Movlena;

        public void shemowmeba(int[] mas, Label lab)
        {
            int maxValue = mas.Max();
            if (maxValue > 25) Movlena(lab);
        }

        public void labPrint( Label lab)
        {
            lab.Text = "25-ზე მეტიიიიიიიიიიი";
        }
    }

  /*  
    2.1. შექმენით საბაზო კლასი.შექმენით ინტერფეისი, რომელიც ერთ მეთოდს შეიცავს.
    მეთოდი გამოთვლის სამკუთხედის პერიმეტრს.მოახდინეთ ამ ინტერფეისის რეალიზება იმ
    კლასში, რომელიც საბაზო კლასის მემკვიდრეა. საბაზო კლასი შეიცავს მეთოდს, რომელიც
    ახდენს სამკუთხედის ფართობის გამოთვლას.

    2.2. შექმენით საბაზო კლასი.შექმენით ინტერფეისი, რომელიც ერთ მეთოდს შეიცავს. მეთოდი
    პოულობს მასივის მინიმალურ ელემენტს.მოახდინეთ ამ ინტერფეისის რეალიზება იმ კლასში,
    რომელიც საბაზო კლასის მემკვიდრეა. საბაზო კლასი შეიცავს მეთოდს, რომელიც მეთოდი
    პოულობს მასივის მაქსიმალურ ელემენტს.
  */

    class Sabazo
    {
        public int a, b, c;

        public Sabazo(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public int perimetri()
        {
            return a + b + c;
        }
    }

    interface interface21
    {
        string Metodi1();
    }

    class class21 : Sabazo, interface21
    {
       public class21 (int a, int b, int c) : base (a, b, c)
        {

        }
        public string Metodi1()
        {
            return "Metodi1 Gaishva";
        }

    }
    /*
        3.1. შექმენით ორი ინტერფეისი, რომლებსაც ერთნაირი სახელის მქონე მეთოდი აქვთ.
        პირველი ინტერფეისის მეთოდი გამოთვლის და აბრუნებს სამკუთხედის პერიმეტრს.მეორე
        ინტერფეისის მეთოდი გამოთვლის და აბრუნებს სამკუთხედის ფართობს. შეასრულეთ ამ
        ინტერფეისების რეალიზება.

        3.2. შექმენით ორი ინტერფეისი, რომლებსაც ერთნაირი სახელის მქონე თვისება აქვთ.
        პირველი ინტერფეისის თვისება პრივატულ ცვლადს დადებით მნიშვნელობებს ანიჭებს და
        აბრუნებს პრივატული ცვლადის მნიშვნელობას.მეორე ინტერფეისის თვისება პრივატულ
        ცვლადს უარყოფით მნიშვნელობებს ანიჭებს და აბრუნებს პრივატული ცვლადის მნიშვნელობას.
        შეასრულეთ ამ ინტერფეისების რეალიზება
    */

    // 3.1
    interface inter3ver1
    {
        int Metodi1();
    }

    interface inter3ver2
    {s
        double Metodi1();
    }

    class Klasi31 : inter3ver1, inter3ver2 { 
        int a, b, c;
        inter3ver1 inter1;
        inter3ver2 inter2;
        public Klasi31 (int a, int c, int b)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        int inter3ver1.Metodi1()
        {
            return a + b + c;
        }

        double inter3ver2.Metodi1()
        {
            return (a * b) / 2;
        }

        public int Metodi_a()
        {
            return inter1.Metodi1();
        }

        public double Metodi_b()
        {
            return inter2.Metodi1();
        }
    }
}
