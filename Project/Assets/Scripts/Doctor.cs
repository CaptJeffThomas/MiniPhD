using UnityEngine;
using System.Collections;

public class Doctor : MonoBehaviour {
	
	enum Orientation { UP, DOWN, LEFT, RIGHT };
	
	public float movSpeedX, movSpeedY; //speed in pixels per second
	
	public bool mMoving; //whether the doctor is currently moving, used to fix minor animation problem
	public bool mAttacking;
	
	public GameObject LaserBeam;
	
	Orientation mOrientation;
	
	Material mMaterial;
	
	CustomAnimator mAnimator;
	
	// Use this for initialization
	void Start () {
		
		movSpeedX = 75.0f;
		movSpeedY = 75.0f;
		
		mMoving = false;
		mAttacking = false;
		
		mMaterial = renderer.material;
		
		mAnimator = new CustomAnimator(ref mMaterial, 6, 4);
		
		mAnimator.CreateAnimation("Standing Up", 18, 18, 1);
		mAnimator.CreateAnimation("Standing Left", 6, 6, 1);
		mAnimator.CreateAnimation("Standing Right", 12, 12, 1);
		mAnimator.CreateAnimation("Standing Down", 0, 0, 1);
		mAnimator.CreateAnimation("Walk Down", 1, 2, 0.2);
		mAnimator.CreateAnimation("Walk Left", 7, 8, 0.2);
		mAnimator.CreateAnimation("Walk Right", 13, 14, 0.2);
		mAnimator.CreateAnimation("Walk Up", 19, 20, 0.2);
		mAnimator.CreateAnimation("Sword Left", 9, 10, 0.2);
		mAnimator.CreateAnimation("Sword Right", 15, 16, 0.2);
		mAnimator.CreateAnimation("Sword Up", 21, 22, 0.2);
		mAnimator.CreateAnimation("Sword Down", 3, 4, 0.2);
		mAnimator.CreateAnimation("Gun Down", 5, 5, 1);
		mAnimator.CreateAnimation("Gun Left", 11, 11, 1);
		mAnimator.CreateAnimation("Gun Right", 17, 17, 1);
		mAnimator.CreateAnimation("Gun Up", 23, 23, 1);
		
		mAnimator.PlayAnimation("Standing Right", false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!mAttacking)
		{
			if(Input.GetKey(KeyCode.W))
			{
				
				transform.Translate(Vector3.up * movSpeedY * Time.deltaTime);
				mAnimator.PlayAnimation("Walk Up", true);
				mOrientation = Orientation.UP;
				mMoving = true;
				
			}else if(Input.GetKey(KeyCode.A))
			{
				
				transform.Translate(Vector3.left * movSpeedX * Time.deltaTime);
				mAnimator.PlayAnimation("Walk Left", true);
				mOrientation = Orientation.LEFT;
				mMoving = true;
				
			}else if(Input.GetKey(KeyCode.S))
			{
				
				transform.Translate(Vector3.down * movSpeedY * Time.deltaTime);
				mAnimator.PlayAnimation("Walk Down", true);
				mOrientation = Orientation.DOWN;
				mMoving = true;
				
			}else if(Input.GetKey(KeyCode.D))
			{
				
				transform.Translate(Vector3.right * movSpeedX * Time.deltaTime);
				mAnimator.PlayAnimation("Walk Right", true);
				mOrientation = Orientation.RIGHT;
				mMoving = true;
				
			}else if(mMoving)
			{
				if(mOrientation == Orientation.RIGHT)
					mAnimator.PlayAnimation("Standing Right", false);
				else if(mOrientation == Orientation.LEFT)
					mAnimator.PlayAnimation("Standing Left", false);
			 	else if(mOrientation == Orientation.UP)
					mAnimator.PlayAnimation("Standing Up", false);		
				else if(mOrientation == Orientation.DOWN)
					mAnimator.PlayAnimation("Standing Down", false);
				mMoving = false;
			}
		}
		
		if(!mAttacking)
		{
			if(Input.GetKey(KeyCode.Space))  //Slashing our Sword
			{
				if(mOrientation == Orientation.LEFT)
					mAnimator.PlayAnimation("Sword Left", false);
				else if(mOrientation == Orientation.RIGHT)
					mAnimator.PlayAnimation("Sword Right", false);
				else if(mOrientation == Orientation.UP)
					mAnimator.PlayAnimation("Sword Up", false);
				else if(mOrientation == Orientation.DOWN)
					mAnimator.PlayAnimation("Sword Down", false);
			}else if(Input.GetKey(KeyCode.E)) //Firing our Gun
			{
				GameObject lazer; 
				if(mOrientation == Orientation.LEFT){
					mAnimator.PlayAnimation("Gun Left", false);
					lazer = Instantiate(LaserBeam, transform.position, transform.rotation) as GameObject;
					LazerBeam script = lazer.GetComponent("LazerBeam") as LazerBeam;
					lazer.transform.localEulerAngles = new Vector3(0,0,-90);
					script.setDirection(Vector3.down);
					
				}	
				else if(mOrientation == Orientation.RIGHT){
					mAnimator.PlayAnimation("Gun Right", false);
					lazer = Instantiate(LaserBeam, transform.position, transform.rotation) as GameObject;
					LazerBeam script = lazer.GetComponent("LazerBeam") as LazerBeam;
					lazer.transform.localEulerAngles = new Vector3(0,0,90);
					script.setDirection(Vector3.down);
					
				}	
				else if(mOrientation == Orientation.UP){
					mAnimator.PlayAnimation("Gun Up", false);
					lazer = Instantiate(LaserBeam, transform.position, transform.rotation) as GameObject;
					LazerBeam script = lazer.GetComponent("LazerBeam") as LazerBeam;
					lazer.transform.localEulerAngles = new Vector3(0,0,180);
					script.setDirection(Vector3.down);
					
				}
				else if(mOrientation == Orientation.DOWN){
					mAnimator.PlayAnimation("Gun Down", false);
					lazer = Instantiate(LaserBeam, transform.position, transform.rotation) as GameObject;
					LazerBeam script = lazer.GetComponent("LazerBeam") as LazerBeam;
					script.setDirection(Vector3.down);
				}
			}
		}
		if(mAnimator.IsRunning("Sword Right") || mAnimator.IsRunning("Sword Left") || mAnimator.IsRunning("Sword Up") || 
			mAnimator.IsRunning("Sword Down") || mAnimator.IsRunning("Gun Left") || mAnimator.IsRunning("Gun Right") ||
			mAnimator.IsRunning("Gun Down") || mAnimator.IsRunning("Gun Up"))
		{
			mAttacking = true;
		}else
		{
			mAttacking = false;
		}
		
		
		mAnimator.Update(Time.deltaTime);
		
	}
}
