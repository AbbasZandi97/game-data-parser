# 🎮 Game Data Parser

A simple console app that reads video game data from a file, parses it, and prints the list of games to the console. Built with C# and .NET 10.

The parser is source-independent: reading the file and parsing its content are separated by an `IDeserializer` interface, so any data format can be supported by adding a new implementation. JSON is the format used by default and is the one wired up in `Program.cs`.

## How to Use

1. Run the app
2. Enter the name (or path) of the data file you want to read
3. View the list of loaded games, each shown with its release year and rating
4. Press any key to close the app

### Test data (JSON)

The included `JsonDeserializer` expects a list of games:

```json
[
  {
    "Title": "The Legend of Zelda",
    "ReleaseYear": 1986,
    "Rating": 9.5
  },
  {
    "Title": "Super Mario Bros.",
    "ReleaseYear": 1985,
    "Rating": 9.0
  }
]
```

### Example output

```
Enter the name of the file you want to read
games.json
Loaded games are:
The Legend of Zelda, released in 1986, rating: 9.5
Super Mario Bros., released in 1985, rating: 9
Press any key to close the app.
```

## Features

- Format-independent design: parsing sits behind the `IDeserializer` interface, so the app doesn't depend on any specific file format
- JSON support included: `JsonDeserializer` is the ready-to-use implementation
- Easy to extend: to support another format (TXT, CSV, XML...), implement `IDeserializer` and pass it to `Application` in `Program.cs`
- Duplicate-safe loading: games are stored in a `Dictionary<string, VideoGame>` keyed by title, so repeated titles are ignored
- Clear error messages: handles empty or missing file names, a missing file, malformed content, and invalid entries (null game, missing title)
- Error logging: unexpected errors are appended to `log.txt`
- Swappable parts: deserializing, logging, and user interaction all sit behind interfaces

## Project Structure

```
game-data-parser/
├── GameDataParser.slnx
└── GameDataParser/
    ├── App/
    │   └── Application.cs              # App flow
    ├── Deserializer/
    │   ├── IDeserializer.cs            # Parsing contract, implement it for any format
    │   └── JsonDeserializer.cs         # JSON implementation (System.Text.Json)
    ├── Log/
    │   ├── IErrorLogger.cs             # Logging contract
    │   └── FileErrorLogger.cs          # Appends errors to log.txt
    ├── Model/
    │   ├── VideoGame.cs                # Title, ReleaseYear, Rating
    │   └── VideoGameCollection.cs      # Validates games and removes duplicates
    ├── UserInteraction/
    │   ├── IUserInteraction.cs         # User interaction contract
    │   └── ConsoleUserInteraction.cs   # All console input and output
    └── Program.cs                      # Entry point, wires up dependencies
```

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Run the app

```
git clone https://github.com/AbbasZandi97/game-data-parser.git
cd game-data-parser/GameDataParser
dotnet run
```

When prompted, enter the path to your data file. A relative path is resolved from the folder you run the app in.

### Using a different format

In `Program.cs`, replace `JsonDeserializer` with your own `IDeserializer` implementation:

```csharp
new Application(new YourDeserializer(),
    new VideoGameCollection(),
    new FileErrorLogger(), new ConsoleUserInteraction()).StartApp();
```

## Concepts Practiced

- **Interface-based design**: `IDeserializer`, `IErrorLogger`, and `IUserInteraction` contracts with swappable implementations
- **Open/Closed Principle**: new data formats are added by writing a new `IDeserializer`, without changing `Application`
- **Dependency Injection (manual)**: `Program.cs` passes all dependencies into `Application` through its constructor
- **Separation of Concerns**: distinct layers for app flow (App), parsing (Deserializer), logging (Log), data (Model), and console I/O (UserInteraction)
- **JSON Deserialization**: parsing a list of objects with `System.Text.Json`
- **Collections**: `Dictionary<string, VideoGame>` to keep games unique by title
- **Exception Handling**: separate handling for `JsonException`, `InvalidDataException`, and unexpected errors
- **File I/O**: reading input with `File.ReadAllText` and logging errors with `File.AppendAllText`
- **Input Validation**: rejecting empty, null, and non-existent file names
- **Nullable reference types**: enabled project-wide
- **Namespaces & Project Structure**: organizing code into logical folders and namespaces
