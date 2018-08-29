WHAT IS THIS TANK GAME?
This is a project developed by Nicholas Carpenter, Michael Mazur, and Christian Vokurka. 
Its development was overseen by Dr.Ruttan and developed during the Spring 2018 semester at 
Kent State University. The intention of the game, ultimately, is to teach players concepts 
of programming such as variables, loops, if statements, and functions.

HOW DO I PLAY IT?
The project was developed under the Unity 2017 framework, intended to be played on PC. 
Commands are to be entered into the text box in order to run Lua code that tells the tank 
what to do. Here is an example command that shows different concepts the game can handle:
	for i = 0, 4 do
		move("forward",1)
		if i<4 then
			aim(i*20)
		else
			aim(180)
		end
		move("backward",1)
	end
This command will loop 5 times and do the following: move forward for one second, aim 
(i times 20) degrees if i < 4, otherwise aim 180 degrees, then move backward for 1 second.

HOW DOES IT WORK?
There is a lot of back and forth going on here among several files. There are four important 
files at play: enterCommand.cs, luaAPI.cs, doCommand.cs, and drivers.lua. When a user hits 
"Run Lua", enterCommand.cs will create an instance of Lua and pass the user text to 
ExecuteCommand in luaAPI.cs. Simply put, "lua.DoString (command);" will pass the command 
onto drivers.lua, which will interpret the different commands it needs to run. It will call 
the functions back in luaAPI.cs. The functions in luaAPI.cs will be interpreted as need 
be(translating a parameter to a float, etc.) and call the appropriate function in 
doCommand.cs which will actually execute the command in game.
Take some time to understand how this back and forth works, as it's necessary to make sure 
the commands are interpreted properly. The Lua language will be interpreted and synytax 
like for, if, function names and their parameters will be parsed for you.

Thank you for taking your time to look at our game! We've developed what we believe is a 
great framework for future work to be done. It will likely take some time to understand 
what we've done here, but I have tried to comment on what I can and explain it to the 
best of my ability. This README.txt was written by Michael and, though I'll be graduated 
by the time you read this, don't hesitate to ask me about anything via email:
mazurasdf AT gmail DOT com