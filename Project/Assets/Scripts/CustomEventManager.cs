using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomEventManager : MonoBehaviour {
	
	public delegate void EventDel(CustomEvent evt); 
	public EventDel EventListeners; //add a function/listener to this by calling EventManager.EventListeners += func;
	
	Queue<CustomEvent> mEventQueue;

	// Use this for initialization
	void Start () {
		mEventQueue = new Queue<CustomEvent>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W))
			{
				
				this.PostEvent (new CustomEvent("wkey"));
				
			}else if(Input.GetKey(KeyCode.A))
			{
				
				this.PostEvent (new CustomEvent("akey"));
				
			}else if(Input.GetKey(KeyCode.S))
			{
				
				this.PostEvent (new CustomEvent("skey"));
				
			}else if(Input.GetKey(KeyCode.D))
			{
				this.PostEvent (new CustomEvent("dkey"));
				
			}
		
		while(mEventQueue.Count > 0)
		{
			CustomEvent evt = mEventQueue.Dequeue(); //remove the event from the queue
			EventListeners (evt); //send this event to all of the listening functions
		}
		
		
	}
	
	//add an event to the event queue
	public void PostEvent(CustomEvent evt)
	{
		mEventQueue.Enqueue(evt);
	}
	
}

public class CustomEvent
{
	
	string mEventID; //identifier for the event
	
	List<int> mParams; //all of the important data for this event
	
	public CustomEvent(string eventID)
	{
		
		mParams = new List<int>();
		
		mEventID = eventID;
		
	}
	
	public string GetEventName()
	{
		return mEventID;
	}
	
	//returns the parameter in the list at the given index
	public int GetParam(int index)
	{
		if(mParams.Count > index)
			return mParams[index];
		
		return -1; //no parameter at that index
	}
	
	//appends the parameter to the end of the list
	public void AddParam(int param)
	{
		mParams.Add(param);
	}
	
}
