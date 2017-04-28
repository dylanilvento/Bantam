using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public int fortNum;
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
			StartCoroutine("CallWinScreen");
		}
	}

	public void CallGameOver () {
		StartCoroutine("GameOver");
	}

	IEnumerator GameOver () {
		yield return new WaitForSeconds(2f);
		Transparency.SetOpacity(gameOverScreen, 1f);
		GameStats.StartGameOver();
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(0);
	}

	IEnumerator CallWinScreen () {
		Transparency.SetOpacity(winScreen, 1f);
		GameStats.ConquerFort(fortNum);
		yield return new WaitForSeconds(3f);
		// print("reload the overworld");
		SceneManager.LoadScene(5);
	}
}
