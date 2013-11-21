// This controls our Pause Menu  =) 


using UnityEngine;


public class PauseMenu : MonoBehaviour {


	bool paused = false;
 
 
	void Update () {
 
 
		if(Input.GetKeyDown("p") && paused == false)
		{
			paused = true;
			Time.timeScale = 0;	
   
		}
		else if(Input.GetKeyDown("p") && paused == true) {
   
			paused = false;
			Time.timeScale = 1;
   
		}
	}

	
	void OnGUI(){

		if (paused){

	
			if(GUI.Button(new Rect(Screen.width * .4f, Screen.height * .75f, Screen.width * .2f, Screen.height * 0.06f), "Resume")){	 
				paused = false;
				Time.timeScale = 1;
			}	
			if(GUI.Button(new Rect(Screen.width * .4f, Screen.height * .82f, Screen.width * .2f, Screen.height * 0.06f), "Main Menu")){
				Time.timeScale = 1;
				Application.LoadLevel("MainMenu");
			}	
	
			if(GUI.Button(new Rect(Screen.width * .4f, Screen.height * .89f, Screen.width * .2f, Screen.height * 0.06f), "Quit")){	
				Application.Quit();
			}

		}


	}
	
}