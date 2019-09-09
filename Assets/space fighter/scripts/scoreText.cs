using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreText : MonoBehaviour {

	public int score = 0;
	public TextMesh text;
	float timer = -2;
	float transparency = 1;
	void Start () {
		text.characterSize = 0.3f;
		text.text = "+" + score;
	}

	void Update () {
		timer += Time.deltaTime;
		if (timer >= 0.01f) {
			timer = 0;
			transparency -= 0.01f;
			text.color = new Color (1, 1, 1, transparency);
			if (transparency <= 0) {
				Destroy (this.gameObject);
			}
		}
	}
}
