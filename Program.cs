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
            StartTutorRandom(ref points);
        }

        public static void StartTutorRandom(ref int score) {
            Random rnd = new Random();
            string[] lines = File.ReadAllLines(@"./questions.md");
            lines = lines.OrderBy(x => rnd.Next()).ToArray();

            foreach (string line in lines) {
                if (AskQuestion(line)) {
                    WriteLine($"Correct! Score({++score})");
                } else {
                    WriteLine("jammer joh");
                }
                ReadLine();
            }
        }

        public static bool AskQuestion(string line) {
            string[] question = line.Split('?');
            int e = Int32.Parse(question[1].Split(':')[1]);
            int answer_e = e + 65;
            string answer = question[1].Split(':')[0].Split(',')[e];

            Clear();
            WriteLine($"{question[0]}? ({answer}, {(char)answer_e} {e})");

            int enumerate = 65;
            foreach (string option in question[1].Split(':')[0].Split(',')) {
                WriteLine($"{(char)enumerate++} {option}\n");
            }

            Write("Die Antwoord: ");
            string input = ReadLine();

            return (input.ToLower() == answer.ToLower()) || (input.ToUpper() == ((char)(answer_e)).ToString()) ? true : false;
        }
    }
}
