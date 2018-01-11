Ben Levy - Game of Life technical kata submission

This was made using C# in Visual Studio 2017 and should be run 
in the same or similar environment. 

Typical Conway's Game of Life puzzle as a console app.

Entering the initial 2d array state is dynamic, and uses any character as a live (Alive)
cell, with spaces (' ') being dead (!Alive) cells. Each cell also stores the characters
used for its neighbors, so if a !Alive cell changes state to Alive, its displayed character
will be randomly selected from those of its neighbors. This has an interesting effect of
homogenization as the algorithm is progressively run.

Enjoy!
