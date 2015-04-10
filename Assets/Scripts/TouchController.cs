using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	GameObject Objecttomove;
	private Vector2 v2previous;
	private Vector2 v2current;
	private float fTouchDelta;
	int icomfort;

	void Update()
	{
		if(Input.touchCount == 1){
			if(Input.GetTouch(0).phase == TouchPhase.Began){
				v2previous = Input.GetTouch(0).position;
			}
			if(Input.GetTouch(0).phase == TouchPhase.Ended){
				v2current = Input.GetTouch(0).position;
				fTouchDelta = v2current.magnitude - v2previous.magnitude;
				
				if(Mathf.Abs(fTouchDelta) > icomfort){
					Debug.Log("Swipe");
					if(fTouchDelta>0){
						Debug.Log("Left and Bottom");
					}
					else{
						Debug.Log("Right and Top");
					}
				}
				else
				{
					
					if(Input.GetTouch(0).tapCount == 1){
						Debug.Log("Single Tap with on finger");
						
						RaycastHit hit;
						Ray ray;
						ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
						if(Physics.Raycast(ray,out hit)){
							Debug.Log(hit.transform.name);
							Objecttomove = GameObject.Find(hit.transform.name);
							
						}
						
					}
				}
			}
		}
	}
}
