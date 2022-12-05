using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IronPython.Modules;
using static IronPython.Modules.PythonThread;

namespace AoC2022
{
    internal class Day02
    {
        public enum Move
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3,
        }

        public static Move ConvertWeirdAndStupidSuggestedMove(Move elfMove, string superWeirdMoveCode_dudeWtfAreYouDoing)
        {
            switch (superWeirdMoveCode_dudeWtfAreYouDoing)
            {
                case "X": return elfMove == Move.Rock ? Move.Scissors : elfMove == Move.Paper ? Move.Rock : Move.Paper;
                case "Y": return elfMove;
                case "Z": return elfMove == Move.Rock ? Move.Paper : elfMove == Move.Paper ? Move.Scissors : Move.Rock;
                default:
                    return Move.Rock;
            }
        }
        public static Move ConvertWeirdAndStupidElfNotation(string superWeirdMoveCode_dudeWtfAreYouDoing)
        {
            switch (superWeirdMoveCode_dudeWtfAreYouDoing)
            {
                case "A": case "X":  return Move.Rock;
                case "B": case "Y": return Move.Paper;
                case "C": case "Z": return Move.Scissors;
                default:
                    return Move.Rock;
            }

        }
        public static void Run()
        {
            var lines = File.ReadAllText(@"C:\files\temp\day02input.txt").Split(
                new string[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );
            
            Int64 totalPoints = 0;
            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    var moves = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    var elfMove = ConvertWeirdAndStupidElfNotation(moves.First().Trim().ToUpper());
                    var ownMove = ConvertWeirdAndStupidSuggestedMove(elfMove, moves.Skip(1).First().Trim().ToUpper());
                    
                    var winPoints = 
                        elfMove == Move.Rock && ownMove == Move.Rock ? 3 : elfMove == Move.Rock && ownMove == Move.Paper ? 6 :
                        elfMove == Move.Paper && ownMove == Move.Paper ? 3 : elfMove == Move.Paper && ownMove == Move.Scissors ? 6 :
                        elfMove == Move.Scissors && ownMove == Move.Scissors ? 3 : elfMove == Move.Scissors && ownMove == Move.Rock ? 6 : 0;

                    var moveSpecificPoints = (int)ownMove;

                    totalPoints += winPoints + moveSpecificPoints;
                    
                }

                
            }


            Console.WriteLine(totalPoints);
        }
    }
}