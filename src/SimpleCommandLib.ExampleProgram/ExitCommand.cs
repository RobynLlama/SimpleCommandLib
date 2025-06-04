using System;

namespace SimpleCommandLib.ExampleProgram;

public class ExitCommand : ICommandRunner
{
  public string CommandName { get; } = "exit";
  public string CommandUsage => "Terminates the running program";

  public bool Execute(string[] args)
  {
    Console.WriteLine("Goodbye\n");
    Program.ItsTimeToGo();
    return true;
  }
}
