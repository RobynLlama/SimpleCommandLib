using System;
using System.Collections.Generic;

namespace SimpleCommandLib.ExampleProgram;

public class ExampleDispatcherDo : CommandDispatcher, ICommandRunner
{
  #region ICommandRunner
  /**************************
   Command Runner Interface:
  ***************************/
  public string CommandName { get; } = "do";
  public string CommandUsage => "`do` is a grouping of subcommands, try `do help` for more info";

  public bool Execute(string[] args)
  {
    if (args.Length > 0)
      return RunCommand(args[0], args[1..]);

    return false;
  }
  #endregion

  public ExampleDispatcherDo()
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
