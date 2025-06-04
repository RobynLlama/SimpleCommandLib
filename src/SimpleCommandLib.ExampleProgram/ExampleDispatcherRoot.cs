using System;
using System.Collections.Generic;

namespace SimpleCommandLib.ExampleProgram;

public class ExampleDispatcherRoot : CommandDispatcher
{
  protected override Dictionary<string, ICommandRunner> CommandsMap { get; set; } = new(StringComparer.InvariantCultureIgnoreCase)
  {
    {"do", new ExampleDispatcherDo()}
  };
}
