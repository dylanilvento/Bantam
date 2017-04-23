using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {


	int modifier;
	Rigidbody2D rb;
	float x, y, z;

	public GameObject explosion;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();

		if (transform.localScale.x > 0) {
			modifier = 1;
		}

		else {
			modifier = -1;
		}

		StartCoroutine("ScaleUp");
	}
	
	// Update is called once per frame
	void Update () {
		// transform.position = new Vector2(transform.position.x + 0.02f * modifier, transform.position.y);
		rb.velocity = new Vector2(x, y);
		transform.Rotate(new Vector3(0f, 0f, 10f * modifier));
		
	}

	IEnumerator ScaleUp () {

		while (transform.localScale.x < 1f) {
			transform.localScale = new Vector2 (transform.localScale.x +0.25f, transform.localScale.y +0.25f);
			yield return new WaitForSeconds(0.5f);
		}
		
		
	}

	public void SetVelocityVector (float x, float y, float z) {
		
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public void SetVelocityVector (float x, float y) {
		print(x + ", " + y);
		this.x = x;
		this.y = y;
	}

	public void SetVelocityVector (Vector2 newVel) {
		// print(x + ", " + y);
		this.x = newVel.x;
		this.y = newVel.y;
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.name.Contains("Edge Wall")) {
			// print("works");
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name.Contains("Bullet")) {
			Destroy(gameObject);
		}

		if (other.gameObject.name.Contains("Player")) {
			Destroy(gameObject);
			CreateExplosion();
		}
	}

	void CreateExplosion () {
		GameObject spawnedExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
		spawnedExplosion.GetComponent<SpriteRenderer>().sortingOrder = 3;
	}

}
