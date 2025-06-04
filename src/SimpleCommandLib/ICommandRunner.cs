namespace SimpleCommandLib;

/// <summary>
/// Interface for a discrete command run by a CommandDispatcher
/// </summary>
public interface ICommandRunner
{
  /// <summary>
  /// The name of the command, used when reporting failure and
  /// as the key in the CommandsMap of CommandDispatchers.
  /// This should be unique for commands that will share a
  /// dispatcher
  /// </summary>
  string CommandName { get; }

  /// <summary>
  /// A description of how to use this command, what it does
  /// or expectations around arguments it should be provided, etc
  /// </summary>
  string CommandUsage { get; }

  /// <summary>
  /// Executes the command with arguments
  /// </summary>
  /// <param name="args">The arguments to pass to the command. Can be empty `[]` for commands that don't expect input</param>
  /// <returns>
  /// Commands should return <b>true</b> when exiting successfully and
  /// <b>false</b> when encountering an error that doesn't require further
  /// attention and simply signalling a failure is enough
  /// </returns>
  /// <exception cref="CommandFailedException">This or a class extending it should be thrown when encountering an error that requires attention from the application</exception>
  bool Execute(string[] args);
}
