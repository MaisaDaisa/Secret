using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace C_sharp_14_catch
{
    public partial class Form1 : Form
    {
        /*
        1. შეადგინეთ პროგრამა, რომელიც შეკრებს ერთგანზომილებიანი მასივის ელემენტებს.ინდექსის
        არასწორი მნიშვნელობის შემთხვევაში გამოიტანეთ შესაბამისი შეტყობინება.
        2. შეადგინეთ პროგრამა, რომელიც შეკრებს ორგანზომილებიანი მასივის ელემენტებს.რომელიმე
        ინდექსის არასწორი მნიშვნელობის შემთხვევაში გამოიტანეთ შესაბამისი შეტყობინება.
        3. შეადგინეთ პროგრამა, რომელიც ერთი ორგანზომილებიანი მასივის ელემენტებს გაყოფს
        მეორე ორგანზომილებიანი მასივის შესაბამის ელემენტებზე.ნულზე გაყოფის შემთხვევაში
        გამოიტანეთ შესაბამისი შეტყობინება.
        4. შეადგინეთ პროგრამა, რომელიც მთელრიცხვა ერთგანზომილებიანი მასივის ელემენტებს
        ფაილში ჩაწერს.შეტანა-გამოტანის შეცდომის აღძვრის შემთხვევაში გამოიტანეთ შესაბამისი
        შეტყობინება.
        5. შეადგინეთ პროგრამა, რომელიც მთელრიცხვა ორგანზომილებიანი მასივის ელემენტებს
        ფაილიდან წაიკითხავს.შეტანა-გამოტანის შეცდომის აღძვრის შემთხვევაში გამოიტანეთ
        შესაბამისი შეტყობინება.
        */
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            1.შეადგინეთ პროგრამა, რომელიც შეკრებს ერთგანზომილებიანი მასივის ელემენტებს.ინდექსის
            არასწორი მნიშვნელობის შემთხვევაში გამოიტანეთ შესაბამისი შეტყობინება.
            */

            int in1 = int.Parse(textBox1.Text);
            int in2 = int.Parse(textBox2.Text);

            int[] mas = { 2, 3 , 4, 5, 10 ,323, 32, 1111,2 };

            int shekreba;
            try {
                shekreba = mas[in1] + mas[in2];
                label1.Text = shekreba.ToString();
            }
            catch (IndexOutOfRangeException) {
                label1.Text = "INDEX OUT OF RANGE GAUSHVA";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
             *  2. შეადგინეთ პროგრამა, რომელიც შეკრებს ორგანზომილებიანი მასივის ელემენტებს.რომელიმე
        ინდექსის არასწორი მნიშვნელობის შემთხვევაში გამოიტანეთ შესაბამისი შეტყობინება.
            */
            int in11 = int.Parse(textBox4.Text);
            int in12 = int.Parse(textBox6.Text);

            int in21 = int.Parse(textBox3.Text);
            int in22 = int.Parse(textBox5.Text);

            int[,] mas = new int[,]{ { 1, 2, 3, }, { 4, 5, 6, }, { 7, 8, 9, } };

            int shekreba;
            try
            {
                shekreba = mas[in11, in22] + mas[in21, in22];
                label1.Text = shekreba.ToString();
            } catch (IndexOutOfRangeException)
            {
                label1.Text = "INDEX OUT OF RANGE GAUSHVA";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
              3. შეადგინეთ პროგრამა, რომელიც ერთი ორგანზომილებიანი მასივის ელემენტებს გაყოფს
        მეორე ორგანზომილებიანი მასივის შესაბამის ელემენტებზე.ნულზე გაყოფის შემთხვევაში
        გამოიტანეთ შესაბამისი შეტყობინება.
            */
            int[] in1 = { 1, 2, 3, 100, 5, 6, 2, 3 };
            int[] in2 = { 1, 2, 3, 3, 4, 5, 0, 3 };

            label1.Text = "";
            for (int i = 0; i < in1.Length; i++)
            {
                try
                {
                    double result = (double)in1[i] / in2[i];
                    label1.Text += result.ToString() + "\n";
                }
                catch (DivideByZeroException)
                {
                    label1.Text += "aq gaiyo nulze \n";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
                     4. შეადგინეთ პროგრამა, რომელიც მთელრიცხვა ერთგანზომილებიანი მასივის ელემენტებს
        ფაილში ჩაწერს.შეტანა-გამოტანის შეცდომის აღძვრის შემთხვევაში გამოიტანეთ შესაბამისი
        შეტყობინება.
            */

             int[] mas = { 1, 2, 3, 4, 5, 6, 7 };
             BinaryWriter fl1 = null;
            
             try
             {
                 fl1 = new BinaryWriter(new FileStream("ricxvi.txt", FileMode.OpenOrCreate, FileAccess.Write));
                 for (int i = 0; i < mas.Length; i++)
                 {
                     fl1.Write(mas[i]);
                 }
             }
             finally { 
                 if (fl1 != null) fl1.Close();
             }
            
             BinaryReader reader = null;
             try
             {
                 reader = new BinaryReader(new FileStream("ricxvi.txt", FileMode.Open, FileAccess.Read));
                 while (reader.BaseStream.Position != reader.BaseStream.Length)
                 {
                     int value = reader.ReadInt32();
                     label1.Text += value.ToString() + " ";
                 }
             }
             catch 
             {
                 label1.Text = "Probelma moxda";
             }
             finally
             {
                 if (reader != null) reader.Close();
             }
            


        }
    }
}
