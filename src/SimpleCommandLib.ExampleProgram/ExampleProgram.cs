using System;

namespace SimpleCommandLib.ExampleProgram
{
  internal class Program
  {
    static bool Running = true;

    static void Main(string[] args)
    {
      Console.WriteLine("Parsing logic startup");
      string? input = string.Empty;
      ExampleDispatcherRoot dispatcher = new();

      while (Running)
      {
        Console.Write("> ");
        input = Console.ReadLine();

        if (input is null)
          continue;

        try
        {
          dispatcher.ParseAndRunCommand(input);
        }
        catch (CommandFailedException ex)
        {
          Console.WriteLine($"\nCommand Failed!\n  Name: {ex.CommandName}\n  In: {ex.Sender}  \n  Info: {ex.Message}");
        }
      }
    }

    public static void ItsTimeToGo() => Running = false;
  }
}
