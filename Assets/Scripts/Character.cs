using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {
	Rigidbody2D rb;
	BoxCollider2D boxCollider;
	CircleCollider2D circleCollider;


	SpriteRenderer sr;

	Animator anim;

	GameManager gm;
	public GameObject bullet, explosion;
	public float xAxis;

	[Range(0f, 1f)]
	public float movementSpeed;
	[Range(0f, 50f)]
	public float jumpDistance;
	public Image[] uiBullets = new Image[4], reloadBarFill = new Image[5], uiHealth = new Image[4];
	public Sprite bulletFill, bulletOutline, heartFill, heartOutline;
	int ammo = 3, health = 3;
	bool outOfAmmo = false, grounded = true, ducking = false, canShoot = true, invincible = false;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();	
		anim = GetComponent<Animator>();
		boxCollider = GetComponent<BoxCollider2D>();
		circleCollider = GetComponent<CircleCollider2D>();
		sr = GetComponent<SpriteRenderer>();
		gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
		Transparency.SetTransparent(reloadBarFill);
	}
	
	// Update is called once per frame
	void Update () {
		xAxis = Input.GetAxis("Horizontal");

		if (Input.GetKeyDown(KeyCode.UpArrow) && grounded) {
			rb.velocity = new Vector2(rb.velocity.x * 2.5f, jumpDistance);
			grounded = false;
		}

		if (xAxis > 0f && grounded) {
			rb.velocity = new Vector2 (movementSpeed, rb.velocity.y);
			if (transform.localScale.x < 0) transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
			
		}

		else if (xAxis < 0f && grounded) {
			rb.velocity = new Vector2 (-1 * movementSpeed, rb.velocity.y);
			if (transform.localScale.x > 0) transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
			
		}

		if (Input.GetKeyDown(KeyCode.Space) && !outOfAmmo && canShoot) {
			Shoot();
		}

		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			anim.SetBool("duck", true);
			ducking = true;
			boxCollider.enabled = false;

		}

		if (Input.GetKeyUp(KeyCode.DownArrow)) {
			anim.SetBool("duck", false);
			ducking = false;
			boxCollider.enabled = true;
		}

		anim.SetFloat("movement", Mathf.Abs(xAxis));
	}

	void Shoot () {
		if (!ducking) {
			GameObject spawnBullet = Instantiate(bullet, new Vector2(transform.position.x + CheckDirectionForBulletSpawn(), transform.position.y + 0.03f), Quaternion.identity);
			if (transform.localScale.x < 0) spawnBullet.transform.localScale = new Vector2 (spawnBullet.transform.localScale.x * -1, spawnBullet.transform.localScale.y);
		}

		else {
			GameObject spawnBullet = Instantiate(bullet, new Vector2(transform.position.x + CheckDirectionForBulletSpawn(), transform.position.y - 0.1f), Quaternion.identity);
			if (transform.localScale.x < 0) spawnBullet.transform.localScale = new Vector2 (spawnBullet.transform.localScale.x * -1, spawnBullet.transform.localScale.y);
		}

		uiBullets[ammo].sprite = bulletOutline;
		ammo--;

		if (ammo < 0) {
			outOfAmmo = true;
			StartCoroutine("Reload");
		}

		StartCoroutine("PauseShooting");

	}

	IEnumerator PauseShooting () {
		canShoot = false;
		yield return new WaitForSeconds(0.25f);
		canShoot = true;
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

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.name.Contains("Floor") || other.gameObject.name.Contains("Enemy Base") || other.gameObject.name.Contains("Platform")) {
			grounded = true;
		}	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name.Contains("Blade") && !invincible) {
			print("Works");
			
			if (health >= 0) {
				uiHealth[health].GetComponent<Image>().sprite = heartOutline;
				health--;
			
			}

			if (health < 0) {
				Die();
			}

			else {
				TakeDamage();
			}
		}
	}

	void TakeDamage () {
		rb.velocity = new Vector2(transform.localScale.x * -1f, 4f);
		StartCoroutine("FlashInvincibility");
	
	}

	void Die () {
		circleCollider.enabled = false;
		boxCollider.enabled = false;
		rb.velocity = new Vector2(transform.localScale.x * -1f, 4f);
		// StartCoroutine("FlashInvincibility");
		gm.CallGameOver();
	
	}

	IEnumerator FlashInvincibility () {
		int ii = 0;
		invincible = true;
		while (ii < 5) {
			sr.color = Color.red;
			yield return new WaitForSeconds(0.25f);
			sr.color = Color.white;
			yield return new WaitForSeconds(0.25f);
			ii++;
		}
		invincible = false;
	}
	
}
