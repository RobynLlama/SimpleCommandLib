# SimpleCommandLib Example Project

This project demonstrates the basics of setting up commands using the SimpleCommandLib library. It includes examples of both a single command and a nested command structure.

## Commands

- **do**: This command acts as a container for subcommands. By itself, it does nothing but serves as a namespace for nested commands. The primary subcommand available is `exit`.
  - **exit**: This is a subcommand under the `do` command. Executing this command will terminate the input loop of the example application, effectively ending the session.

## Running the Example

1. Navigate to this directory in your terminal.
2. Execute `dotnet run` to start the CLI.
3. Use the commands listed above to interact with the application.

This example is designed to help you understand how to implement and use commands within your own projects using SimpleCommandLib.
