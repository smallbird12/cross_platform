using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            StreamReader sr = new StreamReader("../../../../input.txt");
            string[] strok = File.ReadAllLines("../../../../input.txt");

            if (strok.Length == 0)
            {
                throw new Exception("File is empty");
            }
                        
            StreamWriter sw = new StreamWriter("../../../../output.txt", false);           

            line = sr.ReadLine();
            while (line != null)
            {                 
                string str = line;
                if(str.Length<1 ||str.Length>8)
                {
                    throw new Exception("String is too short or too long. 1<=Length<=8.");
                }
                var per = new Permutations(str);
                var list = per.GetPermutationsList(false);

                foreach (var l in list)
                {
                    sw.WriteLine(l);                    
                }
                line = sr.ReadLine();
            }           
            sr.Close();
            sw.Close();
            Console.WriteLine("The result is written to a file 'output.txt'");           
        }
    }
    class Permutations
    {
        private List<string> _permutationsList;
        private String _str;      
        private void AddToList(char[] a, bool repeat = true)
        {
            var bufer = new StringBuilder("");
            for (int i = 0; i < a.Count(); i++)
            {
                bufer.Append(a[i]);
            }
            if (repeat || !_permutationsList.Contains(bufer.ToString()))
            {
                _permutationsList.Add(bufer.ToString());
            }

        }       
        private void RecPermutation(char[] a, int n, bool repeat = true)
        {
            for (var i = 0; i < n; i++)
            {
                var temp = a[n - 1];
                for (var j = n - 1; j > 0; j--)
                {
                    a[j] = a[j - 1];
                }
                a[0] = temp;
                if (i < n - 1) AddToList(a, repeat);
                if (n > 0) RecPermutation(a, n - 1, repeat);
            }
        }

        public Permutations()
        {
            _str = "";
        }

        public Permutations(String str)
        {
            _str = str;
        }     
        public String PermutationStr
        {
            get
            {
                return _str;
            }
            set
            {
                _str = value;
            }
        }     
        public System.Collections.Generic.List<string> GetPermutationsList(bool repeat = true)
        {
            _permutationsList = new List<string> { _str };
            RecPermutation(_str.ToArray(), _str.Length, repeat);
            return _permutationsList;
        }     
        public List<string> GetPermutationsSortList(bool repeat = true)
        {
            GetPermutationsList(repeat).Sort();
            return _permutationsList;
        }
    }
}