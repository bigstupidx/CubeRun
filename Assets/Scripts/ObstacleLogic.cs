using UnityEngine;
using System.Collections;

public class ObstacleLogic : MonoBehaviorHelper 
{
	public GameObject explosion;

	bool behindPlayer = false;

	void OnEnable()
	{
		behindPlayer = false;

		int count = transform.childCount;

		int rand = Random.Range (0, count);

		foreach (Transform t in transform) 
		{
			t.gameObject.SetActive (false);
		}

		transform.GetChild (rand).gameObject.SetActive (true);
	}

	void Update()
	{
		transform.Translate (gameManager.obstacleSpeedMultiplicator * Vector3.back * gameManager._scrollSpeed * Time.deltaTime*5f);

		float dist = Vector3.Distance (cam.transform.position, transform.position);

		if (dist < 10)
			behindPlayer = true;

		if (behindPlayer && dist < 1) 
		{
			gameManager.point++;
			Destroy (gameObject);
		}
	}

	public Transform DoExplosion()
	{
		var go = Instantiate (explosion) as GameObject;

		return go.transform;
	}
		
}
