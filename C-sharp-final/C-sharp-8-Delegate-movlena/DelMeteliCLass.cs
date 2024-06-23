using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
დელეგატს დაუმატეთ 2 მეთოდის მისამართი. ორივე მეთოდი გამოიძახეთ დელეგატის
საშუალებით. შემდეგ, დელეგატს გამოაკელით I მეთოდის მისამართი და დაუმატეთ III
მეთოდის მისამართი. ორივე მეთოდი გამოიძახეთ დელეგატის საშუალებით. I მეთოდს
გადაეცემა ერთგანზომილებიანი მთელრიცხვა მასივი. მეთოდი ამ მასივის კენტ
ელემენტებს ამრავლებს 3-ზე. II მეთოდს გადაეცემა ერთგანზომილებიანი მთელრიცხვა
მასივი. მეთოდი ამ მასივის ლუწ ელემენტებს ამრავლებს 2-ზე. III მეთოდს გადაეცემა
ერთგანზომილებიანი მთელრიცხვა მასივი. მეთოდი ამ მასივის ელემენტებს ამრავლებს
10-ზე.
*/
namespace C_sharp_8
{

    public delegate void Del1Delegate(int[] mas);
    internal class DelMeteliCLass { 

        public void Metodi1(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] % 2 == 1)
                {
                    mas[i] *= 3;
                }
            }
        }

        public void Metodi2(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] % 2 == 0)
                {
                    mas[i] *= 2;
                }
            }
        }

        public void Metodi3(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] *= 10;
            }
        }
    }
    
}
