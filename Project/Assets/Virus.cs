using UnityEngine;
using System.Collections;

public class Virus : MonoBehaviour {
	
	public float x, y;
	public float movSpeedX, movSpeedY;
	
	public float elapsedTime; //continuous counter that is incremented each frame - for timed actions
	
	// Use this for initialization
	void Start () {
		
		x = 0.0f;
		y = 0.0f;
		movSpeedX = 0.0f;
		movSpeedY = 0.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		elapsedTime += Time.deltaTime;
		
		if(elapsedTime > 0.5f)
		{
			movSpeedX = Random.Range(-20.0f, 20.0f);
			movSpeedY = Random.Range(-20.0f, 20.0f);
			elapsedTime -= 0.5f;
		}
		
		
		/*if(movSpeedX > 0.0f)
			transform.Translate(Vector3.right * movSpeedX * Time.deltaTime);
		else
			transform.Translate(Vector3.left * movSpeedX * Time.deltaTime);*/
		
		x += (movSpeedX * Time.deltaTime);
		y += (movSpeedY * Time.deltaTime);
		
		transform.Translate(x, y, 0.0f);
		
	}
}
