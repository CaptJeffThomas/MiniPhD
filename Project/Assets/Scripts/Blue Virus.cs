using UnityEngine;
using System.Collections;

public class BlueVirus : MonoBehaviour {
	
	enum ATTACK_TYPE { MELEE, RANGED };
	
	public double x, y;        //coordinates of virus sprite
	public int hp; //meleeDef, rangeDef;  I don't think we need to implement these Def stats after further consideration
	
	public float lifeTime;  //time virus has been alive.
	public float startTime; //time virus was born.
	public float spreadThreshold; //time after spawning until virii spreads.  Do we want this to vary between colors?
	public float currentTime;
	
	void Start(){
		
		//x = xPos;
		//y = yPos;
		
		hp = 3;
		//meleeDef = 0;
		//rangeDef = 1;
		
		lifeTime = 0;
		spreadThreshold = 20;
		
		startTime = Time.time;
		currentTime= 0;
		
		//eventMan = GameObject.Find("Global Script Executor").GetComponent<CustomEventManager>();
		//eventMan.EventListeners += RecieveEvent;
		
	}
	
	//controls Virus spread mechanic.
	void Update(){
		currentTime = Time.time;	
		if(currentTime - startTime > spreadThreshold){
		
		}
	}
	
	//upon trigger entry by a bullet, the virus takes dmg and bullet is destroyed
	void OnTriggerEnter(Collider col ){  
		if (col.gameObject.name == "LazerBeam")
		{
			//takeDamage(RANGED, 1);
			Destroy(col);
		}
		
	}
	
	public void takeDamage(int dmgType, int dmg){
		
		if (dmgType == 1){
			hp = hp - dmg;
		}
		
		if (hp <= 0){
			virusDeath();
		}
		
	}
	
	public void spread(){
	
	}
	
	public void virusDeath(){
	
	}
	
	void RecieveEvent(CustomEvent evt)
	{
		if(evt.GetEventName() == "Sword Attack")
		{
			int evtX, evtY, x, y;
			evtX = evt.GetParam(0);
			evtY = evt.GetParam(1);
			x = (int)transform.position.x;
			y = (int)transform.position.y;
			
			float distance = Vector3.Distance(transform.position, new Vector3(evtX, evtY, 0.0f));
			
			if(distance < 28.0f)
			{
				this.takeDamage((int)ATTACK_TYPE.MELEE, evt.GetParam(2));
			}
		}else if(evt.GetEventName () == "Gun Attack")
		{
			
		}else if(evt.GetEventName() == "Spread")
		{
			
		}
	}
}
