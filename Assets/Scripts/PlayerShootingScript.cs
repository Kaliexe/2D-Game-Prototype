using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingScript : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform reticle;
	public Transform firePoint;
	
	public float fireRate = 0.5f;
	public float fireOffsetFromPoint = 1.1f;

	public float damage = 10f;

	public float bulletSpeed = 10f;
	
	public LayerMask doNotHitLayer;

	float timeToFire = 0f;
	

	// Use this for initialization
	void Start () {
		
		if (bulletPrefab == null) {
			Debug.Log("Error: Bullet Prefab is null");
		}

		if (firePoint == null) {
			Debug.LogError("Error:  FirePoint is null");
		}

		if (reticle == null) {
			Debug.LogError("Error:  recticle is null");
		}
	}
	
	// Update is called once per frame
	void Update () {

		getMousePosition();

		if (Input.GetMouseButton(0)) {

			timeToFire -= Time.deltaTime;

			if (timeToFire <= 0f) {

				fire();
				timeToFire = fireRate;
			}
		}
	}

	private void fire() {

		Vector2 dir = reticle.position - firePoint.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		angle -= 90f;
		//Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		//Quaternion rotation = Quaternion.LookRotation(dir);
		dir.Normalize();
		Quaternion quaternion = Quaternion.AngleAxis(angle, Vector3.forward);



		GameObject bullet = Instantiate(bulletPrefab, dir * fireOffsetFromPoint + new Vector2(firePoint.position.x, firePoint.position.y), quaternion);

		

		Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
		//rigidbody.AddForce(dir * Time.deltaTime * bulletSpeed);
		rigidbody.velocity = dir * bulletSpeed;
	}

	private void getMousePosition() {
		//recticle = new RectTransform()
		
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		reticle.position = mousePos;
	}
}
