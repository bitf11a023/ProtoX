using UnityEngine;
using System.Collections;

public class TouchController1 : MonoBehaviour {

//	GameObject[] Objecttomove;
	private Vector2 v2previous;
	private Vector2 v2current;
	private float fTouchDelta;
	int minSwipeLength = 10;
	int maxSwipeLength = 30;
	RaycastHit2D hit;
//
//	void Awake()
//	{
//		Objecttomove = GameObject.FindGameObjectsWithTag("collide") as GameObject[];
//	}

//	void Update()
//	{
//		if(Input.touchCount == 1){
//			if(Input.GetTouch(0).phase == TouchPhase.Began){
//				v2previous = Input.GetTouch(0).position;
//			}
//			if(Input.GetTouch(0).phase == TouchPhase.Ended){
//				v2current = Input.GetTouch(0).position;
//				fTouchDelta = v2current.magnitude - v2previous.magnitude;
//				
//				if(Mathf.Abs(fTouchDelta) > minSwipeLenght){
//					Debug.Log("Swipe");
//					if(fTouchDelta>0){
//						Objecttomove[1].transform.position = new Vector2(Objecttomove[1].transform.position.x,Objecttomove[1].transform.position.y+1);
//						Debug.Log("Left and Bottom");
//					}
//					else{
//						Objecttomove[1].transform.position = new Vector2(Objecttomove[1].transform.position.x,Objecttomove[1].transform.position.y-1);
//						Debug.Log("Right and Top");
//					}
//				}
//				else
//				{
//					
//					if(Input.GetTouch(0).tapCount == 1){
//						Debug.Log("Single Tap with on finger");
//
//						Vector3 castFrom = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
//						hit = Physics2D.Raycast(castFrom,Vector2.zero);
//						if(hit.collider != null && hit.transform != null){
//							Debug.Log(hit.transform.name);
//							if(hit.transform.tag == "collide")
//							{
//								Objecttomove[0].transform.position = new Vector2(Objecttomove[0].transform.position.x+1,Objecttomove[0].transform.position.y);
//							}
//							
//						}
//						
//					}
//				}
//			}
//		}
//	}

	public RaycastHit2D GetHitObject()
	{
		return hit;
	}

	public string senseTouch()
	{
		string touchstatus="";
		if(Input.touchCount == 1){
			if(Input.GetTouch(0).phase == TouchPhase.Began){
				v2previous = Input.GetTouch(0).position;
			}
			if(Input.GetTouch(0).phase == TouchPhase.Moved){
				v2current = Input.GetTouch(0).position;
				fTouchDelta = v2current.magnitude - v2previous.magnitude;
				
				if(Mathf.Abs(fTouchDelta) > minSwipeLength){
					Debug.Log("Swipe");
					if(fTouchDelta>0){
//						Objecttomove[1].transform.position = new Vector2(Objecttomove[1].transform.position.x,Objecttomove[1].transform.position.y+1);
//						Debug.Log("Left and Bottom");
						touchstatus="SwipeUp";
					}
//					else if(fTouchDelta >= maxSwipeLength )
//					{
//						touchstatus = "LongJump";
//				}
					else{
//						Objecttomove[1].transform.position = new Vector2(Objecttomove[1].transform.position.x,Objecttomove[1].transform.position.y-1);
//						Debug.Log("Right and Top");
						touchstatus="SwipeDown";
					}
				}
				else if(Mathf.Abs(fTouchDelta) < 3)
				{
					
					if(Input.GetTouch(0).tapCount == 1){
//						Debug.Log("Single Tap with on finger");
						
						Vector3 castFrom = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
						hit = Physics2D.Raycast(castFrom,Vector2.zero);
						if(hit.collider != null && hit.transform != null){
//							Debug.Log(hit.transform.name);
							touchstatus="SingleTap";
	/*Code to be removed*/	if(hit.collider.gameObject.transform.name == "back_button")
	/*Code to be removed*/	{
	/*Code to be removed*/		Application.LoadLevel("Menu");
	/*Code to be removed*/	}
						}
						
					}
				}
			}
		}
		return touchstatus;
	}


}
