using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour {
	Rigidbody2D rb;
	public float rotationSpeed;
	public float movementSpeed;
	public GameObject puff;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		// if (Input.GetKey(KeyCode.UpKey))
		if (Input.GetKey(KeyCode.UpArrow)) {

			// rb.velocity = new Vector2(0f, 1f);
			// rb.AddRelativeForce(new Vector2(0f, movementSpeed));
			rb.velocity = transform.up * movementSpeed;
			float random = Random.Range(0f, 1f);

			if (random < 0.25f) {
				GameObject spawnedPuff = Instantiate(puff, transform.position, Quaternion.identity);
				spawnedPuff.GetComponent<Rigidbody2D>().velocity = gameObject.transform.up * -0.1f;
			}

			
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Rotate(Vector3.forward * rotationSpeed);
		}

		else if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Rotate(Vector3.back * rotationSpeed);
		}
	}


}
