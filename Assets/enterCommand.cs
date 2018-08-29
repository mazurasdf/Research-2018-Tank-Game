using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enterCommand : MonoBehaviour {

	public GameObject tank;
	public Button button;
	private luaAPI lua;

	void Start() {
		//create new instance of lua and pass it the tank object family
		lua = new luaAPI (tank);
		//add a listener to react when the "Run Lua" button is clicked
		button.onClick.AddListener(TaskOnClick);
	}

	void Update(){
	}

	void TaskOnClick(){
		//what ever is typed in the text box is now sent through to luaAPI.cs
		lua.ExecuteCommand (GetComponent<InputField>().text);
	}

}
