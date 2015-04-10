using UnityEngine;
using System.Collections;

public class motion : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2 (20f,0);
		//rigidbody2D.AddForce (new Vector2(20,0));

	}
}
