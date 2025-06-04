using System;
using System.Collections.Generic;
using SimpleCommandLib.Extensions;

namespace SimpleCommandLib;

/// <summary>
/// The core class of SimpleCommandLib, the CommandDispatcher stores
/// commands and runs them as needed.
/// </summary>
public abstract class CommandDispatcher
{
  /// <summary>
  /// This is the mapping of string command names to actual runners.
  /// When extending CommandDispatcher I recommend using `StringComparer.InvariantCultureIgnoreCase`
  /// for your dictionary's comparer unless you absolutely need case
  /// sensitivity. See the example program's ExampleDispatcherTop.cs for
  /// an example of how to do this
  /// </summary>
  protected abstract Dictionary<string, ICommandRunner> CommandsMap { get; set; }

  /// <summary>
  /// Programmatically adds a command to the CommandsMap
  /// </summary>
  /// <param name="command">an instance of ICommandRunner to add</param>
  /// <remarks>
  /// This method uses the ICommandRunner.CommandName property as the
  /// key for insertion, make certain it is unique or the insertion
  /// will fail
  /// </remarks>
  /// <returns>
  /// Returns <b>true</b> on successful insertion, <b>false</b> if a
  /// command with the same name already exists in the Map.
  /// </returns>
  public bool TryAddCommand(ICommandRunner command)
  {
    if (CommandsMap.ContainsKey(command.CommandName))
      return false;

    else CommandsMap[command.CommandName] = command;
    return true;
  }

  /// <summary>
  /// This is the default handler for when a command is not found
  /// and may be overridden in derived classes for specialized
  /// command resolution, cleanup, or other needs.
  /// </summary>
  /// <param name="commandName"></param>
  /// <exception cref="CommandFailedException"></exception>
  public virtual void OnCommandNotFound(string commandName) =>
    throw new CommandFailedException(commandName, GetType(), $"Command not Found in {nameof(CommandsMap)}");

  /// <summary>
  /// Splits the given string into parts, respecting quotes and
  /// tries to run the first item as a command from the Map
  /// </summary>
  /// <param name="input">A string that contains a command name and arguments separated by spaces</param>
  /// <returns>
  /// Returns <b>true</b> if the command was found and executed without
  /// any exceptions, <b>false</b> if the command could not be found or
  /// the string is not suitable to be split for commands, such as if
  /// the string contains no content or is null
  /// </returns>
  public bool ParseAndRunCommand(string input)
  {
    string[] values = input.SplitOutsideQuotes(' ');

    if (values.Length == 0)
      return false;

    var commandName = values[0];

    string[] args = values[1..];

    return RunCommand(commandName, args);
  }

  /// <summary>
  /// Runs a given command with arguments
  /// </summary>
  /// <param name="commandName">The name of the command to run in the Map</param>
  /// <param name="args">An array of strings to send the command as arguments, can be empty if the command expects nothing</param>
  /// <returns>
  /// Returns <b>true</b> if the command was found and executed without
  /// any exceptions, <b>false</b> if the command was found but encountered
  /// an error while running
  /// </returns>
  /// <exception cref="CommandFailedException">Thrown if the command was unable to be found</exception>
  public bool RunCommand(string commandName, string[] args)
  {
    if (!CommandsMap.TryGetValue(commandName, out var cmd))
    {
      OnCommandNotFound(commandName);
      return false;
    }

    return cmd.Execute(args);
  }
}
