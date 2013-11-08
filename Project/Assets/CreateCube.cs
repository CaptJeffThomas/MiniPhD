using UnityEngine;
using System.Collections;

public class CreateCube : MonoBehaviour {
	
	public Transform virus;
	public Transform doctor;

	// Use this for initialization
	void Start () {
		
		Random.seed = 10;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
		{
			Instantiate(virus, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
			virus.transform.Rotate(new Vector3(0.0f, 0.0f, 0.0f));
		}else if(Input.GetKeyDown(KeyCode.L))
		{
			Instantiate(doctor, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
			doctor.transform.Rotate(new Vector3(0.0f, 0.0f, 0.0f));
		}
	}
}
