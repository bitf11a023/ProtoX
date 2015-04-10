using UnityEngine;
using System.Collections;

public class ScrollingScript : MonoBehaviour {

	public Transform[] obj;

	void Update()
	{
		float speed = 1f;
		for(int a=0; a<obj.Length; a++)
		{
			Transform abc = obj[a].transform;
//			abc.position.x=abc.position.x - speed;
//			obj[a].transform.position = abc.transform.position;
			obj[a].transform.position = new Vector3(abc.position.x - speed * Time.deltaTime, abc.transform.position.y, abc.transform.position.z);
			speed = speed - 0.5f;
		}
	}
}
