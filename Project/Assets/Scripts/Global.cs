using UnityEngine;
using System.Collections;

/*anything that should be done on a global scale should go here*/

public class Global : MonoBehaviour
{
	
	int level, count, end, gameOver;
	GameObject[] reds, greens, blues, boss;
	Rect windowRect = new Rect(Screen.width * .4f, Screen.height * .5f, Screen.width * .15f, Screen.height * 0.05f);
	
	public AudioClip sound;
	
	private CustomEventManager eventMan;
	
	
	// Use this for initialization
	void Start () {
		
		level = Application.loadedLevel;
		end = 1;
		gameOver = 0;
		
		eventMan = GameObject.Find("Global Script Executor").GetComponent<CustomEventManager>();
		eventMan.EventListeners += ReceiveEvent;
		
	}
	
	
	// Update is called once per frame
	void Update () {

    	reds=GameObject.FindGameObjectsWithTag("RedVirus");
    	greens=GameObject.FindGameObjectsWithTag("GreenVirus");
    	blues=GameObject.FindGameObjectsWithTag("BlueVirus");
		boss=GameObject.FindGameObjectsWithTag("Boss");
    	count = reds.Length + blues.Length + greens.Length + boss.Length;
	
		
    
    	if(count == 0){ //if all the virii have been slain, end the level
			
			if(end == 1){ //ensures this Update code is only ran once.
				
				end = 0;
				audio.PlayOneShot(sound);
				StartCoroutine(pause());
				
			}
		}
	}
	
	public void ReceiveEvent(CustomEvent evt)  //Handles failure state
	{
		if(evt.GetEventName() == "Time Up")
		{
			//game over
			gameOver = 1;
			StartCoroutine(pause());
			
		}
	}	
				
	void OnGUI()
    {
        if(count == 0)
			windowRect = GUI.Window (0, windowRect, WindowConfig, "Mini PhD");
		if(gameOver == 1)
			windowRect = GUI.Window (0, windowRect, WindowConfig, "");
		
    }
	
	
	IEnumerator pause(){
		
		yield return new WaitForSeconds(10);
		if(end == 0) 
			Application.LoadLevel(level + 1);     // we have won the level, move forward
		else
			Application.LoadLevel("MainMenu");  // we have lost the level , back to main menu
	}
	
	void WindowConfig(int id){
		if(gameOver == 1)
			GUILayout.Label("Valerie has died.  GAME OVER.");
		else if(level != 4)
			GUILayout.Label("Everything is clear! Time to move ahead.");
		else
			GUILayout.Label("All the viruses have been purged!");
	} 
}
