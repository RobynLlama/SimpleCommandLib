using System;

namespace SimpleCommandLib.ExampleProgram;

public class HelpCommand(CommandDispatcher parent) : ICommandRunner
{
  public string CommandName { get; } = "help";
  public string CommandUsage => "Shows this help screen";
  protected CommandDispatcher Parent = parent;

  public bool Execute(string[] args)
  {
    string parentCommandName = "`";

    if (Parent is ICommandRunner parentCommand)
      parentCommandName = $"`{parentCommand.CommandName} ";

    Console.WriteLine("Available Commands:");
    foreach (var cmd in Parent.EnumerateCommands)
      Console.WriteLine($"{parentCommandName}{cmd.Key}` - {cmd.Value.CommandUsage}");
    return true;
  }
}
