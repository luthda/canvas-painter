# Canvas Painter

### Setup
* Download .NET 5 or latest.
* Navigate to "CanvasPainter" folder and run `dotnet run` or open the project in your favourite IDE.

### Special cases
* Executing no or invalid commands like '20 20' will remind you of using a valid command.
* The commands are case-insensitive: `C 20 4` equals to `c 20 4`.
* Lines can be drawn in reverse: `L 1 2 6 2` will draw exactly the same line as `L 6 2 1 2`.
* The canvas size is limited from 1 to 50 for width and height.

### Commands
* `C w h` => Should create a new canvas of width w and height h.  
* `L x1 y1 x2 y2` => Should create a new line from (x1,y1) to (x2,y2). Currently only horizontal or vertical lines are supported.  
* `R x1 y1 x2 y2` => Should create a new rectangle, whose upper left corner is (x1,y1) and lower right corner is (x2,y2).  
* `B x y c` => Should fill the entire area connected to (x,y) with "colour" c.  
* `Q` => Should quit the program.

