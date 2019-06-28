using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mo3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*1*/
            double Epsilon = 0.1;
            double[] x0 = { 0, 0 };
            double[] x1 = { 0, 0 };
            double[] z = { 0, 0 };
            double[] xp = { 0, 0 };
            double h=0.2;
            double d = 2;
            double m = 0.5;
            double fz = 0;
            double fxp = 0;
            int i = 0;
        metka2:/*2*/
            x1[0] = x0[0];
            z[0] = x0[0];
            x1[1] = x0[1];
            z[1] = x0[1];
            double fx = x1[0] * x1[0] - x1[0] * x1[1] + 3 * x1[1] * x1[1] - x1[0];
            metka3:/*3*/
            i = 1;
            metka4:/*4*/
            x1[i - 1] += h;
            fx = x1[0] * x1[0] - x1[0] * x1[1] + 3 * x1[1] * x1[1] - x1[0];
            /*5*/
            fz = z[0] * z[0] - z[0] * z[1] + 3 * z[1] * z[1] - z[0];
            if (fz > fx)
            {
                z[0] = x1[0];
                z[1] = x1[1];
                goto metka7;
            }
            else
            {
                x1[i - 1] -= 2 * h;
                fx = x1[0] * x1[0] - x1[0] * x1[1] + 3 * x1[1] * x1[1] - x1[0];
            }
            /*6*/
            if (fz > fx)
            {
                z[0] = x1[0];
                z[1] = x1[1];
            }
            else
            {
                x1[i - 1] += h;
                z[0] = x1[0];
                z[1] = x1[1];
            }
        metka7:/*7*/
            if (i < 2)
            {
                i++;
                goto metka4;
            }
        else
            {
                z[0] = x1[0];
                z[1] = x1[1];
            }
                /*8*/
                if(x1[0]==x0[0] & x1[1]==x0[1])
            {
                h /= d;
                goto metka3;
            }
            /*9*/
            xp[0] = x1[0] + m * (x1[0] - x0[0]);
            xp[1] = x1[1] + m * (x1[1] - x0[1]);
            fxp = xp[0] * xp[0] - xp[0] * xp[1] + 3 * xp[1] * xp[1] - xp[0];
            fx = x1[0] * x1[0] - x1[0] * x1[1] + 3 * x1[1] * x1[1] - x1[0];
            /*10*/
            if (fxp < fx)
            {
                x0[0] = xp[0];
                x0[1] = xp[1];
            }
            else
            {
                x0[0] = x1[0];
                x0[1] = x1[1];
            }
            /*11*/
            if (h <= Epsilon)
            {
                fx = x1[0] * x1[0] - x1[0] * x1[1] + 3 * x1[1] * x1[1] - x1[0];
                Console.WriteLine("fmin = {0}",fx);
            }
            else
                goto metka2;
            Console.ReadLine();
        }
    }
}
