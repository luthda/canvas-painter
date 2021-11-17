# CanvasPainter2.0

### Setup
* Download .NET 5 or latest.
* Navigate to "CanvasPainter" folder and run `dotnet run` or open the project in your favourite IDE.

### Special cases
* Executing no or invalid commands like '20 20' will remind you of using a valid command.
* The commands are case-insensitive: `C 20 4` equals to `c 20 4`.
* Lines can be drawn in reverse: `L 1 2 6 2` will draw exactly the same line as `L 6 2 1 2`.
