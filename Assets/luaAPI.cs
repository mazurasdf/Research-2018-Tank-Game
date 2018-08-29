using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;


public class luaAPI : MonoBehaviour {

	private Lua lua;
	private string drivers = "drivers.lua";
	private doCommand commandScript;
	public GameObject tank;

	//constructor, initializes all that crazy lua stuff! honestly, who knows how this all works! ¯\_(ツ)_/¯
	public luaAPI(GameObject target){
		lua = new Lua ();
		commandScript = target.GetComponent<doCommand> ();
		lua ["luabinding"] = this;
		lua.DoFile (Application.streamingAssetsPath + "/" + drivers);
		lua.DoString ("UnityEngine = luanet.UnityEngine");
		tank = target;
	}

	//takes the command and runs it through drivers.lua. drivers.lua will interpret the string and call the correct function in this file
	public bool ExecuteCommand(string command){
		Debug.Log ("Trying to run Lua");
		lua.DoString (command);
		return true;
	}

	/*
	 * 
	 * These are our functions below! They all reference functions in doCommand.cs, where all the real code is!
	 * 
	 */

	public void changeAngle(string angle){
		Debug.Log (angle);
		commandScript.StartCoroutine (commandScript.changeAngle(float.Parse(angle)));
	}

	public void moveTank(string direction, string seconds){
		Debug.Log (direction);
		Debug.Log (seconds);
		commandScript.StartCoroutine (commandScript.moveTank (direction, float.Parse(seconds)));
	}

	public void turnTank(string direction){
		commandScript.StartCoroutine(commandScript.turn (float.Parse (direction)));
	}

	public void printHello(){
		Debug.Log ("hello");
	}
}