using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2022
{
    static class Day01
    {
        public static void Run()
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


            
            Console.WriteLine(sums.OrderByDescending(x => x).ToList().Take(3).Sum());
        }
    }
}