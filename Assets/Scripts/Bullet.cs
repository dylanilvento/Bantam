using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;
    int modifier;

    // Use this for initialization
    void Start()
    {
        if (transform.localScale.x > 0)
        {
            modifier = 1;
        }
        else
        {
            modifier = -1;
        }
    }

	// Update is called once per frame
	void Update () {
		transform.position = new Vector2(transform.position.x + 0.02f * modifier, transform.position.y);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Blade"))
        {
            Destroy(gameObject);
            CreateExplosion();
        }
        else if (other.gameObject.name.Contains("Enemy"))
        {
            Destroy(gameObject);
            CreateExplosion();
        }
    }

    void CreateExplosion()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
