using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

	public GameObject obj;
	public float spawnTimeMin;
	public float spawnTimeMax;


	// Use this for initialization
	void Start () {
		Spawn ();
	}

	void Spawn()
	{
		//Instantiate (obj [Random.Range (0, obj.Length)], transform.position, transform.rotation);
		Instantiate (obj, transform.position, Quaternion.identity);
		Invoke ("Spawn", spawnTimeMin);
	}

	public void Stopinvokation()
	{
		CancelInvoke ("Spawn");
	}

}
