using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeEjector : MonoBehaviour {

	public GameObject blade;
	public EjectorDirection direction;
	// Use this for initialization
	void Start () {
		StartCoroutine("Shoot");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Shoot () {

		
		while (true) {
			// print("shoot");
			float random = Random.Range(1f, 5f);
			yield return new WaitForSeconds(random);
			GameObject spawnedBlade = Instantiate(blade, transform.position, Quaternion.identity);
			spawnedBlade.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder - 1;
			spawnedBlade.GetComponent<Blade>().SetVelocityVector(GetEjectorDirectionVector());
		}
	}

	Vector2 GetEjectorDirectionVector () {
		if (direction == EjectorDirection.Left) {
			return new Vector2(-1f, 0f);
		}
		else if (direction == EjectorDirection.Right) {
			return new Vector2(1f, 0f);
		}
		else if (direction == EjectorDirection.UpLeft) {
			return new Vector2(-1f, 1f);
		}
		else if (direction == EjectorDirection.UpRight) {
			return new Vector2(1f, 1f);
		}
		else if (direction == EjectorDirection.Up) {
			return new Vector2(0f, 1f);
		}

		return new Vector2(0f, 0f);
	}
}
