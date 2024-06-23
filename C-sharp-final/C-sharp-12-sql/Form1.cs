using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace C_sharp_12_sql
{
    /*
     * 1. შეადგინეთ პროგრამა, რომელიც გასცემს თბილისელი შემკვეთების რაოდენობას.
        (ExecuteScalar() მეთოდი).
        2. შეადგინეთ პროგრამა, რომელიც გასცემს იმ ხელშეკრულებების რაოდენობას, სადაც
        გადასახდელი თანხა (ლარებში) აღემატება 3000 ლარს. (ExecuteScalar() მეთოდი).
        3. შეადგინეთ პროგრამა, რომელიც გასცემს თანამშრომლების საშუალო ხელფასის
        მნიშვნელობას. (ExecuteScalar() მეთოდი).
        4. შეადგინეთ პროგრამა, რომელიც თბილისელი თანამშრომლების ხელფასს გაზრდის 15%-
        ით UPDATE მოთხოვნის უშუალოდ შესრულების გზით. (ExecuteNonQuery() მეთოდი)
        5. Shemkveti ცხრილს დაუმატეთ ახალი სტრიქონი INSERT მოთხოვნის უშუალოდ
        შესრულების გზით. (ExecuteNonQuery() მეთოდი).
        6. Shemkveti ცხრილიდან სტრიქონები წაშალეთ იმ თანამშრომლების შესახებ, რომლებიც
        ქალაქ თბილისში ცხოვრობენ, DELETE მოთხოვნის უშუალოდ შესრულების გზით.
        (ExecuteNonQuery() მეთოდი).
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
             1. შეადგინეთ პროგრამა, რომელიც გასცემს თბილისელი შემკვეთების რაოდენობას.
            (ExecuteScalar() მეთოდი).
            */
            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = " SELECT COUNT(shemkvetiID) FROM Shemkveti WHERE qalaqi = N'თბილისი'";
            object coooooo = cmd.ExecuteScalar();
            label1.Text = coooooo.ToString();

            conn.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            2. შეადგინეთ პროგრამა, რომელიც გასცემს იმ ხელშეკრულებების რაოდენობას, სადაც
           გადასახდელი თანხა (ლარებში) აღემატება 3000 ლარს. (ExecuteScalar() მეთოდი).
           */

            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(xelshekrulebaID) FROM Xelshekruleba WHERE gadasaxdeli_l > 3000";
            object pasuxi = cmd.ExecuteScalar();
            label1.Text = pasuxi.ToString();

            conn.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*
            5.Shemkveti ცხრილს დაუმატეთ ახალი სტრიქონი INSERT მოთხოვნის უშუალოდ
            შესრულების გზით. (ExecuteNonQuery() მეთოდი).
            */

            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "INSERT INTO Personali(gvari, saxeli, xelfasi) VALUES (@gvariVal, @saxeliVal, @xelfasiVal)";
            cmd.Parameters.Add("@gvariVal", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@saxeliVal", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@xelfasiVal", SqlDbType.Float);

            cmd.Parameters["@gvariVal"].Value = "Maisadze";
            cmd.Parameters["@saxeliVal"].Value = "Nikoloz";
            cmd.Parameters["@xelfasiVal"].Value = 1500.31;

            int rowsAffected = cmd.ExecuteNonQuery();
            label1.Text = rowsAffected.ToString();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
            3.შეადგინეთ პროგრამა, რომელიც გასცემს თანამშრომლების საშუალო ხელფასის
            მნიშვნელობას. (ExecuteScalar() მეთოდი).
            */

            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = " SELECT AVG(xelfasi) FROM Personali";
            object pasuxi = cmd.ExecuteScalar();
            label1.Text = pasuxi.ToString();

            conn.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
             4. შეადგინეთ პროგრამა, რომელიც თბილისელი თანამშრომლების ხელფასს გაზრდის 15%-
            ით UPDATE მოთხოვნის უშუალოდ შესრულების გზით. (ExecuteNonQuery() მეთოდი)
            */
            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = " UPDATE Personali SET xelfasi = 1.15 * xelfasi WHERE qalaqi = N'თბილისი'";
            int rowsEffected = cmd.ExecuteNonQuery();
            label1.Text = rowsEffected.ToString();

            conn.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*
             6. Shemkveti ცხრილიდან სტრიქონები წაშალეთ იმ თანამშრომლების შესახებ, რომლებიც
            ქალაქ თბილისში ცხოვრობენ, DELETE მოთხოვნის უშუალოდ შესრულების გზით.
            (ExecuteNonQuery() მეთოდი).
            */

            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"DELETE FROM Shemkveti WHERE qalaqi = N'თბილისი'";
            int rowsAffected = cmd.ExecuteNonQuery();
            label1.Text= rowsAffected.ToString();

            conn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            /*
           5.Shemkveti ცხრილს დაუმატეთ ახალი სტრიქონი INSERT მოთხოვნის უშუალოდ
           შესრულების გზით. (ExecuteNonQuery() მეთოდი).
           */

            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();

            string gvari = textBox1.Text;
            string saxeli = textBox2.Text;
            double fuli = double.Parse(textBox3.Text);

            cmd.CommandText = "INSERT INTO Personali(gvari, saxeli, xelfasi) VALUES ('"+gvari+"', '"+saxeli+"', "+fuli+")";
            Console.Write(cmd.CommandText);


            int rowsAffected = cmd.ExecuteNonQuery();
            label1.Text = rowsAffected.ToString();
            conn.Close();
        }

    
    }
}
