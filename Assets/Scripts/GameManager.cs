using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	int enemyCnt = 0;
	public GameObject uiCnt, uiCntBG, winScreen;
	public GameObject[] gameOverScreen;

	// Use this for initialization
	void Start () {
		Transparency.SetTransparent(winScreen);
		Transparency.SetTransparent(gameOverScreen);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnemyCheckIn () {
		enemyCnt++;
		uiCnt.GetComponent<Text>().text = enemyCnt + "";
		uiCntBG.GetComponent<Text>().text = enemyCnt + "";	
	}

	public void EnemyCheckOut () {
		enemyCnt--;
		uiCnt.GetComponent<Text>().text = enemyCnt + "";
		uiCntBG.GetComponent<Text>().text = enemyCnt + "";

		if (enemyCnt <= 0) {
			Transparency.SetOpacity(winScreen, 1f);
		}
	}

	public void CallGameOver () {
		StartCoroutine("GameOver");
	}

	IEnumerator GameOver () {
		yield return new WaitForSeconds(2f);
		Transparency.SetOpacity(gameOverScreen, 1f); 
	}
}
