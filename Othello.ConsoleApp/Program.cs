using Othello.RuleEngine;
using Othello.ValueObjects;
using System;
using System.Text;

namespace Othello.ConsoleApp
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                var playerName = args.Length > 0 ? args[0] : "Human";

                RunGame(playerName);

                Console.WriteLine($"Bye");
                return 0;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("ERROR");
                Console.Error.WriteLine(e);

                return e.GetType().GetHashCode();
            }
        }

        private static void RunGame(string playerName)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"Hello {playerName}! You're playing Black \u25CF.");
            Console.WriteLine("I, the Computer, am playing White \u25CB.");
            Console.WriteLine("You begin.");
            
            var board = new Board((Dimension)8);
        }
    }
}
