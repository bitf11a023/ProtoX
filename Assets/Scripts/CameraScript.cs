﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public Transform player;

	void LateUpdate ()
	{
		transform.position = new Vector3 (player.position.x+5, 0.7f, -10);
	}
}