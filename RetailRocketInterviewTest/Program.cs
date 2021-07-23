using System;
using RetailRocketInterviewTest.Commands;

namespace RetailRocketInterviewTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ICommand command = args[0] switch
            {
                SaveCommand.Alias => new SaveCommand(args),
                PrintCommand.Alias => new PrintCommand(args),
                _ => throw new ArgumentException("Unexpected command alias.")
            };
            command.Invoke();
        }
    }
}