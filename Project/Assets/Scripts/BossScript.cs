using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {
	
	enum ColorValue { RED, GREEN, BLUE };
	
	public Transform target;				// Target the missile is locked onto
	
	ColorValue currentColor;
	
	float colorTimer;
	public float deathTimer;
	
	int hp;
	public bool alive;
	
	private CustomAnimator mAnimator;
	
	private CustomEventManager eventMan;
	
	Material mMaterial;
	
	public AudioClip deathGrowl;
	
	// Use this for initialization
	void Start () {
		
		
		alive = true;
		
		hp = 50;
		
		currentColor = ColorValue.RED;
		colorTimer = 0.0f;
		
		eventMan = GameObject.Find ("Global Script Executor").GetComponent<CustomEventManager>();
		eventMan.EventListeners += RecieveEvent;
		
		//target = GameObject.Find("Doctor").GetComponent<Transform>();
		
		mMaterial = renderer.material;
		mAnimator = new CustomAnimator(ref mMaterial, 4, 1);
		
		mAnimator.CreateAnimation("Red", 0, 0, 10000000);
		mAnimator.CreateAnimation("Blue", 1, 1, 10000000);
		mAnimator.CreateAnimation("Green", 2, 2, 10000000);
		mAnimator.CreateAnimation("Death", 3, 3, 10000000);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(mAnimator == null) return;
		
		if(alive)
		{
			colorTimer += Time.deltaTime;
			
			if(hp > 35 && colorTimer > 6.0f)
			{
				colorTimer -= 6.0f;
				
				int color = Random.Range(0, 3);
				currentColor = (ColorValue)color;
				
			}else if(hp > 20 && colorTimer > 4.0f)
			{
				colorTimer -= 4.0f;
				
				int color = Random.Range(0, 3);
				currentColor = (ColorValue)color;
				
			}else if(colorTimer > 2.0f)
			{
				colorTimer -= 2.0f;
				
				int color = Random.Range(0, 3);
				currentColor = (ColorValue)color;
				
			}
			
			if(currentColor == ColorValue.RED)
				mAnimator.PlayAnimation("Red", false);
			else if(currentColor == ColorValue.GREEN)
				mAnimator.PlayAnimation("Green", false);
			else if(currentColor == ColorValue.BLUE)
				mAnimator.PlayAnimation("Blue", false);
			
			Vector3 v3 = target.position - transform.position;
			float angle = Mathf.Atan2(v3.y, v3.x) * Mathf.Rad2Deg;
			Quaternion qTo = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.rotation = Quaternion.RotateTowards (transform.rotation, qTo, 60 * Time.deltaTime);
			transform.Translate (Vector3.right * 80 * Time.deltaTime);
			Vector3 temp = transform.position;
		    temp.z = 7.0f;
		    transform.position = temp;
			
		}else
		{
			rigidbody.velocity = new Vector3(0,0,0);
			
			deathTimer += Time.deltaTime;
			if (deathTimer > 3){
				Destroy(gameObject);
			}
		}
	
	}
	
	public void RecieveEvent(CustomEvent evt)
	{
		if(evt.GetEventName() == "Sword Attack")
		{
			int evtX, evtY, x, y;
			evtX = evt.GetParam(0);
			evtY = evt.GetParam(1);
			x = (int)transform.position.x;
			y = (int)transform.position.y;
			
			float distance = Vector3.Distance(transform.position, new Vector3(evtX, evtY, 0.0f));
			
			if(distance < 120.0f)
			{
				this.takeDamage(1, evt.GetParam(2));
			}
		}
	}
	
	public void takeDamage(int damageType, int damage)
	{
		if(damageType == 1 && currentColor != ColorValue.BLUE)
		{
			
			hp -= damage;
		
			if (hp <= 0){
				bossDeath();
			}
			
		}else if(damageType == 2 && currentColor != ColorValue.RED)
		{
			hp -= damage;
		
			if (hp <= 0){
				bossDeath();
			}
		}
	}
	
	public void bossDeath()
	{
		rigidbody.velocity = new Vector3(0,0,0);
		
		mAnimator.PlayAnimation("Death", false);
		
		audio.PlayOneShot(deathGrowl);
		
		alive = false;
		
		eventMan.EventListeners -= RecieveEvent;
	}
	
	
}
