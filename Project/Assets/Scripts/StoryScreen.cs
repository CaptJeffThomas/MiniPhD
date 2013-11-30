/* This draws and controls the actions of our Dtpry.   */

using UnityEngine;
using System.Collections;

public class StoryScreen : MonoBehaviour {
	
	private Color color;


	 void OnGUI()
	{
	
		if(GUI.Button(new Rect(Screen.width * .72f, Screen.height * .88f, Screen.width * .2f, Screen.height * 0.06f), "Begin")){	 //Starts First level
			Application.LoadLevel("Level 1");
		}	


	}
	
	
}	