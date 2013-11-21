/* This draws and controls the actions of our Credits.   */

using UnityEngine;
using System.Collections;

public class CreditsController : MonoBehaviour {


	 void OnGUI()
	{
	

		if(GUI.Button(new Rect(Screen.width * .72f, Screen.height * .75f, Screen.width * .2f, Screen.height * 0.06f), "Main Menu")){	 //Plays Credit Roll
			Application.LoadLevel("MainMenu");
		}	
	
		if(GUI.Button(new Rect(Screen.width * .72f, Screen.height * .82f, Screen.width * .2f, Screen.height * 0.06f), "Quit")){	
			Application.Quit();
		}	
	

	}
}	