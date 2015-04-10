using UnityEngine;
using System.Collections;

public class ScoreCal : MonoBehaviour {

	static public float score=0f;
	private TextMesh scoreMesh;
	static public int increment;

	void Start(){
		score = 0f;
		scoreMesh = GetComponent<TextMesh> ();
		increment = 7;
	}

	void Update(){
		scoreMesh.text = ((int)score).ToString();
		score = score + Time.deltaTime*increment;
	}

	public void Addscore(int s)
	{
		score = score + s;
	}

	public void Setscore(int s)
	{
		score = s;
	}

	public float Getscore()
	{
		return score;
	}

	public void Setincrement(int c)
	{
		increment = c;
	}
}
