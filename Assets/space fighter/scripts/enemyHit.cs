using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHit : MonoBehaviour {

	public float myHealth = 50;
	private int startHealth;
	void Start() {
		myHealth = myHealth * Vars.level;
		startHealth = (int)myHealth;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name.Contains("bullet")) {
			myHealth -= (PlayerPrefs.GetInt("damageLevel") * 10 + 30);
			if (myHealth <= 0) {
				GameObject.Find("bulletSound").GetComponent <AudioSource> ().Play ();
				Vars.score += startHealth;
				int number = Random.Range (1, 5);
				for (int i = 0; i < number; i++) {
					Instantiate (Resources.Load ("star"), new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
				}
				GameObject.Find ("game").transform.Find ("score").GetComponent<Text> ().text = "SCORE: " + Vars.score;

				if (transform.Find ("score") != null) {
					GameObject g = transform.Find ("score").gameObject;
					g.transform.parent = null;
					g.transform.localRotation = Quaternion.Euler(0,0,0);
					g.GetComponent<scoreText> ().enabled = true;
					g.GetComponent<scoreText> ().score = startHealth;
				}

				if (this.gameObject.transform.parent != null) {
					Destroy (this.gameObject.transform.parent.gameObject);
				}

				Destroy (this.gameObject);
			} else {
				GameObject.Find("hitSound").GetComponent <AudioSource> ().Play ();
				Destroy (col.gameObject);

			}
		}
	}

	public void destroyEnemy() {
		if (this.gameObject.transform.parent != null) {
			Destroy (this.gameObject.transform.parent.gameObject);
		}

		Destroy (this.gameObject);
	}
}
