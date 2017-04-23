using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		print(other.gameObject.name);
		if (other.gameObject.name.Contains("Bul")) {
			print("works");
			health--;
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		print(other.gameObject.name);
		if (other.gameObject.name.Contains("Bul")) {
			print("works");
			health--;
		}
	}
}
