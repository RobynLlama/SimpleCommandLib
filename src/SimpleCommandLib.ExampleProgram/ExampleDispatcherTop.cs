using System;
using System.Collections.Generic;

namespace SimpleCommandLib.ExampleProgram;

public class ExampleDispatcherTop : CommandDispatcher
{
  public Dictionary<string, ICommandRunner> AvailableCommands => CommandsMap;

  public ExampleDispatcherTop()
  {
    TryAddCommand(new HelpCommand(this));
  }

  protected override Dictionary<string, ICommandRunner> CommandsMap { get; set; } = new(StringComparer.InvariantCultureIgnoreCase)
  {
    { "exit", new ExitCommand()}
  };

  public override void OnCommandNotFound(string commandName)
  {
    Console.WriteLine($"unrecognized: `do {commandName}`\nFor help, try `do help`");
  }
}
