using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {
	
	public delegate void EventDel(CustomEvent evt); 
	public EventDel EventListeners; //add a function/listener to this by calling EventManager.EventListeners += func;
	
	Queue<CustomEvent> mEventQueue;

	// Use this for initialization
	void Start () {
		mEventQueue = new Queue<CustomEvent>();
	}
	
	// Update is called once per frame
	void Update () {
		
		while(mEventQueue.Count > 0)
		{
			CustomEvent evt = mEventQueue.Dequeue(); //remove the event from the queue
			EventListeners (evt); //send this event to all of the listening functions
		}
		
		
	}
	
	//add an event to the event queue
	void PostEvent(CustomEvent evt)
	{
		mEventQueue.Enqueue(evt);
	}
	
}

public class CustomEvent
{
	
	string mEventID; //identifier for the event
	
	List<int> mParams; //all of the important data for this event
	
	CustomEvent(string eventID)
	{
		
		mParams = new List<int>();
		
		mEventID = eventID;
		
	}
	
	string GetEventName()
	{
		return mEventID;
	}
	
	//returns the parameter in the list at the given index
	int GetParam(int index)
	{
		if(mParams.Count > index)
			return mParams[index];
		
		return -1; //no parameter at that index
	}
	
	//appends the parameter to the end of the list
	void AddParam(int param)
	{
		mParams.Add(param);
	}
	
}
