using System;
using System.Windows.Forms;

/*
შექმენით მოვლენა, რომელიც აღიძვრება მაშინ, როცა პირველი რიცხვი მეორეზე მეტია.
დამამუშავებელს გამოაქვს შესაბამისი შეტყობინება.
*/
namespace C_sharp_8
{
    delegate void Del1Movlena(Label lab1);
    internal class MovlenaClass
    {
        public event Del1Movlena Movlena1;
        public void Shedareba(int ric1, int ric2,Label lab2)
        {
            if (ric1 > ric2) Movlena1(lab2);
        }
        public void LabelMetodi(Label lab3)
        {
            lab3.Text = "ერთი რიცხვი მეორეზე დიდია";
        } 
    }
}
