using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using FileHandling;

public class LeaderBoardScript : MonoBehaviour {

	public static int[] Scores = {0,0,0,0,0}; 
	//public static List<string> Scores = new List<string> ();
	public int HighScore=0;

	void Awake(){
		ReadLeaderBoard ();
	}

	void OnEnable(){
		ReadLeaderBoard ();
	}

	void Start(){
		ReadLeaderBoard ();
	}

	void ReadLeaderBoard()
	{
		int a = 0;
		if (FileIO.HasKey ("HighestScore")) {
			HighScore = FileIO.GetInt ("HighestScore");
		} 
		else{
			FileIO.SetInt ("HighestScore", 0);
			FileIO.Flush();
		}
		for(int i = 1 ;i<=5; i++)
		{
			if(FileIO.HasKey("Score"+ i))
			{
				Scores[a] = FileIO.GetInt("Score"+ i);
				a++;
			}
			else{
				FileIO.SetInt ("Score" + i, 0);
				FileIO.Flush();
			}
		}

//		XmlDocument xmldoc = new XmlDocument ();
//		xmldoc.Load(Application.dataPath + "/LeaderBoard.xml");
//		XmlNodeList topscore = xmldoc.GetElementsByTagName("TopScore");
//		foreach (XmlNode obj in topscore) {
//			HighScore = obj.InnerText;		
//		}
//		XmlNodeList ScoreList = xmldoc.GetElementsByTagName("Score");
//		foreach (XmlNode obj in ScoreList) {
//			Scores.Add(obj.InnerText);
//			Debug.Log (obj.InnerText);
//		}
	}

	public void UpdateLeaderBoard(int Score)
	{
		int existingTopScore;
		existingTopScore = FileIO.GetInt("HighestScore");
		if(existingTopScore<Score){
			FileIO.SetInt("HighestScore",Score);
			FileIO.Flush();
			Debug.Log(FileIO.GetInt("HighestScore"));
			}
		for(int i = 1 ;i<=5; i++)
		{
			int existingscore=0,tempscore=0;
			tempscore=Score;
			existingscore = FileIO.GetInt("Score"+ i);
			if(existingscore<Score)
			{
				Score=existingscore;
				FileIO.SetInt("Score"+ i,tempscore);
				FileIO.Flush();
				Debug.Log(FileIO.GetInt("Score"+i));
			}
		}

//		XmlDocument xmlDoc = new XmlDocument();
//		xmlDoc.Load(Application.dataPath + "/LeaderBoard.xml");
//		XmlNodeList TopScoreNodes = xmlDoc.GetElementsByTagName("TopScore");
//		foreach(XmlNode topscoreNode in TopScoreNodes)
//		{
//			int existingTopScore = int.Parse(topscoreNode.InnerText);
//			if(existingTopScore<Score){
//				topscoreNode.InnerText = Score.ToString();
//			}
//		}
//		XmlNodeList ScoreNodes = xmlDoc.GetElementsByTagName("Score");
//		int tempscore;
//		foreach(XmlNode scoreNode in ScoreNodes)
//		{
//			tempscore=Score;
//			int existingScore = int.Parse(scoreNode.InnerText);
//			if(existingScore<Score){
//				Score = int.Parse(scoreNode.InnerText);
//				scoreNode.InnerText = tempscore.ToString();
//			}
//		}
//		xmlDoc.Save(Application.dataPath + "/LeaderBoard.xml");
	}
}
