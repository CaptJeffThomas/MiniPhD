using System;
using UnityEngine;


public class Walls : MonoBehaviour
	
{
		public Walls ()
		{
		}
	
	
		void onCollisionEnter(Collision col){
		
			if (col.gameObject.name == "LazerBeam")
			{
				Destroy(col.gameObject);
			}
		}
	
}

