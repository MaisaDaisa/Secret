using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
დელეგატს დაუმატეთ 3 მეთოდის მისამართი. სამივე მეთოდი გამოიძახეთ დელეგატის
საშუალებით. შემდეგ, დელეგატს გამოაკელით II და III მეთოდების მისამართები და
დაუმატეთ IV მეთოდის მისამართი. ორივე მეთოდი გამოიძახეთ დელეგატის
საშუალებით. I მეთოდს გადაეცემა სტრიქონი. მეთოდი ამ სტრიქონში ხმოვან
სიმბოლოებს შეცვლის სიმბოლო-ციფრით ‘0’. II მეთოდს გადაეცემა სტრიქონი. მეთოდი
ამ სტრიქონში ‘ბ’ სიმბოლოს შეცვლის სიმბოლო-ციფრით ‘1’. III მეთოდს გადაეცემა
სტრიქონი. მეთოდი ამ სტრიქონში წაშლის ‘ა’ სიმბოლოს. IV მეთოდს გადაეცემა
სტრიქონი. მეთოდი ამ სტრიქონში წაშლის სასვენ ნიშნებს.
*/
namespace C_sharp_8
{
    delegate void Del2Delegate(ref string str);
    internal class DelStriqoniCLass
    {
        public void Metodi1(ref  string str)
        {
            char[] xmovan = { 'ა', 'ე', 'ი', 'ო', 'უ' };
            foreach (char c in xmovan)
            {
                str = str.Replace(c, '0');
            }
        }
        public void Metodi2( ref string str)
        {
           str = str.Replace('ბ', '1');
        }

        public void Metodi3(ref string str)
        {
           str = str.Replace("ა", ""); ;
        }
        public void Metodi4(ref string str)
        {
            char[] punctuation = { '.', ',', ';', ':', '!', '?' };
            foreach (char c in punctuation)
            {
                str = str.Replace(c.ToString(), "");
            }
        }
    }
}
