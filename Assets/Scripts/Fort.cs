using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fort : MonoBehaviour {
	public GameObject[] fortText;
	OverworldGameManager gm;
	bool canEnter = false, conquered = false;

	public int fortNum;

	GameObject ship;
	// Use this for initialization
	void Start () {
		Transparency.SetTransparent(fortText);
		ship = GameObject.Find("Ship");
		gm = GameObject.Find("Overworld Game Manager").GetComponent<OverworldGameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameStats.CheckSingleFortBeat(fortNum)) {
			if (ship.transform.position.x > transform.position.x + 1f) {
				gm.IncrLeft(fortNum);
			}
			else {
				gm.DecrLeft(fortNum);
			}

			if (ship.transform.position.x < transform.position.x - 1f) {
				gm.IncrRight(fortNum);
			}

			else {
				gm.DecrRight(fortNum);
			}

			if (ship.transform.position.y > transform.position.y + 0.65f) {
				gm.IncrDown(fortNum);
			}

			else {
				gm.DecrDown(fortNum);
			}

			if (ship.transform.position.y < transform.position.y - 0.65f) {
				gm.IncrUp(fortNum);
			}

			else {
				gm.DecrUp(fortNum);
			}
		}

		else {
			fortText[0].GetComponent<TextMesh>().text = "Conquered";
			fortText[1].GetComponent<TextMesh>().text = "Conquered";
			conquered = true;
			canEnter = false;
		}

		if (Input.GetKey(KeyCode.Space) && canEnter) {
			SceneManager.LoadScene(fortNum + 1);
		}
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name.Contains("Ship")) {
			Transparency.SetOpacity(fortText, 1f);
			if (!conquered) canEnter = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.name.Contains("Ship")) {
			Transparency.SetTransparent(fortText);
			if (!conquered) canEnter = false;
		}
	}
}
