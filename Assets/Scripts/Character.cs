using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {
	Rigidbody2D rb;

	Animator anim;
	public GameObject bullet;
	public float xAxis;

	[Range(0f, 1f)]
	public float movementSpeed;

	public Image[] uiBullets = new Image[4], reloadBarFill = new Image[5];
	public Sprite bulletFill, bulletOutline;
	int ammo = 3;
	bool outOfAmmo = false;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();	
		anim = GetComponent<Animator>();
		Transparency.SetTransparent(reloadBarFill);
	}
	
	// Update is called once per frame
	void Update () {
		xAxis = Input.GetAxis("Horizontal");
		if (xAxis > 0f) {
			rb.velocity = Vector2.right * movementSpeed;
			if (transform.localScale.x < 0) transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
			
		}
		if (xAxis < 0f) {
			rb.velocity = Vector2.left * movementSpeed;
			if (transform.localScale.x > 0) transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
			
		}

		if (Input.GetKeyDown(KeyCode.Space) && !outOfAmmo) {
			Shoot();
		}

		anim.SetFloat("movement", Mathf.Abs(xAxis));
	}

	void Shoot () {
		GameObject spawnBullet = Instantiate(bullet, new Vector2(transform.position.x + CheckDirectionForBulletSpawn(), transform.position.y + 0.03f), Quaternion.identity);
		if (transform.localScale.x < 0) spawnBullet.transform.localScale = new Vector2 (spawnBullet.transform.localScale.x * -1, spawnBullet.transform.localScale.y);
		
		uiBullets[ammo].sprite = bulletOutline;
		ammo--;

		if (ammo < 0) {
			outOfAmmo = true;
			StartCoroutine("Reload");
		}

	}

	float CheckDirectionForBulletSpawn () {
		float diff = 0.09f;
		if (transform.localScale.x < 0) return diff * -1f;
		else return diff;
	}

	IEnumerator Reload () {
		float reloadRate = 0.25f;

		foreach (Image fill in reloadBarFill) {
			yield return new WaitForSeconds(reloadRate);
			Transparency.SetOpacity(fill, 1f);
		}
		yield return new WaitForSeconds(reloadRate);
		foreach (Image shot in uiBullets) {
			shot.sprite = bulletFill;
		}

		Transparency.SetTransparent(reloadBarFill);

		outOfAmmo = false;
		ammo = 3;
		
	}
}
