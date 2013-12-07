using UnityEngine;
using System.Collections;

/*anything that should be done on a global scale should go here*/

public class Global : MonoBehaviour {
	
	int level, count, end;
	GameObject[] reds, greens, blues;
	Rect windowRect = new Rect(Screen.width * .4f, Screen.height * .5f, Screen.width * .15f, Screen.height * 0.05f);
	
	public AudioClip sound;
	
	
	// Use this for initialization
	void Start () {
		
		//Random.seed = (int)System.Environment.TickCount; //initialize the random number generator for all classes
		level = Application.loadedLevel;
		end = 1;
		
	}
	
	
	// Update is called once per frame
	void Update () {
		
		
		if( level <= 4) //if our level index is before the boss fight, we check for these victory conditions
		{

        	reds=GameObject.FindGameObjectsWithTag("RedVirus");
        	greens=GameObject.FindGameObjectsWithTag("GreenVirus");
        	blues=GameObject.FindGameObjectsWithTag("BlueVirus");
        	count = reds.Length + blues.Length + greens.Length;
		
			
        
        	if(count == 0){ //if all the virii have been slain, end the level
				
				if(end == 1){ //ensures this Update code is only ran once.
					
					end = 0;
					audio.PlayOneShot(sound);
					StartCoroutine(pause()); 
					
				}
			
			}
		}
		
		
		
    }
	
	void OnGUI()
    {
        if(count == 0)
			windowRect = GUI.Window (0, windowRect, WindowConfig, "Mini PhD");
			
    }
	
	
	IEnumerator pause(){
		yield return new WaitForSeconds(10); 
		Application.LoadLevel(level + 1);
	}
	
	void WindowConfig(int id){
		GUILayout.Label("Everything is clear! Time to move ahead.");
	} 
	
}
