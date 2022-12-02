using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Day01();
            //Day02();

        }

        private static void Day21()
        {

        }
        private static void Day01()
        {
            var lines = File.ReadAllText(@"C:\Users\a369808\OneDrive - Volvo Group\Magnus\tmp1.txt").Split(
                new string[] { Environment.NewLine },
                StringSplitOptions.None
            );

            List<Int64> sums = new List<Int64>();
            Int64 sum = 0;
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    sums.Add(sum);
                    sum = 0;
                    continue;
                }
                    
                sum += Convert.ToInt64(line);
            }

            Console.WriteLine(sums.Max());
        }
    }
}
