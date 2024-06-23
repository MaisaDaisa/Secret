using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_sharp_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            int[] mas = { 1, 3, 5, 5 };
            DelMeteliCLass obj = new DelMeteliCLass();
            Del1Delegate del_mimartva;
            Del1Delegate del_met1 = new Del1Delegate(obj.Metodi1);
            Del1Delegate del_met2 = new Del1Delegate(obj.Metodi2);
            Del1Delegate del_met3 = new Del1Delegate(obj.Metodi3);

            del_mimartva = del_met1;
            del_mimartva += del_met2;

            del_mimartva(mas);

            label1.Text = "";
            foreach (int i in mas)
            {
                label1.Text += i.ToString() + " ";
            }

            del_mimartva -= del_met1;
            del_mimartva += del_met3;

            mas = new int[] { 1, 3, 5, 10 };
            del_mimartva(mas);

            label2.Text = "";
            foreach (int i in mas)
            {
                label2.Text += i.ToString() + " ";
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DelStriqoniCLass processor = new DelStriqoniCLass();

            Del2Delegate del2Delegate = null;

            Del2Delegate del1 = new Del2Delegate(processor.Metodi1);
            Del2Delegate del2 = new Del2Delegate(processor.Metodi2);
            Del2Delegate del3 = new Del2Delegate(processor.Metodi3);
            Del2Delegate del4 = new Del2Delegate(processor.Metodi4);

            del2Delegate = del1;
            del2Delegate += del2;
            del2Delegate += del3;


            string sampleString = "გილოცავთ, ბრწყინვალე დღესასწაულს!";
            del2Delegate(ref sampleString);

            label4.Text = sampleString;

            del2Delegate -= del2;
            del2Delegate -= del3;
            del2Delegate += del4;

            sampleString = "გილოცავთ, ბრწყინვალე დღესასწაულს!";
            del2Delegate(ref sampleString);

            label3.Text = sampleString;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int ric1, ric2;
            ric1 = 20;
            ric2 = 10;

            MovlenaClass obj = new MovlenaClass();
            Del1Movlena del_mov = new Del1Movlena(obj.LabelMetodi);
            obj.Movlena1 += del_mov;
            obj.Shedareba(ric1, ric2, label4 );
        }
    }
}
