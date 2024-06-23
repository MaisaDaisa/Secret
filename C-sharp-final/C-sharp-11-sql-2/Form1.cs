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
using System.Data.Common;

namespace C_sharp_11_sql_2
{
    /*
    Personali ცხრილის მე-6 სტრიქონში staji სვეტის მნიშვნელობა შეცვალეთ.ახალი
მნიშვნელობა TextBox ელემენტიდან შეიტანეთ.ახალი მნიშვნელობაა 14.
2. Personali ცხრილში სტრიქონი ჩაუმატეთ.staji და asaki სვეტების ახალი მნიშვნელობებია
7 და 30. ახალი მნიშვნელობები TextBox ელემენტებიდან შეიტანეთ.
3. Personali ცხრილიდან წაშალეთ ერთი სტრიქონი, რომლის პირველადი გასაღებია 2. ეს
მნიშვნელობა TextBox ელემენტიდან შეიტანეთ.
4. Personali და Xelshekruleba ცხრილებს შორის დაამყარეთ რელაცია.
5. Shemkveti ცხრილის მე-7 სტრიქონში qalaqi სვეტის მნიშვნელობა შეცვალეთ.ახალი
მნიშვნელობა TextBox ელემენტიდან შეიტანეთ.ახალი მნიშვნელობაა ‘ონი’.
6. Shemkveti ცხრილში სტრიქონი ჩაუმატეთ. qalaqi და regioni სვეტების ახალი
მნიშვნელობებია ‘ქობულეთი’ და ‘აჭარა’. ახალი მნიშვნელობები TextBox
ელემენტებიდან შეიტანეთ.
7. Shemkveti ცხრილიდან წაშალეთ ერთი სტრიქონი, რომლის პირველადი გასაღებია 1. ეს
მნიშვნელობა TextBox ელემენტიდან შეიტანეთ.
8. Shemkveti და Xelshekruleba ცხრილებს შორის დაამყარეთ რელაცია.
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
             Personali ცხრილის მე-6 სტრიქონში staji სვეტის მნიშვნელობა შეცვალეთ.ახალი
             მნიშვნელობა TextBox ელემენტიდან შეიტანეთ.ახალი მნიშვნელობაა 14.
            */
            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Personali", conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Personali");
            label1.Text = ds.Tables["Personali"].Rows[5]["staji"].ToString();
            int axaliMnishvn = int.Parse(textBox1.Text);
            ds.Tables["Personali"].Rows[5]["staji"] = axaliMnishvn;
            adapter.Update(ds, "Personali");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Personali";

            conn.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
             * 2. Personali ცხრილში სტრიქონი ჩაუმატეთ.staji და asaki სვეტების ახალი მნიშვნელობებია
                7 და 30. ახალი მნიშვნელობები TextBox ელემენტებიდან შეიტანეთ.
            */
            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Personali", conn);
            SqlCommandBuilder builder = new SqlCommandBuilder( adapter);
            DataSet ds = new DataSet();

            adapter.Fill(ds, "Personali");

            int staji = int.Parse(textBox2.Text);
            int asaki = int.Parse(textBox3.Text);

            DataRow dr = ds.Tables["Personali"].NewRow();

            dr["staji"] = staji;
            dr["asaki"] = asaki;
            ds.Tables["Personali"].Rows.Add(dr);

            adapter.Update(ds, "Personali"); 
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Personali";

            

            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
            3.Personali ცხრილიდან წაშალეთ ერთი სტრიქონი, რომლის პირველადი გასაღებია 2.ეს
            მნიშვნელობა TextBox ელემენტიდან შეიტანეთ.
            */
            SqlConnection con = new SqlConnection("server=Maisa; database=Shekveta; uid=sa; pwd=1");
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Personali", con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Personali");

            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["Personali"].Columns[0];
            ds.Tables["Personali"].PrimaryKey = keys;

            DataRow row = ds.Tables["Personali"].Rows.Find(2);

            if (row != null )
            {
                row.Delete();
                adapter.Update(ds, "Personali");
                label1.Text = "Waishalaaaa";
            } else { label1.Text = "ar waishala"; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
             * 4. Personali და Xelshekruleba ცხრილებს შორის დაამყარეთ რელაცია.
             * */
            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter personaliAdapter = new SqlDataAdapter("SELECT * FROM Personali", conn);
            SqlDataAdapter xelshekrulebaAdapter = new SqlDataAdapter("SELECT * FROM Xelshekruleba", conn);

            personaliAdapter.Fill(ds, "Personali");
            xelshekrulebaAdapter.Fill(ds, "Xelshekruleba");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Xelshekruleba";
            // Establish the relationship

            DataRelation relacia = new DataRelation("relacia",
                ds.Tables["Personali"].Columns["personaliID"],
                ds.Tables["Xelshekruleba"].Columns["personaliID"], 
                false
            );

            ds.Relations.Add( relacia );

            conn.Close();

            // Binding the data to DataGridViews
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = ds;
            bindingSource1.DataMember = "Personali";

            BindingSource bindingSource2 = new BindingSource();
            bindingSource2.DataSource = bindingSource1;
            bindingSource2.DataMember = "relacia";

            dataGridView1.DataSource = bindingSource1;
            dataGridView2.DataSource = bindingSource2;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*
            Shemkveti ცხრილის მე - 7 სტრიქონში qalaqi სვეტის მნიშვნელობა შეცვალეთ.ახალი
            მნიშვნელობა TextBox ელემენტიდან შეიტანეთ.ახალი მნიშვნელობაა ‘ონი’.
            */

            SqlConnection con = new SqlConnection("server=Maisa; database=Shekveta; uid=sa; pwd=1");
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Shemkveti", con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Shemkveti");

            string qalaqi = textBox4.Text;

            ds.Tables["Shemkveti"].Rows[6]["qalaqi"] = qalaqi;
            adapter.Update(ds, "Shemkveti");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Shemkveti";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Shemkveti", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Shemkveti");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Shemkveti";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            /*
            6.Shemkveti ცხრილში სტრიქონი ჩაუმატეთ.qalaqi და regioni სვეტების ახალი
            მნიშვნელობებია ‘ქობულეთი’ და ‘აჭარა’. ახალი მნიშვნელობები TextBox
            ელემენტებიდან შეიტანეთ.
            */

            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Shemkveti", conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Shemkveti");

            string qalaqi = textBox5.Text;
            string regioni = textBox6.Text;

            DataRow row = ds.Tables["Shemkveti"].NewRow();

            row["qalaqi"] = qalaqi;
            row["regioni"] = regioni;

            ds.Tables["Shemkveti"].Rows.Add(row);
            adapter.Update(ds, "Shemkveti");

            dataGridView1.DataSource=ds;
            dataGridView1.DataMember = "Shemkveti";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /*
            7.Shemkveti ცხრილიდან წაშალეთ ერთი სტრიქონი, რომლის პირველადი გასაღებია 1.ეს
             მნიშვნელობა TextBox ელემენტიდან შეიტანეთ.
            */
            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Shemkveti", conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Shemkveti");

            DataColumn[] keys = new DataColumn[1];
            keys[0] = ds.Tables["Shemkveti"].Columns[0];
            ds.Tables["Shemkveti"].PrimaryKey = keys;

            int sadziebo = int.Parse(textBox7.Text);
            DataRow row = ds.Tables["Shemkveti"].Rows.Find(sadziebo);

            if (row != null)
            {
                row.Delete();
                adapter.Update(ds, "Shemkveti");
                label1.Text = "waishala";
            }
            else label1.Text = "ar was";

            

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Shemkveti";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            /*
             8. Shemkveti და Xelshekruleba ცხრილებს შორის დაამყარეთ რელაცია.
             */

            SqlConnection conn = new SqlConnection("server=MAISA; database=Shekveta; uid=sa; pwd=1");
            conn.Open();
            SqlDataAdapter shekvetaAdapter = new SqlDataAdapter("SELECT * FROM Shemkveti", conn);
            SqlDataAdapter xelshekrulebaAdapter = new SqlDataAdapter("SELECT * FROM Xelshekruleba", conn);

            DataSet ds = new DataSet();
            shekvetaAdapter.Fill(ds, "Shemkveti");
            xelshekrulebaAdapter.Fill(ds, "Xelshekruleba");

            DataRelation relacia = new DataRelation("relacia",
                ds.Tables["Shemkveti"].Columns["personaliID"],
                ds.Tables["Xelshekruleba"].Columns["personaliID"],
                false
                );

            ds.Relations.Add(relacia);

            conn.Close();

            BindingSource soruce1 = new BindingSource();
            soruce1.DataSource = ds;
            soruce1.DataMember = "Shemkveti";

            BindingSource soruce2 = new BindingSource();
            soruce2.DataSource = soruce1;
            soruce2.DataMember = "relacia";

            dataGridView1.DataSource = soruce1;
            dataGridView2.DataSource = soruce2;

        }
    }
}
