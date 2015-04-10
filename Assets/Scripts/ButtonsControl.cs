using UnityEngine;
using System.Collections;

public class ButtonsControl : MonoBehaviour {

	public Sprite[] buttons;
	int PowerUpCount;
	SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		PowerUpCount = PlatformerCharacter2D.PowerUpCount;
	}
	
	// Update is called once per frame
	void Update () {
		PowerUpCount = PlatformerCharacter2D.PowerUpCount;
		sr.sprite = buttons[PowerUpCount] as Sprite;
	}
}
