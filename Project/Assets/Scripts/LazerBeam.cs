//Controls our Lazer Projectiles //

using UnityEngine;
using System.Collections;


public class LazerBeam : MonoBehaviour {

	public float lazerSpeed;
	public Vector3 direction;
	public AudioClip sound;
	
	private Transform trans;
	
	
	public void setDirection(Vector3 dir){
		direction = dir;
	}
	
	
	void Start(){
	
	
		lazerSpeed = 600;
		trans = transform;
		audio.PlayOneShot(sound);

	}
	
	
	void Update(){
	
		float mvDistance = lazerSpeed * Time.deltaTime;
		trans.Translate( direction * mvDistance);
		
		//add some texture controls so it is facing the right direction and it flips axis every .5seconds to make it look like its active.
	
	}
	
	
	
}