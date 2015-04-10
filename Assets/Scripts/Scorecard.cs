using UnityEngine;
using System.Collections;

public class Scorecard : MonoBehaviour {

	public TextMesh scoreMesh;
	TouchController1 t1;
	public GameObject touchController;

	// Use this for initialization
	void Start () {
		t1 = touchController.GetComponent<TouchController1> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (t1.senseTouch () == "SingleTap") {
			RaycastHit2D hit = t1.GetHitObject();
			if(hit.collider.gameObject.transform.name == "Scorecard_Menu_button")
			{
				Application.LoadLevel("Menu");
			}
			else if(hit.collider.gameObject.transform.name == "Scorecard_Retry_button")
			{
				Application.LoadLevel("Level1");
			}
		}
	}

	public void SetScore(int s)
	{
		scoreMesh.text = s.ToString ();
	}

}
