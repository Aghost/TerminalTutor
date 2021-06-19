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
            Random rnd = new Random();
            string[] lines = File.ReadAllLines(@"./questions.md");

            foreach (string line in lines.OrderBy(x => rnd.Next()).ToArray()) {
                WriteLine(AskQ(line) ? $"-- Correct! -- ({++points})" : $"-- Incorrect! -- ({points})");
            }
        }

        public static bool AskQ(string line) {
            string[] question = line.Split('?');
            int enumerate = 65;
            char answer = (char)(Int32.Parse(question[2]) + enumerate);

            WriteLine($"{question[0]}? (cheatmode: {answer})");

            foreach(string option in question[1].Split(',')) {
                WriteLine($"{(char)enumerate++}) {option}");
            }

            Write("> Answer: ");
            
            return Char.ToUpper(ReadKey(true).KeyChar) == answer ? true : false;
        }
    }
}
