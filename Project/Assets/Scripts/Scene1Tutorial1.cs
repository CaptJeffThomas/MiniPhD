//Displays Text upon entering trigger

using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.IO;


public class Scene1Tutorial1 : MonoBehaviour{

	public string windowTitle = "Tutorial";
	public string text = "Use the W,A,S,D keys to move Up, Left, Down and Right respectively.";
	public GUIStyle style;
	

    private bool showText = true, trigger = false;
    private float currentTime, startTime;
	private float timeToWait = 3.0f;
	
	//public GameObject doc;
	//private Doctor script;
	
	Rect windowRect = new Rect(Screen.width * .4f, Screen.height * .5f, Screen.width * .1f, Screen.height * 0.1f);
   
  
	   
	void OnStart ()
	{
		

	}
	
 
    void Update()    //if Text has not yet been triggered
    {
       
	
	    if(trigger){
			if(showText)
			{
				currentTime = Time.time;	
				if(currentTime - startTime > timeToWait)
				{
					
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
				
				windowRect = GUI.Window (0, windowRect, WindowConfig, windowTitle);
				
			
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