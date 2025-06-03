namespace SimpleCommandLib.ExampleProgram;

public class ExampleCommandTop : ICommandRunner
{
  public string CommandName { get; } = "exit";
  private ExampleDispatcherTop subCommands = new();

  public bool Execute(string[] args)
  {
    if (args.Length > 0)
      return subCommands.RunCommand(args[0], args[1..]);

    return false;
  }
}
