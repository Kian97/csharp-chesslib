# C# Chess Library
A simple C# library that allows for the managing and playing of chess games between two opponents, following the standard ruleset.

The library is still currently being worked on, so don't expect a polished product yet!




###Example:
For an example of the library's implementation, a minimalistic winforms app has been included in the solution.

![Screenshot of the demo app](example.png?raw=true "TestApp Chessboard!")


In summary, a move is performed as follows:
```
ChessGame myGame = new ChessGame(100, true); //100 consecutive inactive moves for draw, pawn transform allowed

//Move pawn at A,1 to A,3
myGame.SelectPeice(ChessGame.convertLoc('A', '1')); 
myGame.MakeMove(ChessGame.convertLoc('A', '3')); 
```
*Both methods return false if the provided location isn't legal/valid

#####Important game methods and properties

```myGame.PieceList``` list containing all active piece's

```myGame.TakenList``` list containing all taken piece's 

```myGame.GetSelectedMoves()``` returns a list of points for selected piece's legal moves

```myGame.Turn``` Black/White enum indicating current turn's side

```myGame.IsInCheck(side)``` returns bool indicating check status of side

```myGame.CanDraw()``` indicates whether game in current state is eligible for drawing

```myGame.Draw()``` draws the game


###To do:
* Threefold repition allowing for draw
* Event for when draw becomes available
* Add undoMove()
* Refactor for camelCase convention
* Add timer functionality

  
  
  
  


