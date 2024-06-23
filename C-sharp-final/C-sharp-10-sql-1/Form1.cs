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
    
namespace C_sharp_10_sql_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Personali", conn);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Personali");

            // ამას სჭირდება DataMember რადგან მიუთითოს რომელი Table უნდა გამოიყენოს
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Personali";


            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from Personali", conn);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Personali");

            conn.Close();

            // აქ დატასეტიდან ირჩევ რომელ ცხრილს იყენებ
            DataView dv = new DataView(ds.Tables["Personali"]);
            // აქ არის WHERE ფილტრი
            dv.RowFilter = "asaki > 20";
            // order by შეგიძლია აქ
            dv.Sort = "ganyofileba, asaki DESC";
            dataGridView1.DataSource = dv;


        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from Personali", conn);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Personali");
            conn.Close();

            dataGridView1.DataSource= ds;
            dataGridView1.DataMember = "Personali";

            //აქ აბრუნებს ობჯექტ ტიპს
            object minRaod = ds.Tables["Personali"].Compute("MIN(asaki)", "asaki < 40");
            object MaxRaod = ds.Tables["Personali"].Compute("MAX(xelfasi)", "asaki < 40");
            object CountRaod = ds.Tables["Personali"].Compute("Count(PersonaliID)", "asaki < 40");
            //kidev mojna AVG da SUM
            label1.Text = minRaod.ToString();
            label2.Text = MaxRaod.ToString();
            label3.Text = CountRaod.ToString();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from Personali", conn);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Personali");
            conn.Close();

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Personali";

            // 

            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["Personali"].Columns["PersonaliID"];

            ds.Tables["Personali"].PrimaryKey = keys;

            DataRow rowfind = ds.Tables["Personali"].Rows.Find(1);

            if (rowfind != null) label1.Text = rowfind["gvari"].ToString();
        }



        /*
        1. მოთხოვნა შეასრულეთ ADO.NET კლასების გამოყენებით. Shemkveti ცხრილიდან
        წაიკითხეთ მონაცემები და ისინი DataGridView ელემენტში გამოიტანეთ.
        2. ცხრილში მონაცემების გაფილტვრა ADO.NET კლასებისა და ობიექტების
        გამოყენებით. გაფილტრეთ Shemkveti ცხრილი. ფილტრში უნდა გამოჩნდეს
        მონაცემები ქობულეთელი იურიდიული პირების შესახებ.
        3. ცხრილში მონაცემების დახარისხება ADO.NET კლასებისა და ობიექტების
        გამოყენებით. დაახარისხეთ Xelshekruleba ცხრილი კლებადობით tarigi_dawyebis
        სვეტის მიხედვით და ზრდადობით gadasaxdeli_l სვეტის მიხედვით.
        4. ცხრილში მონაცემების ძებნა ADO.NET კლასებისა და ობიექტების გამოყენებით.
        ძებნა შეასრულეთ Personali ცხრილში. ეკრანზე გამოიტანეთ იმ ხელშეკრულების
        სტრიქონი, რომლის ნომერია = 4.
        5. მოთხოვნების შესრულება ADO.NET კლასების გამოყენებით. Shemkveti ცხრილში
        დათვალეთ ქალი ფიზიკური პირის რაოდენობა.
        6. ცხრილში მონაცემების გაფილტვრა ADO.NET კლასებისა და ობიექტების
        გამოყენებით. Personali ცხრილში იპოვეთ თანამშრომლების მაქსიმალური
        ხელფასი.
        7. ცხრილში მონაცემების გაფილტვრა ADO.NET კლასებისა და ობიექტების
        გამოყენებით. Personali ცხრილში იპოვეთ თანამშრომლების მინიმალური
        ხელფასი.
        8. ცხრილში მონაცემების გაფილტვრა ADO.NET კლასებისა და ობიექტების
        გამოყენებით. Personali ცხრილში იპოვეთ სავაჭრო განყოფილების
        თანამშრომლების საშუალო ხელფასი.
        */

        private void button5_Click(object sender, EventArgs e)
        {
            /* 1. მოთხოვნა შეასრულეთ ADO.NET კლასების გამოყენებით. Shemkveti ცხრილიდან
        წაიკითხეთ მონაცემები და ისინი DataGridView ელემენტში გამოიტანეთ.*/

            SqlConnection conn = new SqlConnection("server=Maisa; database=Shekveta; uid=sa; pwd=1");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Shemkveti", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Shemkveti");

            conn.Close();

            dataGridView1.DataSource= ds;
            dataGridView1.DataMember = "Shemkveti";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*
            2.ცხრილში მონაცემების გაფილტვრა ADO.NET კლასებისა და ობიექტების
            გამოყენებით.გაფილტრეთ Shemkveti ცხრილი.ფილტრში უნდა გამოჩნდეს
            მონაცემები ქობულეთელი იურიდიული პირების შესახებ.
            */

            SqlConnection conn = new SqlConnection("server=Maisa; database=Shekveta; uid=sa; pwd=1");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Shemkveti", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Shemkveti");

            conn.Close();


            DataView dv = new DataView(ds.Tables["Shemkveti"]);
            // იცოდე რომ იქ არის საჭირო iuridiuli_fizikuri = N'იურიდიული' AND qalaqi = N'ქობულეთი'
            dv.RowFilter = "iuridiuli_fizikuri = 'იურიდიული' AND qalaqi = 'ქობულეთი'";
            dataGridView1.DataSource = dv;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            /*
             3. ცხრილში მონაცემების დახარისხება ADO.NET კლასებისა და ობიექტების
        გამოყენებით. დაახარისხეთ Xelshekruleba ცხრილი კლებადობით tarigi_dawyebis
        სვეტის მიხედვით და ზრდადობით gadasaxdeli_l სვეტის მიხედვით.
            */

            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Xelshekruleba", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Xelshekruleba");

            DataView dv = new DataView(ds.Tables["Xelshekruleba"]);
            dv.Sort = "tarigi_dawyebis DESC, gadasaxdeli_l ASC";
            dataGridView1.DataSource = dv;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            /*
            6.ცხრილში მონაცემების გაფილტვრა ADO.NET კლასებისა და ობიექტების
        გამოყენებით.Personali ცხრილში იპოვეთ თანამშრომლების მაქსიმალური
        ხელფასი.
            */
            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Personali", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Personali");

            conn.Close();

            object maxNum = ds.Tables["Personali"].Compute("MAX(xelfasi)", "");
            label3.Text = maxNum.ToString();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            /*
            4.ცხრილში მონაცემების ძებნა ADO.NET კლასებისა და ობიექტების გამოყენებით.
            ძებნა შეასრულეთ Personali ცხრილში. ეკრანზე გამოიტანეთ იმ ხელშეკრულების
            სტრიქონი, რომლის ნომერია = 4.
            */

            SqlConnection con = new SqlConnection("server=Maisa; database=Shekveta; uid=sa; pwd=1");
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Personali", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Personali");

            con.Close();

            DataView dv = new DataView(ds.Tables["Personali"]);

            dv.RowFilter = "personaliID = 4";
            dataGridView1.DataSource = dv;
       
        }

        private void button12_Click(object sender, EventArgs e)
        {
            /*
             *  5. მოთხოვნების შესრულება ADO.NET კლასების გამოყენებით. Shemkveti ცხრილში
        დათვალეთ ქალი ფიზიკური პირის რაოდენობა.
            */

            SqlConnection con = new SqlConnection("server=Maisa; database=Shekveta; uid=sa; pwd=1");
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Shemkveti", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Shemkveti");

            con.Close();

            object qaliRaod = ds.Tables["Shemkveti"].Compute("COUNT(shemkvetiID)", "sqesi = 'ქალი'");

            label3.Text = qaliRaod.ToString();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            /*
             *   7. ცხრილში მონაცემების გაფილტვრა ADO.NET კლასებისა და ობიექტების
        გამოყენებით. Personali ცხრილში იპოვეთ თანამშრომლების მინიმალური
        ხელფასი.
            */
            SqlConnection con = new SqlConnection("server=Maisa; database=Shekveta; uid=sa; pwd=1");
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Personali", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Personali");

            con.Close();

            object minXelfas = ds.Tables["Personali"].Compute("MIN(xelfasi)", "");

            label3.Text = minXelfas.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            /*
            8.ცხრილში მონაცემების გაფილტვრა ADO.NET კლასებისა და ობიექტების
        გამოყენებით.Personali ცხრილში იპოვეთ სავაჭრო განყოფილების
        თანამშრომლების საშუალო ხელფასი.
            */

            SqlConnection con = new SqlConnection("server=Maisa; database=Shekveta; uid=sa; pwd=1");
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Personali", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Personali");

            con.Close();

            object avgXelfasi = ds.Tables["Personali"].Compute("AVG(xelfasi)", "ganyofileba = 'სავაჭრო'");

            label3.Text=avgXelfasi.ToString();

        }
    }
}
