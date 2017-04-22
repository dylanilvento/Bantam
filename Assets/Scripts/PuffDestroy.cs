using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuffDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("DestroyPuff");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator DestroyPuff () {
		yield return new WaitForSeconds(0.4f);
		Destroy(gameObject);
	}
}
