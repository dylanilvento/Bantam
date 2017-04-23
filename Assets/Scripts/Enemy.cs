using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health;
	public GameObject explosion;
	GameManager gm;
	// Use this for initialization
	void Start () {
		health = Random.Range(5, 10);
		gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
		gm.EnemyCheckIn();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		// print(other.gameObject.name);
		if (other.gameObject.name.Contains("Bul")) {
			// print("works");
			health--;
			if (health <= 0) {
				print("exploding");
				gm.EnemyCheckOut();
				Explode();
			}
		}
	}

	// void OnCollisionEnter2D (Collision2D other) {
	// 	// print(other.gameObject.name);
	// 	if (other.gameObject.name.Contains("Bul")) {
	// 		// print("works");
	// 		health--;
	// 		if (health <= 0) {
	// 			print("exploding");
	// 			Explode();
	// 		}
			
	// 	}
	// }

	void Explode () {
		print("Explode!");

		float dampening = 0.06f;

		for (int ii = 0; ii< 15; ii++) {
			Instantiate(explosion, new Vector2(transform.position.x + (Random.Range(-dampening, dampening)), transform.position.y + (Random.Range(-dampening, dampening))), Quaternion.identity);
		}

		Destroy(gameObject);
	}
}
