using System;
using UnityEngine;


public class Walls : MonoBehaviour
	
{
		public Walls ()
		{
		}
	
	
		void OnCollisionEnter(Collision col){
		
			if (col.gameObject.name == "LazerBeam")
			{
				Destroy(col.gameObject);
			}
		}
	
}

