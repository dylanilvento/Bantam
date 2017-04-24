using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OverworldGameManager : MonoBehaviour {

	// Use this for initialization
	GameObject ship;

	public GameObject[] forts = new GameObject[4];
	public GameObject[] winScreen = new GameObject[3];

	bool[] upPos, downPos, leftPos, rightPos;
	bool wonGame = false;
	public Image up, down, left, right;
	int upCnt, downCnt, leftCnt, rightCnt;

	void Start () {
		upPos = new bool[forts.Length]; downPos = new bool[4]; leftPos = new bool[4]; rightPos = new bool[4];
		Transparency.SetTransparent(up);
		Transparency.SetTransparent(down);
		Transparency.SetTransparent(left);
		Transparency.SetTransparent(right);
		ship = GameObject.Find("Ship");

		

		if (GameStats.CheckForAllFortsBeat()) {
			Transparency.SetOpacity(winScreen, 1f);
			Time.timeScale = 0f;
			wonGame = true;


		}

		else if (GameStats.LastFortBeat != -1) {
			ship.transform.position = forts[GameStats.LastFortBeat].transform.position;
			ship.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 1f);
		}
		 
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && wonGame) {
			SceneManager.LoadScene(5);
			GameStats.StartGameOver();
		}
	}

	public void IncrUp (int index) {
		upPos[index] = true;
		Transparency.SetOpacity(up, 1f);
	}

	public void DecrUp (int index) {
		upPos[index] = false;
		if (CheckIfAllAreFalse(upPos)) Transparency.SetTransparent(up);
	}

	public void IncrDown (int index) {
		downPos[index] = true;
		Transparency.SetOpacity(down, 1f);
	}

	public void DecrDown (int index) {
		downPos[index] = false;
		if (CheckIfAllAreFalse(downPos)) Transparency.SetTransparent(down);
	}

	public void IncrLeft (int index) {
		leftPos[index] = true;
		Transparency.SetOpacity(left, 1f);
	}

	public void DecrLeft (int index) {
		leftPos[index] = false;
		if (CheckIfAllAreFalse(leftPos)) Transparency.SetTransparent(left);
	}

	public void IncrRight (int index) {
		rightPos[index] = true;
		Transparency.SetOpacity(right, 1f);
	}

	public void DecrRight (int index) {
		rightPos[index] = false;
		if (CheckIfAllAreFalse(rightPos)) Transparency.SetTransparent(right);
	}

	bool CheckIfAllAreFalse (bool[] arr) {
		foreach (bool val in arr) {
			if (val == true) {
				return false;
			}
		}

		return true;
	}
	
}
