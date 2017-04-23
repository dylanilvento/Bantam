using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("Explode");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Explode () {
		yield return new WaitForSeconds(0.3f);
		Destroy(gameObject);
	}
}
