using UnityEngine;
using System.Collections;

public class RocketSpawner : MonoBehaviour {

	public Rigidbody2D rocket;
	public float speed = 4f;
	public float spawnMax = 4f;
	public float spawnMin = 1f;
	public GameObject robotObj;
	Vector2[] position =new  Vector2[5];
	int i=0;
	void Start()
	{
		Invoke ("RobotPositions", 0.5f);
		Invoke ("shootrocket", 5);
	}
	void RobotPositions(){
		if (i == 5)
						i = 0;
		position[i] = robotObj.transform.position;
		i++;
		Invoke ("RobotPositions", 0.5f);
		}
	void shootrocket()
	{
		//Vector2 yrand = transform.position;
		//yrand.y = yrand.y + Random.Range (0.5f, -1.0f);
		Vector2 robPos = CalculateAverage ();
		Vector2 finalvector = new Vector2 (transform.position.x, robPos.y);
		Rigidbody2D bulletInstance = Instantiate(rocket, finalvector, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
		bulletInstance.velocity = new Vector2(-speed, 0);
		Invoke ("shootrocket", Random.Range (spawnMin, spawnMax));
	}
	Vector2 CalculateAverage()
	{
		Vector2 RobotPosAverage = new Vector2(0,0);
		for (int i = 0; i < 5; i++) {
			RobotPosAverage = RobotPosAverage + position[i];
				}
		return		RobotPosAverage/5;
	}
}
