//Controls our Lazer Projectiles //

using UnityEngine;
using System.Collections;


public class LazerBeam : MonoBehaviour {

	public float lazerSpeed;
	public Vector3 direction;
	public AudioClip sound;
	public RedVirus rVirus;
	public BlueVirus bVirus;
	public GreenVirus gVirus;
	public BossScript boss;
	
	private Transform trans;
	
	
	public void setDirection(Vector3 dir){
		direction = dir;
	}
	
	
	void Start(){
	
		audio.PlayOneShot(sound);
		lazerSpeed = 600;
		trans = transform;
		

	}
	
	
	void Update(){
	
		float mvDistance = lazerSpeed * Time.deltaTime;
		trans.Translate( direction * mvDistance);
		
		//add some texture controls so it is facing the right direction and it flips axis every .5seconds to make it look like its active.
	
	}
	
	void OnCollisionEnter(Collision col){
		
		if (col.gameObject.name == "Wall")
		{
			Destroy (gameObject);
				
		}
		else if (col.gameObject.name == "BlueVirus"){
			bVirus = col.gameObject.GetComponent<BlueVirus>();
			bVirus.takeDamage (1,1);
			Destroy (gameObject);
		}
		else if (col.gameObject.name == "RedVirus"){
			Destroy (gameObject);
		}
		else if (col.gameObject.name == "GreenVirus"){
			gVirus = col.gameObject.GetComponent<GreenVirus>();
			gVirus.takeDamage (1,1);
			Destroy (gameObject);
		}else if(col.gameObject.name == "Boss"){
			boss = col.gameObject.GetComponent<BossScript>();
			boss.takeDamage(1, 1);
			Destroy(gameObject);
		}
	}
	
}