using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidStart : MonoBehaviour {

	public CircleCollider2D collider1;
	public CircleCollider2D collider2;
	public Transform asteroidTransform;
	float timer = 0;
	float scale = 0;

	void Update () {
		timer += Time.deltaTime;
		if (timer >= 0.01f) {
			timer = 0;
			scale += 0.01f;
				if (scale > 1f) {
					collider1.enabled = true;
					collider2.enabled = true;
					Destroy (GetComponent<asteroidStart> ());
				}
			asteroidTransform.localScale = new Vector2 (scale, scale);
		}
	}
}
