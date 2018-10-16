using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime : MonoBehaviour {

	public float destroyTime = 3f;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, destroyTime);
		//StartCoroutine(kill());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//IEnumerator kill() {

	//	float timeToLive = destroyTime;
	//	while (timeToLive > 0f) {
	//		timeToLive -= Time.deltaTime;
	//	}
	//	Destroy(this);
	//	yield return null;
	//}
}
