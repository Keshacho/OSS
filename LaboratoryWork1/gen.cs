using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork1
{
    class Gen
    {
        public void GenArrList(ArrayList myAL, int ItemCount)
        {
            Random rnd1 = new Random();
            int number;
            for (int index = 0; index < ItemCount; index++)
            {
                number = -100 + rnd1.Next(200);
                myAL.Add(number);
            }
        }

        public void GenDecreasingArrList(ArrayList myAL, int ItemCount)
        {
            Random rnd = new Random();
            double num = 0;
            int start_number = rnd.Next(1, 100);
            for (int index = 0; index < ItemCount; index++)
            {
                if (index == 0)
                {
                    myAL.Add(start_number);
                }
                else
                {
                    double nextnum = rnd.NextDouble();
                    if (nextnum != 0 || nextnum != 1)
                    {
                        num = Convert.ToDouble(myAL[index - 1]) * nextnum;
                        myAL.Add(num);
                    }
                    else index--;
                }
            }
        }
    }
}
