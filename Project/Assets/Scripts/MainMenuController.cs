/* This draws and controls the actions of our Main Menu.   */

using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {


	 void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width * .4f, Screen.height * .75f, Screen.width * .2f, Screen.height * 0.06f), "Start")){
			Application.LoadLevel("Level 1");                        //Loads the first level
		}
	
		if(GUI.Button(new Rect(Screen.width * .4f, Screen.height * .82f, Screen.width * .2f, Screen.height * 0.06f), "Credits")){	 //Plays Credit Roll
			Application.LoadLevel("Credits");
		}	
	
		if(GUI.Button(new Rect(Screen.width * .4f, Screen.height * .89f, Screen.width * .2f, Screen.height * 0.06f), "Quit")){	
			Application.Quit();
		}	
	

	}
}	