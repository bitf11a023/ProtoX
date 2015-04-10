using UnityEngine;
using System.Collections;

public class SpawnerScript1 : MonoBehaviour {

	public GameObject obj;
	public Transform a;
	public Transform b;
	float finalpos;
	public float spawnTime;

	// Use this for initialization
	void Start () {
		Spawn ();
		finalpos = b.position.x - a.position.x;
	}

	void Spawn()
	{
		b.position = new Vector3 (b.position.x + finalpos, b.position.y , b.position.z);
		Instantiate (obj, b.position, Quaternion.identity);
		Invoke ("Spawn", spawnTime);
	}

	public void Stopinvokation()
	{
		CancelInvoke ("Spawn");
	}

}
