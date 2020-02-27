using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            g.Greet();
            Start:
            if (g.DidWin() == true)
            {
                Console.WriteLine("YOU WIN!");
                Console.WriteLine($"The codeword was: {g.codeword}");
            }
            else if (g.DidLose() == true)
            {
                Console.WriteLine("YOU LOSE!");
            }
            else
            {
                
                g.Display();
                g.Ask();
                goto Start;
            }
        }
    }
}
