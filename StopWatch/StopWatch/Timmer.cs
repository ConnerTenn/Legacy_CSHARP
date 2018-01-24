using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace StopWatch
{
    class Timmer
    {
        private static float ElapsedMilliseconds;
        private static TextBox t = Application.OpenForms["Form1"].Controls["Display"] as TextBox;

        public static void main()
        {
            while (true)
            {
                ElapsedMilliseconds = Form1.watch.ElapsedMilliseconds;
                float Miliseconds = (float)Math.Round((ElapsedMilliseconds % 1000)/10);
                float Seconds = (float)Math.Round(ElapsedMilliseconds / 1000);
                float Minutes = (float)Math.Round(ElapsedMilliseconds / (1000 * 60));
                string MinString = "";
                if ((Minutes.ToString()).Length == 1)
                {
                    MinString = string.Concat("0", Minutes);
                    MinString = string.Concat(MinString, ":");
                }
                else if ((Minutes.ToString()).Length > 2)
                {
                    MinString = string.Concat((Math.Round(Minutes % 60)).ToString(), ":");
                    if ((Minutes.ToString()).Length == 1)
                    {
                        MinString = string.Concat("0", Minutes);
                        MinString = string.Concat(MinString, ":");
                    }
                    else
                    {
                        MinString = string.Concat(Minutes, ":");
                    }
                }
                else
                {
                    MinString = string.Concat(Minutes, ":");
                }
                string SecString = "";
                if ((Seconds.ToString()).Length == 1)
                {
                    SecString = string.Concat("0", Seconds);
                    SecString = string.Concat(SecString, ":");
                }
                else
                {
                    SecString = string.Concat(Seconds, ":");
                }
                string MilString = "";
                if ((Seconds.ToString()).Length == 1)
                {
                    MilString = string.Concat("0", Miliseconds);
                    MilString = string.Concat(MilString, ":");
                }
                else
                {
                    MilString = Miliseconds.ToString();
                }

                string FinalString = string.Concat(MinString, SecString, MilString);

                t.Text = FinalString; 
                //Console.WriteLine("{2}:{1}:{0}", Miliseconds, Seconds, Minutes);
            }
        }
    }
}
