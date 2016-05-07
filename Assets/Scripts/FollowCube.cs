using UnityEngine;
using System.Collections;

public class FollowCube : MonoBehaviour
{
	public Transform toFollow;

	void FixedUpdate () 
	{
		transform.position = new Vector3 (0, 0, toFollow.position.z - 11);
	}
}
