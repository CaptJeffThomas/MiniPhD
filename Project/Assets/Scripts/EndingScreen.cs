/* This draws and controls the actions of our Dtpry.   */

using UnityEngine;
using System.Collections;

public class EndingScreen : MonoBehaviour {
	
	private Color color;


	 void OnGUI()
	{
	
		if(GUI.Button(new Rect(Screen.width * .85f, Screen.height * .87f, Screen.width * .1f, Screen.height * 0.06f), "FIN")){	 
			Application.LoadLevel("Credits");
		}	


	}
	
	
}	