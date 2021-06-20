using System;
using System.IO;
using System.Linq;
using static System.Console;

namespace TerminalTutor.App
{
    class Program
    {
        static void Main(string[] args) {
            int points = 0;
            string[] lines = File.ReadAllLines(@"./questions.md");

            Random rnd = new Random();
            foreach (string line in lines.OrderBy(x => rnd.Next())) {
                Clear();
                WriteLine(AskQ(line) ? $"-- Correct! -- ({++points})" : $"-- Incorrect! -- ({points})");
                ReadKey(true);
            }

            WriteLine($"\n{points}/{lines.Length} Correct!\nScore {10 * points / lines.Length}");
        }

        public static bool AskQ(string line) {
            string[] question = line.Split('?');
            int enumerate = 65;
            char answer = (char)(Int32.Parse(question[2]) + enumerate);

            WriteLine($"{question[0]}? (cheatmode: {answer})");

            foreach(string option in question[1].Split(',')) {
                WriteLine($"{(char)enumerate++}) {option}");
            }

            Write("- Answer: ");
            
            return Char.ToUpper(ReadKey(true).KeyChar) == answer ? true : false;
        }
    }
}
