using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LabsLibrary
{
    public class Lab2
    {
        public List<string> GetResult(IEnumerable<string> inputLines)
        {
            return ProcessAllLines((string[])inputLines);
        }        
            public static double SumProb(int n, int q)
            {
                int m, i, j, msize = 1, size = 6 * n + 1;
                double[] prob = new double[size], pnew = new double[size];
                double vsix = 1D / 6;

                if ((q < n) || (q > 6 * n))
                    return 0;

                for (i = 0; i < size; i++)
                    pnew[i] = (prob[i] = 0);
                prob[0] = 1D;
                for (m = 0; m < n; m++)
                {
                    for (i = m; i <= 6 * m; i++)
                        for (j = 1; j < 7; j++)
                            pnew[i + j] += prob[i];
                    msize += 6;
                    for (i = 0; i < msize; i++)
                    {
                        prob[i] = vsix * pnew[i];
                        pnew[i] = 0;
                    }
                }
                return prob[q];
            }
            private List<string> ProcessAllLines(string[] inputLines)
            {

                StreamReader sr = new StreamReader("../../../../input.txt");
                string[] strok = File.ReadAllLines("../../../../input.txt");
                List<int> Num = new List<int>();
                List<string> Answ = new List<string>();
                if (strok.Length == 0)
                {
                    throw new Exception("File is empty");
                }
                StreamWriter sw = new StreamWriter("../../../../output.txt", false);
                string numbers = sr.ReadLine();
                foreach (var number in numbers.Split())
                {
                    int Varr = Convert.ToInt32(number);
                    Num.Add(Varr);
                }
                if (Num[0] > 500 || Num[1] > 3000)
                {
                    throw new Exception("Numbers are out of range");
                }
                var ans = SumProb(Num[0], Num[1]);
                sw.WriteLine(ans);
                sr.Close();
                sw.Close();
            string a = Convert.ToString(ans);
            Answ.Add(a);

                return Answ;
            }
        }

    }

