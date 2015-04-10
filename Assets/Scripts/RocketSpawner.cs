using UnityEngine;
using System.Collections;

public class RocketSpawner : MonoBehaviour {

	public Rigidbody2D rocket;
	public float speed = 4f;
	public float spawnMax = 4f;
	public float spawnMin = 1f;
	void Start()
	{
		Invoke ("shootrocket", 5);
	}

	void shootrocket()
	{
		//Vector2 yrand = transform.position;
		//yrand.y = yrand.y + Random.Range (0.5f, -1.0f);
		Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
		bulletInstance.velocity = new Vector2(-speed, 0);
		Invoke ("shootrocket", Random.Range (spawnMin, spawnMax));
	}

}
