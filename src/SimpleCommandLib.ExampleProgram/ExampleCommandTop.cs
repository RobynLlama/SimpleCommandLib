namespace SimpleCommandLib.ExampleProgram;

public class ExampleCommandTop : ICommandRunner
{
  public string CommandName { get; } = "exit";

  public string CommandUsage => "`do` is a grouping of subcommands, try `do help` for more info";

  private ExampleDispatcherTop subCommands = new();

  public bool Execute(string[] args)
  {
    if (args.Length > 0)
      return subCommands.RunCommand(args[0], args[1..]);

    return false;
  }
}
