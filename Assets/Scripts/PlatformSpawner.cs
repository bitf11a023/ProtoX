using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour {

	public GameObject[] obj;
	public Transform a;
	public Transform b;
	float finalpos;
	public float spawnTime;
	List<GameObject> ground = new List<GameObject>();
	
	// Use this for initialization
	void Start () {
//		maxspeed = Playercontroller.maxSpeed;
//		spawnTime = spawnTime / maxspeed;
		StartCoroutine("Spawn");
		finalpos = b.position.x - a.position.x;
		Invoke("Destroyer", 4.7f);
	}

	void Update()
	{
		Breakroof ();
	}

//	void FixedUpdate() {
//		if (maxspeed != Playercontroller.maxSpeed) {
//			maxspeed = Playercontroller.maxSpeed;
//			spawnTime = spawnTime/maxspeed;
//		}
//	}
	
	IEnumerator Spawn()
	{
		while(true){
			b.position = new Vector3 (b.position.x + finalpos, b.position.y , b.position.z);
			ground.Add(Instantiate (obj[Random.Range(0,obj.Length)], b.position, Quaternion.identity)as GameObject);
			yield return new WaitForSeconds(spawnTime);
		}
	}

	void Destroyer()
	{
		GameObject tempobj = null;
//		foreach (GameObject g in ground) {
//			tempobj = g;
//			break;
//		}
		tempobj = ground [0];
		ground.Remove (tempobj);
		Destroy (tempobj);
		Invoke("Destroyer", spawnTime);
	}

	void Breakroof()
	{
		if (ScoreCal.score > 340f) {
			GameObject o = ground[ground.Count-4];
			GameObject obj1=null;
			foreach(Transform a in o.transform)
			{
				Transform t=a;
				obj1 = t.gameObject;
			}
			obj1.rigidbody2D.isKinematic = false;
		}
	}

	public void Stopinvokation()
	{
		CancelInvoke ("Spawn");
		CancelInvoke ("Destroyer");
	}

}
