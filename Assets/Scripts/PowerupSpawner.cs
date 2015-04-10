using UnityEngine;
using System.Collections;

public class PowerupSpawner : MonoBehaviour {

	public GameObject obj;
	Vector3 OriginalPos;
	public float spawnTimeMin;
	public float spawnTimeMax;

	// Use this for initialization
	void Start () {
		OriginalPos = transform.position;
	}

	void Update()
	{

	}
}
