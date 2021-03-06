﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Transparency : MonoBehaviour {

	//static instance of class
	static public Transparency instance;


	void Awake () {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		//instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetInstance () {
		//instance = this;
	}

	public static void SetOpacity (GameObject[] goArray, float opacity) {
		for (int i = 0; i < goArray.Length; i++) {
			if (goArray[i].GetComponent<Image>() != null) {
				Image currGO = goArray[i].GetComponent<Image>();
				currGO.color = new Color (currGO.color.r, currGO.color.g, currGO.color.b, opacity);
			}

			else if (goArray[i].GetComponent<Text>() != null) {
				Text currGO = goArray[i].GetComponent<Text>();
				currGO.color = new Color (currGO.color.r, currGO.color.g, currGO.color.b, opacity);
			}

			else if (goArray[i].GetComponent<SpriteRenderer>() != null) {
				SpriteRenderer currGO = goArray[i].GetComponent<SpriteRenderer>();
				currGO.color = new Color (currGO.color.r, currGO.color.g, currGO.color.b, opacity);
			}

			else if (goArray[i].GetComponent<TextMesh>() != null) {
				TextMesh currGO = goArray[i].GetComponent<TextMesh>();
				currGO.color = new Color(currGO.color.r, currGO.color.g, currGO.color.b, opacity);
			}
		}
	}

	public static void SetOpacity (GameObject go, float opacity) {
		// for (int i = 0; i < goArray.Length; i++) {
			if (go.GetComponent<Image>() != null) {
				Image currGO = go.GetComponent<Image>();
				currGO.color = new Color (currGO.color.r, currGO.color.g, currGO.color.b, opacity);
			}

			else if (go.GetComponent<Text>() != null) {
				Text currGO = go.GetComponent<Text>();
				currGO.color = new Color (currGO.color.r, currGO.color.g, currGO.color.b, opacity);
			}

			else if (go.GetComponent<SpriteRenderer>() != null) {
				SpriteRenderer currGO = go.GetComponent<SpriteRenderer>();
				currGO.color = new Color (currGO.color.r, currGO.color.g, currGO.color.b, opacity);
			}
		// }
	}

	public static void SetOpacity (Image img, float opacity) {
		// for (int i = 0; i < goArray.Length; i++) {
			
			// Image currGO = go.GetComponent<Image>();
			img.color = new Color (img.color.r, img.color.g, img.color.b, opacity);
		// }
	}

	public static void SetOpacity (SpriteRenderer[] srArray, float opacity) {
		for (int i = 0; i < srArray.Length; i++) {
			SpriteRenderer currSR = srArray[i];
			currSR.color = new Color (currSR.color.r, currSR.color.g, currSR.color.b, opacity);
		}
	}

	public static void SetTransparent (GameObject[] goArray) {
		for (int i = 0; i < goArray.Length; i++) {
			if (goArray[i].GetComponent<Image>() != null) {
				Image currGO = goArray[i].GetComponent<Image>();
				currGO.color = new Color (currGO.color.r, currGO.color.g, currGO.color.b, 0);
			}

			else if (goArray[i].GetComponent<Text>() != null) {
				Text currGO = goArray[i].GetComponent<Text>();
				currGO.color = new Color (currGO.color.r, currGO.color.g, currGO.color.b, 0);
			}

			else if (goArray[i].GetComponent<TextMesh>() != null) {
				TextMesh currGO = goArray[i].GetComponent<TextMesh>();
				currGO.color = new Color(currGO.color.r, currGO.color.g, currGO.color.b, 0);
			}
		}

	}

	public static void SetTransparent (Image[] imageArray) {
		for (int i = 0; i < imageArray.Length; i++) {
			imageArray[i].color = new Color (imageArray[i].color.r, imageArray[i].color.g, imageArray[i].color.b, 0);
		}
	}

	public static void SetTransparent (Image img) {
		// for (int i = 0; i < img.Length; i++) {
			img.color = new Color (img.color.r, img.color.g, img.color.b, 0);
		// }
	}

	public static void SetTransparent (List<GameObject> goArray) {
		foreach (GameObject item in goArray) {
			if (item.GetComponent<Image>() != null) {
				Image currGO = item.GetComponent<Image>();
				currGO.color = new Color (currGO.color.r, currGO.color.g, currGO.color.b, 0);
			}

			else if (item.GetComponent<Text>() != null) {
				Text currGO = item.GetComponent<Text>();
				currGO.color = new Color (currGO.color.r, currGO.color.g, currGO.color.b, 0);
			}
		}
	}

	public static void SetTransparent (GameObject go) {
		if (go.GetComponent<Image>() != null) {
			Image currGO = go.GetComponent<Image>();
			currGO.color = new Color (currGO.color.r, currGO.color.g, currGO.color.b, 0);
		}

		else if (go.GetComponent<Text>() != null) {
			Text currGO = go.GetComponent<Text>();
			currGO.color = new Color (currGO.color.r, currGO.color.g, currGO.color.b, 0);
		}

	}

	public static void UpFade (GameObject[] goArray) {
		//instance = this;
		//SetInstance();
		if (instance == null) {
			Debug.Log("Ain't working");
		}

		else {
			instance.StartCoroutine("FadeUp", goArray);
		}
		
	}

	public static void UpFade (List<GameObject> goArray) {
		//instance = this;
		//SetInstance();
		if (instance == null) {
			Debug.Log("Ain't working");
		}

		else {
			instance.StartCoroutine("FadeUp", goArray);
		}
		
	}

	public static void UpFade (GameObject go) {
		//instance = this;
		//SetInstance();
		if (instance == null) {
			Debug.Log("Ain't working");
		}

		else {
			print("calling it");
			instance.StartCoroutine("FadeUp", go);
		}
		
	}

	IEnumerator FadeUp (GameObject go) {
		while (go.GetComponent<Image>().color.a < 1.0f || go.GetComponent<Text>().color.a < 1f) {
			// for (int i = 0; i < goArray.Length; i++) {
				if (go.GetComponent<Image>() != null) {
					Image currGO = go.GetComponent<Image>();
					currGO.color = new Color (currGO.color.r, currGO.color.g, currGO.color.b, currGO.color.a + 0.1f);
				}
	
				else if (go.GetComponent<Text>() != null) {
					Text currGO = go.GetComponent<Text>();
					currGO.color = new Color (currGO.color.r, currGO.color.g, currGO.color.b, currGO.color.a + 0.1f);
				}
			// }
			yield return new WaitForSeconds(0.05f);
		}
	}

	IEnumerator FadeUp (GameObject[] goArray) {
		while (goArray[0].GetComponent<Image>().color.a < 1.0f) {
			for (int i = 0; i < goArray.Length; i++) {
				if (goArray[i].GetComponent<Image>() != null) {
					Image currGO = goArray[i].GetComponent<Image>();
					currGO.color = new Color (currGO.color.r, currGO.color.g, currGO.color.b, currGO.color.a + 0.1f);
				}
	
				else if (goArray[i].GetComponent<Text>() != null) {
					Text currGO = goArray[i].GetComponent<Text>();
					currGO.color = new Color (currGO.color.r, currGO.color.g, currGO.color.b, currGO.color.a + 0.1f);
				}
			}
			yield return new WaitForSeconds(0.05f);
		}
	}

	IEnumerator FadeUp (List<GameObject> goArray) {
		while (goArray[0].GetComponent<Image>().color.a < 1.0f) {
			foreach (GameObject item in goArray) {
				if (item.GetComponent<Image>() != null) {
					Image currGO = item.GetComponent<Image>();
					currGO.color = new Color (currGO.color.r, currGO.color.g, currGO.color.b, currGO.color.a + 0.1f);
				}
	
				else if (item.GetComponent<Text>() != null) {
					Text currGO = item.GetComponent<Text>();
					currGO.color = new Color (currGO.color.r, currGO.color.g, currGO.color.b, currGO.color.a + 0.1f);
				}
			}
			yield return new WaitForSeconds(0.05f);
		}
	}
}