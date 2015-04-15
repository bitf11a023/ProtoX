			using UnityEngine;

			public class PlatformerCharacter2D : MonoBehaviour 
			{
				bool facingRight = true;							// For determining which way the player is currently facing.

				[SerializeField] float maxSpeed = 10f;				// The fastest the player can travel in the x axis.
				[SerializeField] float jumpForce = 0f;

		[SerializeField] float MaxjumpForce = 450f;				// Amount of force added when the player jumps.	

				[Range(0, 1)]
				[SerializeField] float crouchSpeed = 1f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
				
				[SerializeField] bool airControl = false;			// Whether or not a player can steer while jumping;
				[SerializeField] LayerMask whatIsGround;			// A mask determining what is ground to the character
				
				Transform groundCheck;								// A position marking where to check if the player is grounded.
				float groundedRadius = .2f;							// Radius of the overlap circle to determine if grounded
				bool grounded = false;								// Whether or not the player is grounded.
				Transform ceilingCheck;								// A position marking where to check for ceilings
				float ceilingRadius = .01f;							// Radius of the overlap circle to determine if the player can stand up
				Animator anim;										// Reference to the player's animator component.
				public GameObject robot_explosion;
				public GameObject robot_slide;
				//bool doubleJumps = false;
				public float maxFuel = 100f;
				float currentFuel;
				public float dFuel = 10f;
				ScoreCal s = new ScoreCal();
				public static int PowerUpCount;
				LeaderBoardScript lb = new LeaderBoardScript();

				GameObject[] sp;
				GameObject plat_s;
				GameObject sp1;
				GameObject Scorecard;
				//ParticleSystem robot_particles;


			    void Awake()
				{
					// Setting up references.
					groundCheck = transform.Find("GroundCheck");
					ceilingCheck = transform.Find("CeilingCheck");
					anim = GetComponent<Animator>();
				}

				void Start()
				{
					currentFuel = maxFuel;
					Scorecard = GameObject.Find("Scorecard");
					PowerUpCount = 0;
					sp = GameObject.FindGameObjectsWithTag("Spawner");
					plat_s = GameObject.FindGameObjectWithTag("Platform_Spawner");
					sp1 = GameObject.FindGameObjectWithTag("Spawner1");
					Scorecard.SetActive (false);

				}

				void FixedUpdate()
				{
					// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
					grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
					//Debug.Log (grounded);
			//		anim.SetBool("Ground", grounded);

					// Set the vertical animation
					anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
					//Debug.Log (rigidbody2D.velocity.y);
		//			if (grounded)
		//				doubleJumps = false;
				}


				public void Move(float move, bool crouch, bool jump)
				{


					// If crouching, check to see if the character can stand up
					//		if(!crouch && anim.GetBool("Crouch"))
					//		{
					//			// If the character has a ceiling preventing them from standing up, keep them crouching
					//			if( Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround))
					//				crouch = true;
					//		}

					// Set whether or not the character is crouching in the animator

			if (crouch) {
						
				var slide = Instantiate (robot_slide, transform.position  , transform.rotation);
					Destroy (slide,2f);
			}
					anim.SetBool ("Crouch", crouch);



							//only control the player if grounded or airControl is turned on
							if (grounded || airControl) {
									// Reduce the speed if crouching by the crouchSpeed multiplier
									move = (crouch ? move * crouchSpeed : move);
			currentFuel = 100;
									// The Speed animator parameter is set to the absolute value of the horizontal input.
									anim.SetFloat ("Speed", Mathf.Abs (move));

									// Move the character
									rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
						
			//			// If the input is moving the player right and the player is facing left...
			//			if(move > 0 && !facingRight)
			//				// ... flip the player.
			//				Flip();
			//			// Otherwise if the input is moving the player left and the player is facing right...
			//			else if(move < 0 && facingRight)
			//				// ... flip the player.
			//				Flip();
							}

							// If the player should jump...
							//if ((grounded || !doubleJumps) && jump) {
			if (jump && currentFuel > 0.0f) {
						// Add a vertical force to the player.
						//anim.SetBool("Ground", false);
						currentFuel = currentFuel - 
				dFuel ;
						anim.SetBool ("Jump", jump);
						rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, 0);
						//if(jumpForce <= MaxjumpForce)
						rigidbody2D.AddForce (new Vector2 (0f, jumpForce));
						//doubleJumpUsed = true;
			Debug.Log(currentFuel);
				} else {
						anim.SetBool ("Jump", jump);

			}
	//			    if (grounded && longJump) {
	//			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, 0);
	//			rigidbody2D.AddForce (new Vector2 (0f, jumpForce+150f));
	//		}
		}
		

				void OnCollisionEnter2D(Collision2D collider_object)
				{
					if (collider_object.gameObject.transform.tag == "hurdles") {
						EndGame();
							}
				}

				void OnTriggerEnter2D(Collider2D collider_object)
				{
					if (collider_object.gameObject.transform.tag == "powerup") {
						if(PowerUpCount>=0 && PowerUpCount <=8)
						{
							if(PowerUpCount != 8)
								PowerUpCount++;
							Destroy(collider_object.gameObject);
							s.Addscore(30);
						}
					}
				}
				
				void Flip ()
				{
					// Switch the way the player is labelled as facing.
					facingRight = !facingRight;
					
					// Multiply the player's x local scale by -1.
					Vector3 theScale = transform.localScale;
					theScale.x *= -1;
					transform.localScale = theScale;
				}

				public void EndGame()
				{

					lb.UpdateLeaderBoard((int)s.Getscore());
					Platformer2DUserControl puc = transform.GetComponent<Platformer2DUserControl>();
					PlatformerCharacter2D pc = transform.GetComponent<PlatformerCharacter2D>();
					foreach(GameObject a in sp)
					{
						SpawnerScript ss =  a.GetComponent<SpawnerScript>();
						ss.Stopinvokation();
						a.SetActive(false);
					}
					PlatformSpawner p = plat_s.GetComponent<PlatformSpawner>();
					p.Stopinvokation();
					plat_s.SetActive(false);
					SpawnerScript1 ss1 = sp1.GetComponent<SpawnerScript1>();
					ss1.Stopinvokation();
					sp1.SetActive(false);
					puc.enabled = false;
					pc.enabled = false;
					s.Setincrement(0);
					if (robot_explosion) {
									var explosion = Instantiate (robot_explosion, transform.position, transform.rotation);
									Destroy (explosion,1f);
							}
					anim.SetBool("Destroy",true);
					Scorecard.SetActive(true);
					Scorecard.GetComponent<Scorecard> ().SetScore ((int)s.Getscore ());
									}

				 public  Vector2 RobotPosition()
					{
						return transform.position;
					}
			}
