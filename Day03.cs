using IronPython.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static IronPython.Modules._ast;
using static IronPython.Modules.ArrayModule;

namespace AoC2022
{
    internal class Day03
    {
        public static void Run()
        {
            var lines = File.ReadAllText(@"C:\files\temp\day03input.txt").Split(
                new string[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );

            Dictionary<int, string> ElfIsOnceAgainStupidAndWritesWeirdListsPriorityList = new Dictionary<int, string>();
            int index = 1;
            for (char character = 'a'; character <= 'z'; ++character, index++)
            {
                ElfIsOnceAgainStupidAndWritesWeirdListsPriorityList.Add(index, character.ToString());
                ElfIsOnceAgainStupidAndWritesWeirdListsPriorityList.Add(index + 26, character.ToString().ToUpper());
            }

            Int64 sum = (from line in lines let halfTheItems = line.Length / 2 let firstCompartment = line.Substring(0, halfTheItems).ToList() let secondCompartment = line.Substring(halfTheItems, halfTheItems).ToList() from character in firstCompartment.Where(firstCompartmentItem => secondCompartment.Any(secondCompartmentItem => secondCompartmentItem.Equals(firstCompartmentItem))).Distinct() select ElfIsOnceAgainStupidAndWritesWeirdListsPriorityList.Single(item => item.Value == character.ToString()).Key).Aggregate<int, long>(0, (current, priorityString) => current + priorityString);
            Console.WriteLine(sum);
        }
    }
}