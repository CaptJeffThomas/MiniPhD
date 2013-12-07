//Displays Text upon entering trigger

using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.IO;


public class Scene3Tutorial1 : MonoBehaviour{

	public string windowTitle = "Tutorial";
	public string text = "Red Virii can only be hurt by your Extradimensional LazerSword.  Stay Vigilant!";
	public GUIStyle style;
	public AudioClip sound; //triggers level 1 music.
	

    private bool showText = true, trigger = false;
    private float currentTime, startTime;
	private float timeToWait = 5.0f;
	
	//public GameObject doc;
	//private Doctor script;
	
	Rect window = new Rect(Screen.width * .4f, Screen.height * .5f, Screen.width * .1f, Screen.height * 0.1f);
   
  
	   
	void OnStart ()
	{
		startTime = Time.time;
	}
	
 
    void Update()    //if Text has not yet been triggered
    {
       
	   
	   if(trigger){
			if(showText)
			{
				currentTime = Time.time;	
				if(currentTime - startTime > timeToWait)
				{
					
					audio.Play();
					trigger = false;
					showText = false;     //disable text and do not show text again.

				}
			}
	   }
    }
	
 
    void OnGUI()
    {
        if(trigger){
			if(showText){
				window = GUI.Window (0, window, WindowConfig, windowTitle);

			}	
		}		
    }
	
	
	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "Doctor")
		{
			startTime = Time.time;
			trigger = true;
		
			
		}
	}
	
	void WindowConfig(int id){
		GUILayout.Label(text);
	} 
	
}