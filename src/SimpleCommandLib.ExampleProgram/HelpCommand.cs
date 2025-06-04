using System;

namespace SimpleCommandLib.ExampleProgram;

public class HelpCommand(CommandDispatcher parent) : ICommandRunner
{
  public string CommandName { get; } = "help";
  public string CommandUsage => "Shows this help screen";
  protected CommandDispatcher Parent = parent;

  public bool Execute(string[] args)
  {
    Console.WriteLine("Available Commands:");
    foreach (var cmd in Parent.EnumerateCommands)
      Console.WriteLine($"  {cmd.Key} - {cmd.Value.CommandUsage}");
    return true;
  }
}
