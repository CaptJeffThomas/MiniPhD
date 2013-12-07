using UnityEngine;
using System.Collections;

public class GreenVirus : MonoBehaviour {	
	
	enum ATTACK_TYPE { MELEE, RANGED };
	enum Orientation { UP, DOWN, LEFT, RIGHT };
	//public boolean cRight, cLeft, cDown, cUP; 
	public float x, y, xv, yv; //coordinates of virus sprite
	public int hp; //meleeDef, rangeDef;  I don't think we need to implement these Def stats after further consideration
	public bool alive;
	public float deathTimer;
	public float lifeTime;  //time virus has been alive.
	public float startTime; //time virus was born.
	public float spreadThreshold; //time after spawning until virii spreads.  Do we want this to vary between colors?
	public float currentTime;
	public float timer;
	public float cTimer;
	
	CustomAnimator mAnimator;
	private CustomEventManager eventMan;
	Orientation mOrientation;
	
	Material mMaterial;
	public AudioClip sound;  //holds deathNoise
	
	void Start(){
		alive = true;
		deathTimer = 0;
		xv = 0.0f;
		yv = 0.0f;
		timer = 0.0f;
		
		
		mMaterial = renderer.material;
		
		eventMan = GameObject.Find("Global Script Executor").GetComponent<CustomEventManager>();
		eventMan.EventListeners += RecieveEvent;
		
		mAnimator = new CustomAnimator(ref mMaterial, 4, 2);
		
		mAnimator.CreateAnimation("Up", 2, 2, 10000000);
		mAnimator.CreateAnimation("Down", 3, 3, 10000000);
		mAnimator.CreateAnimation("Left", 0,0, 10000000);
		mAnimator.CreateAnimation("Right", 1, 1, 10000000);
		mAnimator.CreateAnimation("Dead Up", 6, 6, 10000000);
		mAnimator.CreateAnimation("Dead Down", 7, 7, 10000000);
		mAnimator.CreateAnimation("Dead Left", 4, 4, 10000000);
		mAnimator.CreateAnimation("Dead Right", 5, 5, 10000000);
		
		//x = xPos;
		//y = yPos;
		
		hp = 6;
		//meleeDef = 0;
		//rangeDef = 0;
		
		lifeTime = 0;
		spreadThreshold = 12;
		
		startTime = Time.time; 
		currentTime= 0;
	}
	
	//controls Virus spread mechanic.
	void Update(){
		currentTime = Time.time;	
		if(currentTime - startTime > spreadThreshold){
		
		}
		
		if (!alive){
			deathTimer += Time.deltaTime;
			if (deathTimer > 3){
				Destroy(gameObject);
			}
		}
		else {
		timer +=Time.deltaTime;
		
		
		if (timer > 0.3){
			xv += Random.Range (0,40)-20;
			if (xv > 100) xv = 100f;
			else if (xv < -100) xv = -100f;
			yv += Random.Range (0,40)-20;
			if (yv > 100) yv = 100f;
			else if (yv < -100) yv = -100f;
			timer = 0;
			
		}
		
		
		
		if (Mathf.Abs ((int)xv) > Mathf.Abs ((int)yv)){
			if(xv > 0){
				mOrientation = Orientation.RIGHT;
				mAnimator.PlayAnimation("Right", false);
				//transform.Translate(Vector3.right * xv * Time.deltaTime);
			}
			else if(xv < 0){
				mOrientation = Orientation.LEFT;
				mAnimator.PlayAnimation("Left", false);
				//transform.Translate(Vector3.left * -xv * Time.deltaTime);
			}
		}
		else if (Mathf.Abs ((int)xv) < Mathf.Abs ((int)yv)){
			if(yv > 0){
				mOrientation = Orientation.UP;
				mAnimator.PlayAnimation("Up", false);
				//transform.Translate(Vector3.up * -yv * Time.deltaTime);
			}
			else if(yv < 0){
				mOrientation = Orientation.DOWN;
				mAnimator.PlayAnimation("Down", false);
				//transform.Translate(Vector3.down * yv * Time.deltaTime);
			}
		}
		
		transform.Translate (new Vector3(xv * Time.deltaTime, yv * Time.deltaTime,0.0f));
		
		}
		
	}
	
	
	//upon trigger entry by a bullet, the virus takes dmg and bullet is destroyed
	/* void OnTriggerEnter(Collider col ){  
		if (col.gameObject.name == "LazerBeam")
		{
			
			takeDamage(2, 1);
			Destroy(col);
		}
		
	} */
	
	
	public void takeDamage(int dmgType, int dmg){
		
		hp = hp - dmg;
		
		if (hp <= 0){
			virusDeath();
		}
	}
	
	
	public void virusDeath(){
		rigidbody.velocity = new Vector3(0,0,0);
		xv = 0;
		yv = 0;	
		
		audio.PlayOneShot(sound);
		
		if(mOrientation == Orientation.LEFT)
		{
			mAnimator.PlayAnimation("Dead Left", false);
			
		}else if(mOrientation == Orientation.RIGHT)
		{
			mAnimator.PlayAnimation("Dead Right", false);

		}else if(mOrientation == Orientation.UP)
		{
			mAnimator.PlayAnimation("Dead Up", false);

		}else if(mOrientation == Orientation.DOWN)
		{
			mAnimator.PlayAnimation("Dead Down", false);

			
		}
		alive = false;
		eventMan.EventListeners -= RecieveEvent;
	
	}
	
	
	public void spread(){
		
	
	}   
	
	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Wall"){
			
				xv *= -1;
				yv *= -1;
				
			
		}
	}
	
	void RecieveEvent(CustomEvent evt)
	{
		if(evt.GetEventName() == "Sword Attack")
		{
			Debug.Log ("SLASH green");
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

