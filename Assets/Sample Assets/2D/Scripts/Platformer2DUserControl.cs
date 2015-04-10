using UnityEngine;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour 
{
	private PlatformerCharacter2D character;
    private bool jump;
	private bool c;
	TouchController1 t1;
	string touch;
	public GameObject _touchController;


	private Vector2 v2previous;
	private Vector2 v2current;
	private float fTouchDelta;
	int minSwipeLenght = 12;
	RaycastHit2D hit;

	void Awake()
	{
		t1 = _touchController.GetComponent<TouchController1> ();
		character = GetComponent<PlatformerCharacter2D>();
	}

    void Update ()
    {
        // Read the jump input in Update so button presses aren't missed.
#if CROSS_PLATFORM_INPUT
        if (CrossPlatformInput.GetButtonDown("Jump")) jump = true;
#else
//		touch = t1.senseTouch();
//		if(touch == "SwipeUp")
//			jump = true;
//		if (touch == "SwipeDown") c = true;
		if(Input.GetKey(KeyCode.X)) c = true;
		if(Input.GetKey(KeyCode.Space)) jump = true;

	/////////////////////////////////////////////////////////////////////////////////////////////

		/////////////////////////Touch Begin////////////////////////////////
		if(Input.touchCount == 1){
			if(Input.GetTouch(0).position.x < Screen.width/2){
				if(Input.GetTouch(0).phase == TouchPhase.Began){
					v2previous = Input.GetTouch(0).position;
				}
				/////////////////////////Touch Stationary////////////////////////////////
				if(Input.GetTouch(0).phase == TouchPhase.Stationary){
					v2current = Input.GetTouch(0).position;
					fTouchDelta = v2current.magnitude - v2previous.magnitude;
					
					if(Mathf.Abs(fTouchDelta) < minSwipeLenght){	
						if(Input.GetTouch(0).tapCount == 1){
							jump = true;
						}
					}
				}
				/////////////////////////Touch End////////////////////////////////
				if(Input.GetTouch(0).phase == TouchPhase.Ended){
					jump=false;
				}
			}
			else
			{
				if(Input.GetTouch(0).phase == TouchPhase.Began){
					v2previous = Input.GetTouch(0).position;
				}
				/////////////////////////Touch Move////////////////////////////////
				if(Input.GetTouch(0).phase == TouchPhase.Moved){
					v2current = Input.GetTouch(0).position;
					fTouchDelta = v2current.magnitude - v2previous.magnitude;
					
					if(Mathf.Abs(fTouchDelta) > minSwipeLenght){
						if(fTouchDelta>0){
							// SwipeUp
						}
						else{
							c = true;
						}
					}
				}
			}
		}

	//////////////////////////////////////////////////////////////////////////////////////////////


#endif

    }

	void FixedUpdate()
	{
		// Read the inputs.
	/*	bool crouch = Input.GetKey(KeyCode.LeftControl);
		#if CROSS_PLATFORM_INPUT
		float h = CrossPlatformInput.GetAxis("Horizontal");
		#else
		float h = Input.GetAxis("Horizontal");
		#endif
	*/
		// Pass all parameters to the character control script.
		character.Move(1, c , jump);

        // Reset the jump input once it has been used.
	    jump = false;
		c = false;
	}
}
