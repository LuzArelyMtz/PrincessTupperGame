using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collisionWithEnemy : MonoBehaviour {

	public float playerHealth = 100;
	float startHelth = 0;
	public Text spacecraftHealth;
	void Start () {
		resetHealth (); 
	}

	void resetHealth() {
		playerHealth = 100;
		if (GameObject.Find ("playersHealth") != null) {
			spacecraftHealth = GameObject.Find ("playersHealth").GetComponent<Text> ();
			spacecraftHealth.text = "HEALTH: 100%";
		}
		if (PlayerPrefs.GetInt ("healthLevel") > 1) {
			playerHealth = playerHealth * (int)((PlayerPrefs.GetInt ("healthLevel") + 1) / 2);
		}
		startHelth = playerHealth; 
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name.Contains ("enemy")) {
			if (col.gameObject.name.Contains ("enemyBullet")) {
				//GameObject.Find ("playerHitSound").GetComponent<AudioSource> ().Play ();
				playerHealth -= 10 * Vars.bulletLevel;
			} else {
				playerHealth -= (int)col.gameObject.GetComponent <enemyHit> ().myHealth;
				col.gameObject.GetComponent <enemyHit> ().destroyEnemy ();
			}
			if (playerHealth <= 0) {
				playerHealth = 0;
				GameObject.Find ("Canvas").GetComponent <gameover> ().gameoverButton ();
				Destroy (GameObject.Find ("player"));
			}
			if (spacecraftHealth != null) {
				spacecraftHealth.text = "HEALTH: " + (int)((playerHealth / startHelth) * 100) + "%";
			} else {
				spacecraftHealth = GameObject.Find ("playersHealth").GetComponent<Text> ();
				spacecraftHealth.text = "HEALTH: " + (int)((playerHealth / startHelth) * 100) + "%";
			}
		} else if (col.gameObject.name.Contains ("asteroid")) {
			playerHealth -= (int)col.gameObject.GetComponent <enemyHit> ().myHealth;
			col.gameObject.GetComponent <enemyHit> ().destroyEnemy ();
		
			if (playerHealth <= 0) {
				playerHealth = 0;
				GameObject.Find ("Canvas").GetComponent <gameover> ().gameoverButton ();
				Destroy (GameObject.Find ("player"));
			}
			if (spacecraftHealth != null) {
				spacecraftHealth.text = "HEALTH: " + (int)((playerHealth / startHelth) * 100) + "%";
			} else {
				spacecraftHealth = GameObject.Find ("playersHealth").GetComponent<Text> ();
				spacecraftHealth.text = "HEALTH: " + (int)((playerHealth / startHelth) * 100) + "%";
			}
		}
	}
	public void calculateSpacecraftHealth() {
		resetHealth ();
		if (spacecraftHealth != null) {
			spacecraftHealth.text = "HEALTH: " + (int)((playerHealth / startHelth) * 100) + "%";
		}
	}

	void OnTriggerStay2D(Collider2D coll) {
		if (coll.gameObject.name == "star(Clone)") {
			coll.gameObject.GetComponent<destroyStar> ().enabled = true;
		}

	}
}
