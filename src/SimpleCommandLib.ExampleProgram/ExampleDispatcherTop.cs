using System;
using System.Collections.Generic;

namespace SimpleCommandLib.ExampleProgram;

public class ExampleDispatcherTop : CommandDispatcher
{
  protected override Dictionary<string, ICommandRunner> CommandsMap { get; set; } = new(StringComparer.InvariantCultureIgnoreCase)
  {
    {"exit", new ExitCommand()}
  };
}
