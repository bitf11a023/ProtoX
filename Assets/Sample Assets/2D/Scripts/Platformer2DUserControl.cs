	using UnityEngine;

	[RequireComponent(typeof(PlatformerCharacter2D))]
	public class Platformer2DUserControl : MonoBehaviour 
	{
		private PlatformerCharacter2D character;
	    private bool jump = false;
		private bool c = false;
		private bool LongJump = false;
		TouchController1 t1;
		string touch;
		public GameObject _touchController;

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
			touch = t1.senseTouch();
		if(touch == "SingleTap")
			jump = true;
			//if(touch == "SwipeUp")
			//	jump = true;
//			if(touch == "LongJump")
//				LongJump = true;
			if (touch == "SwipeDown") c = true;
			if(Input.GetKey(KeyCode.X)) c = true;
			if (Input.GetButtonDown("Jump")) jump = true;
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
			character.Move(1, c , jump  );

	        // Reset the jump input once it has been used.
		    jump = false;
			c = false;
			//LongJump = false;
		}
	}
