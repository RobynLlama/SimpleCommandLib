using System;

namespace SimpleCommandLib;

/// <summary>
/// An exception raised when a command failed to execute.
/// </summary>
/// <param name="commandName">The name of the command that failed to execute</param>
/// <param name="sender">The object that was attempting to run the command</param>
/// <param name="message">(Optional) Further information to clarify the failure or help debugging</param>
public class CommandFailedException(string commandName, Type sender, string? message = null) : Exception(message)
{
  /// <summary>
  /// The name of the command that failed to execute
  /// </summary>
  public readonly string CommandName = commandName;

  /// <summary>
  /// The TypeName of the object that was running the command
  /// </summary>
  public readonly string Sender = sender.Name;
}
