using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour {


	TouchController1 t1;
	public GameObject _touchController;
	public TextMesh[] Score;
	private int[] scoreList;
	//private List<string> scoreList;
	GameObject LeaderBoardWindow;

	void Start () {
		t1 = _touchController.GetComponent<TouchController1> ();
		LeaderBoardWindow = GameObject.Find("Untitled-1") as GameObject;
		scoreList = LeaderBoardScript.Scores;
		//scoreList = new List<string>(LeaderBoardScript.Scores);
		LeaderBoardWindow.SetActive(false);
		SetScoreOnLeaderBoard ();
	}

	void Update () {
		if (t1.senseTouch () == "Tap") {
			RaycastHit2D hit = t1.GetHitObject();
			if(hit.collider.gameObject.transform.name == "Play_button")
			{
				Application.LoadLevel("Level1");
			}
			if(hit.collider.gameObject.transform.name == "LeaderBoard_button")
			{
				LeaderBoardWindow.SetActive(true);
			}
			if(hit.collider.gameObject.transform.name == "Back")
			{
				LeaderBoardWindow.SetActive(false);
			}
			}
		}

	void SetScoreOnLeaderBoard()
	{
		//Score [0].text = Application.dataPath;
		Score [0].text = scoreList[0].ToString();
		int i = 1;
		foreach (int s in scoreList) {
			Score[i].text = s.ToString();
			//Debug.Log (s);
			i++;
		}
	}

}
