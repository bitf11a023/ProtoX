using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawnerScript : MonoBehaviour {

	List<GameObject> hurdles = new List<GameObject>();
	List<GameObject> powerups = new List<GameObject>();
	Object[] hurdlesPrefab;
	Object[] powerupsPrefab;

	void Start()
	{
		hurdlesPrefab = Resources.LoadAll ("hurdles");
		powerupsPrefab = Resources.LoadAll ("powerups");
		SpawnHurdles ();
		SpawnPowerups ();
	}

	void Update()
	{
		if(powerups.Count > 0 && hurdles.Count > 0){
			if(powerups[powerups.Count-1] != null && hurdles[hurdles.Count-1] != null )
			{
				if(Mathf.Abs(powerups[powerups.Count-1].transform.position.x - hurdles[hurdles.Count-1].transform.position.x) < 1)
				{
					GameObject temp = hurdles[hurdles.Count-1] as GameObject;
					hurdles.Remove(temp);
					Destroy(temp.gameObject);
				}
			}
		}
	}

	public void SpawnHurdles()
	{
		//Instantiate (obj [Random.Range (0, obj.Length)], transform.position, transform.rotation);
		GameObject temphurdle = Instantiate (hurdlesPrefab[Random.Range(0,hurdlesPrefab.Length)], transform.position, Quaternion.identity) as GameObject;
		hurdles.Add (temphurdle);
		Invoke ("SpawnHurdles", Random.Range(2f,4f));
	}
		
	void SpawnPowerups()
	{
		//Instantiate (obj [Random.Range (0, obj.Length)], transform.position, transform.rotation);
		Vector3 randpos = new Vector3 (transform.position.x, transform.position.y + Random.Range (0f, 3f), transform.position.z);
		GameObject temppowerup = Instantiate (powerupsPrefab[Random.Range(0,powerupsPrefab.Length)], randpos, Quaternion.identity) as GameObject;
		powerups.Add (temppowerup);
		Invoke ("SpawnPowerups", Random.Range(2f,4f));
	}

}
