using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioProjectile : MonoBehaviour
{
	public GameObject projectile;
	public Mario mario;
	public Vector2 velocity;
	bool canShoot = true;
	public Vector2 offset = new Vector2(0.4f, 0.1f);
	public float cooldown = 0.2f;

    private void Start()
    {
		mario = FindObjectOfType<Mario>();
    }

    void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && canShoot && mario.isFlower)
		{
			GameObject go = (GameObject)Instantiate(projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);

			go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);

			StartCoroutine(CanShoot());
		}

		if(Input.GetKeyDown(KeyCode.D))
        {
			transform.localScale = new Vector3(1, 1, 1);
		}
		else if(Input.GetKeyDown(KeyCode.A))
        {
			transform.localScale = new Vector3(-1, 1, 1);
		}
	}

	IEnumerator CanShoot()
	{
		canShoot = false;
		yield return new WaitForSeconds(cooldown);
		canShoot = true;
	}
}
