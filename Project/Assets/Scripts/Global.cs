using UnityEngine;
using System.Collections;

/*anything that should be done on a global scale should go here*/

public class Global : MonoBehaviour
{
	
	int level, count, end;
	GameObject[] reds, greens, blues, boss;
	Rect windowRect = new Rect(Screen.width * .4f, Screen.height * .5f, Screen.width * .15f, Screen.height * 0.05f);
	
	public AudioClip sound;
	
	private CustomEventManager eventMan;
	
	
	// Use this for initialization
	void Start () {
		
		level = Application.loadedLevel;
		end = 1;
		
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
	
	public void ReceiveEvent(CustomEvent evt)
	{
		if(evt.GetEventName() == "Time Up")
		{
			//game over
			Application.LoadLevel(0);
		}
	}	
				
	void OnGUI()
    {
        if(count == 0)
			windowRect = GUI.Window (0, windowRect, WindowConfig, "Mini PhD");
			
    }
	
	
	IEnumerator pause(){
		yield return new WaitForSeconds(10);
		Application.LoadLevel(level + 1);
	}
	
	void WindowConfig(int id){
		if(level != 4)
			GUILayout.Label("Everything is clear! Time to move ahead.");
		else
			GUILayout.Label("All the viruses have been purged!");
	} 
}
