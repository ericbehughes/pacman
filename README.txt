We had to invert x and y when creating vector2 objects because our maze was being drawn sideways.
Inverting x and y assured that the vector2 position matched up with our array syntax of [x,y] or [row,column].
For example, our array at [1,2] contains a pacman object at row 1, column 2. However, when the vector2 takes in
(1,2) as the parameters, it assumes that 1 is the column and 2 is the row when in fact (due to array acting as [row,column]) 
it's the other way around. Because of this, we had to invert x and y, as mentioned above, so, vector2(1,2) becomes
vector2(2,1).

Pacman.cs - CheckCollision():
	Once the move method in pacman is called a new tile is chosen and assigned because on the direction.
	After the new tile is assigned, the CheckCollision() method is called and checks if the current member of
	this new tile is not null. If the condition validates to true, the collide event is called and the member is set
	to null (deleting it from the maze).
	
Timers:
	All the ghosts get added to the pen once eaten, however we haven't had the time to test whether or not the timers
	work before the submission date.
	
Ghost collisions:
	Ghost collisions with pacman when in chase mode result in pacman's demise (it works). Scared, however, moves randomly
	based on the move algorithm so at timse the test collided however it often fails due to the randomness.
	
Pacman:
	We implemented ICollidable on pacman for the gameState drawMaze method (to set pacman as a member of the tile), however, 
	other than this, it's not really used.
	
What works:
	-Maze being drawn
	-Reading from file
	-No nullPointerExceptions
	-GameState
	-Event subscriptions seem to be working
	-GetAvailableNeighbors
	-CheckMembersLeft
	
What we will work on during the break:
	-GameOver events
	-Hit Collisions with scared
	-Making sure the game ends when pacman's 
		lives = 0 or all the energizers + pellets
		are eaten
	-Making sure the pen timers work correctly