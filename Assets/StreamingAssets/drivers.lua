-- These are the drivers programmed in Lua. They use the
-- LuaAPI C# script to control the boat. Some simple,
-- general drivers were programmed for basic movement.
-- However, the MoveBoat() function can be used to create
-- any elaborative movement.

startCollection = false

--these are for the tank game

function move(direction, seconds)
	luabinding:moveTank(direction, seconds)
end

function aim(angle)
	luabinding:changeAngle(angle)
end

function turn(direction)
	luabinding:turnTank(direction)
end

function hello()
	luabinding:printHello()
end

 -- Don't change these

function StartCommandStream()
	startCollection = true
end

function ExecuteCommands()
	luabinding:delegateMoveTheObject()
	startCollection = false
end