using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace C_sharp_13_LINQ
{
    /*
    1. შეადგინეთ LINQ მოთხოვნა, რომელიც სტრიქონების მასივიდან იმ სტრიქონებს
    ამოირჩევს, რომლებიც „ბ“ ასოთი იწყება.
    2. შეადგინეთ LINQ მოთხოვნა, რომელიც სტრიქონების მასივს დახარისხებს ზრდადობით.
    3. შეადგინეთ LINQ მოთხოვნა, რომელიც სტრიქონების მასივს დახარისხებს კლებადობით.
    4. შეადგინეთ LINQ მოთხოვნა, რომელიც დიდი ზომის ერთგანზომილებიანი მასივიდან
    ამოირჩევს 5-ის ჯერად რიცხვებს.მასივის ზომაა 1000000 ელემენტი.მასივი შემთხვევითი
    რიცხვებით შეავსეთ.
    5. შეადგინეთ LINQ მოთხოვნა, რომელიც დიდი ზომის ერთგანზომილებიანი მასივიდან
    ამოირჩევს 1234-ზე მეტ რიცხვებს.მასივის ზომაა 1000000 ელემენტი.მასივი შემთხვევითი
    რიცხვებით შეავსეთ.
    6. შეადგინეთ LINQ მოთხოვნა, რომელიც დიდი ზომის ერთგანზომილებიანი მასივში
    დათვლის 12340-ზე მეტი რიცხვების რაოდენობას. მასივის ზომაა 1000000 ელემენტი.
    მასივი შემთხვევითი რიცხვებით შეავსეთ.
    7. შეადგინეთ LINQ მოთხოვნა, რომელიც დიდი ზომის ერთგანზომილებიანი მასივში
    იპოვის 12340-ზე მეტი რიცხვების ჯამს. მასივის ზომაა 1000000 ელემენტი.მასივი
    შემთხვევითი რიცხვებით შეავსეთ.
    8. შეადგინეთ LINQ მოთხოვნა, რომელიც დიდი ზომის ერთგანზომილებიანი მასივში
    იპოვის 12340-ზე მეტი რიცხვების საშუალო არითმეტიკულს.მასივის ზომაა 1000000
    ელემენტი.მასივი შემთხვევითი რიცხვებით შეავსეთ.
    9. შეადგინეთ LINQ მოთხოვნა, რომელიც დიდი ზომის ერთგანზომილებიანი მასივში
    იპოვის მინიმალურს.მასივის ზომაა 1000000 ელემენტი.მასივი შემთხვევითი რიცხვებით
    შეავსეთ.
    10. შეადგინეთ LINQ მოთხოვნა, რომელიც დიდი ზომის ერთგანზომილებიანი მასივში
    იპოვის მაქსიმალურს.მასივის ზომაა 1000000 ელემენტი.მასივი შემთხვევითი რიცხვებით
    შეავსეთ.
    11. List<T> ტიპის გამოყენებით შექმენით Avtomanqana კლასის ობიექტების კოლექცია,
    რომელიც 10 ობიექტისგან შედგება. Avtomanqana კლასის ველებია: მანქანის მარკა,
    გამოშვების წელი, ფასი, მწარმოებელი ქვეყანა. შემდეგ, LINQ მოთხოვნის გამოყენებით
    ეკრანზე გამოიტანეთ შემდეგი მონაცემები Toyota მარკის მანქანების შესახებ: მანქანის
    მარკა და ფასი.
    12. List<T> ტიპის გამოყენებით შექმენით Avtomanqana კლასის ობიექტების კოლექცია,
    რომელიც 10 ობიექტისგან შედგება. Avtomanqana კლასის ველებია: მანქანის მარკა,
    გამოშვების წელი, ფასი, მწარმოებელი ქვეყანა. შემდეგ, LINQ მოთხოვნის გამოყენებით
    მონაცემები დაახარისხეთ ზრდადობით მანქანის მარკისა და ფერის მიხედვით.ეკრანზე
    გამოიტანეთ მანქანის მარკა და გამოშვების წელი.
    13. List<T> ტიპის გამოყენებით შექმენით Mascavlebeli და Moscavle კლასის ობიექტების
    კოლექციები. თითოეული კოლექცია 10-10 ობიექტისგან შედგება. Mascavlebeli კლასი
    შემდეგ ველებს შეიცავს: გვარი, საგანი, ხელფასი.Moscavle კლასი შემდეგ ველებს შეიცავს:
    გვარი, კლასის ნომერი, საგანი, ქულა.შემდეგ, Intersect(), Except() და Union() მეთოდების
    გამოყენებით იპოვეთ: ა) ერთნაირი გვარის მქონე მასწავლებლები და მოსწავლეები; ბ) ის
    მასწავლებლები, რომელთა გვარები არ ემთხვევა მოსწავლეების გვარებს; გ)
    განსხვავებული გვარის მქონე მასწავლებლების და მოსწავლეების საერთო სია.
    14. List<T> ტიპის გამოყენებით შექმენით Avtomanqana კლასის ობიექტების კოლექცია,
    რომელიც 10 ობიექტისგან შედგება. Avtomanqana კლასის ველებია: მანქანის მარკა,
    გამოშვების წელი, ფასი, მწარმოებელი ქვეყანა. შემდეგ, Take() და Skip() მეთოდების
    გამოყენებით ეკრანზე გამოიტანეთ მონაცემები: ა) პირველი ხუთი მანქანის შესახებ; ბ)
    ყველა მანქანის შესახებ პირველი ექვსი მანქანის გარდა.
    15. List<T> ტიპის გამოყენებით შექმენით Avtomanqana კლასის ობიექტების კოლექცია,
    რომელიც 10 ობიექტისგან შედგება.Avtomanqana კლასის ველებია: მანქანის მარკა,
    გამოშვების წელი, ფასი, მწარმოებელი ქვეყანა. შემდეგ, Distinct() მეთოდის გამოყენებით
    ეკრანზე გამოიტანეთ არაგამეორებადი მნიშვნელობები მანქანის მარკის მიხედვით.
    16. შეადგინეთ პროგრამა, რომელიც ეკრანზე გამოიტანს იმ თანამშრომლების გვარებს,
    რომელთა ასაკი ნაკლებია 30 წელზე.გამოიყენეთ LINQ-მოთხოვნა.
    17. შეადგინეთ პროგრამა, რომელიც ეკრანზე გამოიტანს ბათუმელი შემკვეთების გვარებს.
    გამოიყენეთ LINQ-მოთხოვნა.
    18. შეადგინეთ პროგრამა, რომელიც ეკრანზე გამოიტანს gadasaxdeli_l სვეტის მნიშვნელობებს
    იმ ხელშეკრულებებისთვის, სადაც vali_l სვეტის მნიშვნელობა აღემატება 500.00.
    გამოიყენეთ LINQ-მოთხოვნა.
    */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            1.შეადგინეთ LINQ მოთხოვნა, რომელიც სტრიქონების მასივიდან იმ სტრიქონებს
             ამოირჩევს, რომლებიც „ბ“ ასოთი იწყება.
            */

            string[] striqonebi = { "ბმული", "ჯანდაბა", "რა არის ეს", "ბოთლი" };
            var bDawyeva = 
                from striqoni in striqonebi
                where striqoni.StartsWith("ბ")
                select striqoni;

            label1.Text = "";
            foreach ( string stirq in  bDawyeva )
            {
                label1.Text += stirq + " ";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* 2. შეადგინეთ LINQ მოთხოვნა, რომელიც სტრიქონების მასივს დახარისხებს ზრდადობით. */
            int[] mas = { 1, 2, 3, 4, 10, 12, 200, 12, 10, 20, 5, -20, 0 };

            var daxarisxebul = from num in mas
                               orderby num
                               select num;

            label1.Text = "";
            foreach (int num in daxarisxebul)
            {
                label1.Text += num.ToString() + " ";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 3. შეადგინეთ LINQ მოთხოვნა, რომელიც სტრიქონების მასივს დახარისხებს კლებადობით.
            int[] mas = { 1, 2, 3, 4, 10, 12, 200, 12, 10, 20, 5, -20, 0 };

            var daxarisxebul = from num in mas
                               orderby num descending
                               select num;

            label1.Text = "";
            foreach (int num in daxarisxebul)
            {
                label1.Text += num.ToString() + " ";
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            /* 
                4. შეადგინეთ LINQ მოთხოვნა, რომელიც დიდი ზომის ერთგანზომილებიანი მასივიდან
                ამოირჩევს 5-ის ჯერად რიცხვებს.მასივის ზომაა 1000000 ელემენტი.მასივი შემთხვევითი
                რიცხვებით შეავსეთ.
            */

            int[] mas = new int[10000];

            Random shemtx = new Random();

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = shemtx.Next();
            }

            var xutJeradi = from num in mas
                            where (num % 5 == 0)
                            select num;

            label1.Text = "";
            foreach (int num in xutJeradi)
            {
                label1.Text += num.ToString() + " ";
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*
             * 5. შეადგინეთ LINQ მოთხოვნა, რომელიც დიდი ზომის ერთგანზომილებიანი მასივიდან
                ამოირჩევს 1234-ზე მეტ რიცხვებს.მასივის ზომაა 1000000 ელემენტი.მასივი შემთხვევითი
                რიცხვებით შეავსეთ.
            */

            // ეს წესით უნდა იყოს 1000000 მარა პროგრამა კვდება 
            int[] mas = new int[100];

            Random shemtx = new Random();

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = shemtx.Next();
            }

            var xutJeradi = from num in mas
                            where num > 1234
                            select num;

            label1.Text = "";
            foreach (int num in xutJeradi)
            {
                label1.Text += num.ToString() + " ";
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            /* 
             * 6. შეადგინეთ LINQ მოთხოვნა, რომელიც დიდი ზომის ერთგანზომილებიანი მასივში
                დათვლის 12340-ზე მეტი რიცხვების რაოდენობას. მასივის ზომაა 1000000 ელემენტი.
                მასივი შემთხვევითი რიცხვებით შეავსეთ.
            */

            int[] mas = new int[1000];

            Random shemtx = new Random();

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = shemtx.Next(-20, 20000);
            }

            var ricxvebi = from num in mas
                            where num > 12340
                            select num;

            label1.Text = ricxvebi.Count().ToString();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            /*
             *  7. შეადგინეთ LINQ მოთხოვნა, რომელიც დიდი ზომის ერთგანზომილებიანი მასივში
    იპოვის 12340-ზე მეტი რიცხვების ჯამს. მასივის ზომაა 1000000 ელემენტი.მასივი
    შემთხვევითი რიცხვებით შეავსეთ.
            */

            int[] mas = new int[1000];

            Random shemtx = new Random();

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = shemtx.Next(-20, 20000);
            }

            var ricxvebi = from num in mas
                           where num > 12340
                           select num;

            label1.Text = ricxvebi.Sum().ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            /* 
             *  8. შეადგინეთ LINQ მოთხოვნა, რომელიც დიდი ზომის ერთგანზომილებიანი მასივში
    იპოვის 12340-ზე მეტი რიცხვების საშუალო არითმეტიკულს.მასივის ზომაა 1000000
    ელემენტი.მასივი შემთხვევითი რიცხვებით შეავსეთ.
            */
            int[] mas = new int[1000];

            Random shemtx = new Random();

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = shemtx.Next(-20, 20000);
            }

            var ricxvebi = from num in mas
                           where num > 12340
                           select num;

            label1.Text = ricxvebi.Average().ToString();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            /*
            9.შეადგინეთ LINQ მოთხოვნა, რომელიც დიდი ზომის ერთგანზომილებიანი მასივში
    იპოვის მინიმალურს.მასივის ზომაა 1000000 ელემენტი.მასივი შემთხვევითი რიცხვებით
    შეავსეთ.
            */

            int[] mas = new int[1000];

            Random shemtx = new Random();

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = shemtx.Next(-20, 20000);
            }

            var ricxvebi = from num in mas
                           where num > 12340
                           select num;

            label1.Text = ricxvebi.Min().ToString();


        }

        private void button9_Click(object sender, EventArgs e)
        {
            /*
             *     10. შეადგინეთ LINQ მოთხოვნა, რომელიც დიდი ზომის ერთგანზომილებიანი მასივში
    იპოვის მაქსიმალურს.მასივის ზომაა 1000000 ელემენტი.მასივი შემთხვევითი რიცხვებით
    შეავსეთ.
            */

            int[] mas = new int[1000];

            Random shemtx = new Random();

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = shemtx.Next(-20, 20000);
            }

            var ricxvebi = from num in mas
                           where num > 12340
                           select num;

            label1.Text = ricxvebi.Max().ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /*
             *     11. List<T> ტიპის გამოყენებით შექმენით Avtomanqana კლასის ობიექტების კოლექცია,
    რომელიც 10 ობიექტისგან შედგება. Avtomanqana კლასის ველებია: მანქანის მარკა,
    გამოშვების წელი, ფასი, მწარმოებელი ქვეყანა. შემდეგ, LINQ მოთხოვნის გამოყენებით
    ეკრანზე გამოიტანეთ შემდეგი მონაცემები Toyota მარკის მანქანების შესახებ: მანქანის
    მარკა და ფასი.
            */

            List<Avtomanqana> manqanebi = new List<Avtomanqana>
            {
               new Avtomanqana("Toyota", 2020, 20000m, "Japan"),
                new Avtomanqana("Ford", 2019, 18000m, "USA"),
                new Avtomanqana("BMW", 2021, 35000m, "Germany"),
                new Avtomanqana("Audi", 2022, 40000m, "Germany"),
                new Avtomanqana("Honda", 2020, 22000m, "Japan"),
                new Avtomanqana("Hyundai", 2021, 25000m, "South Korea"),
                new Avtomanqana("Chevrolet", 2018, 15000m, "USA"),
                new Avtomanqana("Kia", 2021, 23000m, "South Korea"),
                new Avtomanqana("Mercedes", 2022, 50000m, "Germany"),
                new Avtomanqana("Nissan", 2019, 19000m, "Japan")
            };

            var Fasi = from manqna in manqanebi
                       where manqna.CarBrand == "Toyota"
                       select new { manqna.CountryOfManufacture, manqna.Price };

            label1.Text = "";
            foreach ( var info in  Fasi )
            {
                label1.Text += info.Price + " " + info.CountryOfManufacture;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {   /*
            12.List < T > ტიპის გამოყენებით შექმენით Avtomanqana კლასის ობიექტების კოლექცია,
            რომელიც 10 ობიექტისგან შედგება. Avtomanqana კლასის ველებია: მანქანის მარკა,
            გამოშვების წელი, ფასი, მწარმოებელი ქვეყანა. შემდეგ, LINQ მოთხოვნის გამოყენებით
            მონაცემები დაახარისხეთ ზრდადობით მანქანის მარკისა და ფერის მიხედვით.ეკრანზე
            გამოიტანეთ მანქანის მარკა და გამოშვების წელი.
            */

            List<Avtomanqana> manqanebi = new List<Avtomanqana>
            {
               new Avtomanqana("Toyota", 2020, 20000m, "Japan"),
                new Avtomanqana("Ford", 2019, 18000m, "USA"),
                new Avtomanqana("BMW", 2021, 35000m, "Germany"),
                new Avtomanqana("Audi", 2022, 40000m, "Germany"),
                new Avtomanqana("Honda", 2020, 22000m, "Japan"),
                new Avtomanqana("Hyundai", 2021, 25000m, "South Korea"),
                new Avtomanqana("Chevrolet", 2018, 15000m, "USA"),
                new Avtomanqana("Kia", 2021, 23000m, "South Korea"),
                new Avtomanqana("Mercedes", 2022, 50000m, "Germany"),
                new Avtomanqana("Nissan", 2019, 19000m, "Japan")
            };

            var shegedi = from manqana in manqanebi
                          orderby manqana.CarBrand, manqana.YearOfRelease
                          select manqana;

            label1.Text = "";
            foreach (var info in shegedi)
            {
                label1.Text += info.CarBrand.ToString() + " " + info.CountryOfManufacture.ToString() + "\n";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            /* 
             * 13. List<T> ტიპის გამოყენებით შექმენით Mascavlebeli და Moscavle კლასის ობიექტების
    კოლექციები. თითოეული კოლექცია 10-10 ობიექტისგან შედგება. Mascavlebeli კლასი
    შემდეგ ველებს შეიცავს: გვარი, საგანი, ხელფასი.Moscavle კლასი შემდეგ ველებს შეიცავს:
    გვარი, კლასის ნომერი, საგანი, ქულა.შემდეგ, Intersect(), Except() და Union() მეთოდების
    გამოყენებით იპოვეთ: ა) ერთნაირი გვარის მქონე მასწავლებლები და მოსწავლეები; ბ) ის
    მასწავლებლები, რომელთა გვარები არ ემთხვევა მოსწავლეების გვარებს; გ)
    განსხვავებული გვარის მქონე მასწავლებლების და მოსწავლეების საერთო სია.
            */

            List<Mascavlebeli> mas_mascavleblebi = new List<Mascavlebeli> {
                new Mascavlebeli("Maisa", "mate", 2000),
                new Mascavlebeli("Maisa", "mate", 2300),
                new Mascavlebeli("Maisa", "mate", 21200),
                new Mascavlebeli("Maisa", "mate", 200310),
                new Mascavlebeli("Maisa", "mate", 20011110),
                new Mascavlebeli("Maisa", "mate", 20023010),
                new Mascavlebeli("Maisa", "mate", 20020),
                new Mascavlebeli("Maisa", "mate", 200110),
                new Mascavlebeli("Maisa", "mate", 2033300),
                new Mascavlebeli("Maisa", "mate", 2111111000)
            };

            List<Moscavle> mas_mowavleeebi = new List<Moscavle>
            {
                new Moscavle("Gela", 200, "istoria", 9.5),
                new Moscavle("Gela", 200, "istoria", 9.5),
                new Moscavle("Gela", 200, "istoria", 9.5),
                new Moscavle("Gela", 200, "istoria", 9.5),
                new Moscavle("Gela", 200, "istoria", 9.5),
                new Moscavle("Gela", 200, "istoria", 9.5),
                new Moscavle("Gela", 200, "istoria", 9.5),
                new Moscavle("Gela", 200, "istoria", 9.5),
                new Moscavle("Gela", 200, "istoria", 9.5),
                new Moscavle("Maisa", 200, "istoria", 9.5),
            };



            // var ertnairi = mas_mascavleblebi.Intersect(mas_mowavleeebi);
            /*
            for (int i = 0;)

           
            var masw_gvar = from ma in mas_mascavleblebi
                            join from mo in mas_mowavleeebi on  
                            select per
           */

        }

        private void button14_Click(object sender, EventArgs e)
        {
            /*
             * 14. List<T> ტიპის გამოყენებით შექმენით Avtomanqana კლასის ობიექტების კოლექცია,
    რომელიც 10 ობიექტისგან შედგება. Avtomanqana კლასის ველებია: მანქანის მარკა,
    გამოშვების წელი, ფასი, მწარმოებელი ქვეყანა. შემდეგ, Take() და Skip() მეთოდების
    გამოყენებით ეკრანზე გამოიტანეთ მონაცემები: ა) პირველი ხუთი მანქანის შესახებ; ბ)
    ყველა მანქანის შესახებ პირველი ექვსი მანქანის გარდა.
            */

            List<Avtomanqana> manqanebi = new List<Avtomanqana>
            {
               new Avtomanqana("Toyota", 2020, 20000m, "Japan"),
                new Avtomanqana("Ford", 2019, 18000m, "USA"),
                new Avtomanqana("BMW", 2021, 35000m, "Germany"),
                new Avtomanqana("Audi", 2022, 40000m, "Germany"),
                new Avtomanqana("Honda", 2020, 22000m, "Japan"),
                new Avtomanqana("Hyundai", 2021, 25000m, "South Korea"),
                new Avtomanqana("Chevrolet", 2018, 15000m, "USA"),
                new Avtomanqana("Kia", 2021, 23000m, "South Korea"),
                new Avtomanqana("Mercedes", 2022, 50000m, "Germany"),
                new Avtomanqana("Nissan", 2019, 19000m, "Japan")
            };

            var takeMetodit = manqanebi.Take(5);
            var skipMetodit = manqanebi.Skip(6);

            label1.Text = "";
            foreach (var item in skipMetodit)
            {
                label1.Text += item.CarBrand + " \n";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            /*
             * 15. List<T> ტიპის გამოყენებით შექმენით Avtomanqana კლასის ობიექტების კოლექცია,
    რომელიც 10 ობიექტისგან შედგება.Avtomanqana კლასის ველებია: მანქანის მარკა,
    გამოშვების წელი, ფასი, მწარმოებელი ქვეყანა. შემდეგ, Distinct() მეთოდის გამოყენებით
    ეკრანზე გამოიტანეთ არაგამეორებადი მნიშვნელობები მანქანის მარკის მიხედვით.
            */

            List<Avtomanqana> manqanebi = new List<Avtomanqana>
                 {
                    new Avtomanqana("Toyota", 2020, 20000m, "Japan"),
                    new Avtomanqana("Toyota", 2020, 20000m, "Japan"),
                    new Avtomanqana("Toyota", 2020, 20000m, "Japan"),
                    new Avtomanqana("Toyota", 2020, 20000m, "Japan"),
                    new Avtomanqana("Toyota", 2020, 20000m, "Japan"),
                    new Avtomanqana("Toyota", 2020, 20000m, "Japan"),
                    new Avtomanqana("Toyota", 2020, 20000m, "Japan"),
                    new Avtomanqana("Toyota", 2020, 20000m, "Japan"),
                    new Avtomanqana("Toyota", 2020, 20000m, "Japan"),
                    new Avtomanqana("Toyota", 2020, 20000m, "Japan"),
                    new Avtomanqana("Toyota", 2020, 20000m, "Japan"),
                    new Avtomanqana("Toyota", 2020, 20000m, "Japan"),
                    new Avtomanqana("Toyota", 2020, 20000m, "Japan"),
                    new Avtomanqana("Toyota", 2020, 20000m, "Japan"),
                    new Avtomanqana("Toyota", 2020, 20000m, "Japan"),
                     new Avtomanqana("Ford", 2019, 18000m, "USA"),
                     new Avtomanqana("BMW", 2021, 35000m, "Germany"),
                     new Avtomanqana("Audi", 2022, 40000m, "Germany"),
                     new Avtomanqana("Honda", 2020, 22000m, "Japan"),
                     new Avtomanqana("Hyundai", 2021, 25000m, "South Korea"),
                     new Avtomanqana("Chevrolet", 2018, 15000m, "USA"),
                     new Avtomanqana("Kia", 2021, 23000m, "South Korea"),
                     new Avtomanqana("Mercedes", 2022, 50000m, "Germany"),
                     new Avtomanqana("Nissan", 2019, 19000m, "Japan")
                 };

            var gansxvavebul = (from manqana in manqanebi
                                select manqana.CarBrand).Distinct();



            label1.Text = "";
            foreach (var item in gansxvavebul)
            {
                label1.Text += item.ToString() + "\n";
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            /* 
             16. შეადგინეთ პროგრამა, რომელიც ეკრანზე გამოიტანს იმ თანამშრომლების გვარებს,
რომელთა ასაკი ნაკლებია 30 წელზე. გამოიყენეთ LINQ-მოთხოვნა.
            */

            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Personali", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Personali");

            conn.Close();

            var personaliEnum = ds.Tables["Personali"].AsEnumerable();

            var gafiltruli = from p in personaliEnum
                             where int.Parse(p["asaki"].ToString()) > 30
                             orderby p["gvari"] descending
                             select p;

            dataGridView1.DataSource = gafiltruli;
            label1.Text = "";

            foreach( var personali in gafiltruli)
            {
                label1.Text += personali["gvari"].ToString()+ "\n";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            /*
             *     17. შეადგინეთ პროგრამა, რომელიც ეკრანზე გამოიტანს ბათუმელი შემკვეთების გვარებს.
    გამოიყენეთ LINQ-მოთხოვნა.
            */
            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Shemkveti", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Shemkveti");

            conn.Close();

            var gafiltrul = from shmkv in ds.Tables["Shemkveti"].AsEnumerable()
                            where shmkv["qalaqi"].ToString() == "ბათუმი"
                            select shmkv;

            label1.Text = "";

            foreach (var shemkv in gafiltrul)
            {
                label1.Text += shemkv["gvari"].ToString() + "\n";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            /* 
             *     18. შეადგინეთ პროგრამა, რომელიც ეკრანზე გამოიტანს gadasaxdeli_l სვეტის მნიშვნელობებს
    იმ ხელშეკრულებებისთვის, სადაც vali_l სვეტის მნიშვნელობა აღემატება 500.00.
    გამოიყენეთ LINQ-მოთხოვნა.
            */

            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Xelshekruleba", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Xelshekruleba");

            conn.Close();

            var gafiltrul = from xelsh in ds.Tables["Xelshekruleba"].AsEnumerable()
                            where double.Parse(xelsh["vali_l"].ToString()) > 500.00
                            select xelsh;

            label1.Text = "";

            foreach (var xelsh in gafiltrul)
            {
                label1.Text += xelsh["gadasaxdeli_l"].ToString() + "\n";
            }
        }
    }
}
