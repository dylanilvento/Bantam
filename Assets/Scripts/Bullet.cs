using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	int modifier;
	// Use this for initialization
	void Start () {
		if (transform.localScale.x > 0) {
			modifier = 1;
		}

		else {
			modifier = -1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2(transform.position.x + 0.02f * modifier, transform.position.y);
	}
}
