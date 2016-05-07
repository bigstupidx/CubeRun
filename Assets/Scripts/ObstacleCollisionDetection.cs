using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Collider))]
[RequireComponent(typeof (Rigidbody))]
public class ObstacleCollisionDetection : MonoBehaviorHelper 
{
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.name.Contains ("Player")) 
		{
			var t = GetComponentInParent<ObstacleLogic> ().DoExplosion();
			t.transform.position = other.transform.position;
			gameManager.GameOver ();
		}
	}
}
