using UnityEngine;
using System.Collections;

public class Doctor : MonoBehaviour {
	
	public float movSpeedX, movSpeedY; //speed in pixels per second
	
	// Use this for initialization
	void Start () {
		
		movSpeedX = 20.0f;
		movSpeedY = 20.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey(KeyCode.W))
		{
			
			transform.Translate(Vector3.up * movSpeedY * Time.deltaTime);
			
		}
		if(Input.GetKey(KeyCode.A))
		{
			
			transform.Translate(Vector3.left * movSpeedX * Time.deltaTime);
			
		}
		if(Input.GetKey(KeyCode.S))
		{
			
			transform.Translate(Vector3.down * movSpeedY * Time.deltaTime);
			
		}
		if(Input.GetKey(KeyCode.D))
		{
			
			transform.Translate(Vector3.right * movSpeedX * Time.deltaTime);
			
		}
	}
}
