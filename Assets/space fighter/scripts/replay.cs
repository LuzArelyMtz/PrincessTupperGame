using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class replay : MonoBehaviour {

	public void replayGame () {
        SceneManager.LoadScene("gameScene");
		GameObject.Find ("buttonClick").GetComponent<AudioSource> ().Play ();
		if (GameObject.Find ("game").transform.Find ("score") != null) {
			GameObject.Find ("game").transform.Find ("score").GetComponent <Text> ().text = "SCORE: 11";
			GameObject.Find("game").transform.Find ("playersHealth").GetComponent <Text> ().text = "HEALTH: 1000%";
		}

		Vars.score = 0;
		GameObject[] enemys = GameObject.FindGameObjectsWithTag ("enemy");
		for (int i = 0; i < enemys.Length; i++) {
			Destroy (enemys [i]);
		}
		GameObject[] bullets = GameObject.FindGameObjectsWithTag ("bullet");
		for (int i = 0; i < bullets.Length; i++) {
			Destroy (bullets [i]);
		}
		GameObject[] stars = GameObject.FindGameObjectsWithTag ("star");
		for (int i = 0; i < stars.Length; i++) {
			Destroy (stars [i]);
		}

		GameObject.Find ("Canvas").GetComponent<gameover> ().gameoverButton ();
		GameObject g = Instantiate (Resources.Load ("player"), new Vector2 (0, 0), Quaternion.identity) as GameObject;
		g.name = "player";
		g.GetComponent<EnemySpawn> ().enabled = true;
		GameObject.Find ("camera").GetComponent<smoothCamera2D> ().newTarget ();
		Vars.level = 1;
		if (GameObject.Find ("playerSpacecraft") != null) {
			GameObject.Find ("playerSpacecraft").GetComponent<collisionWithEnemy> ().calculateSpacecraftHealth ();
		}
		Vars.gameover = false;
	}
	public void replayGameFromPauseMenu() {
        SceneManager.LoadScene("gameScene");
        Vars.gameover = false;
		if (GameObject.Find ("game").transform.Find ("score") != null) {
			GameObject.Find ("game").transform.Find ("score").GetComponent <Text> ().text = "SCORE: 0";
		}
		Vars.score = 0;
		GameObject[] enemys = GameObject.FindGameObjectsWithTag ("enemy");
		for (int i = 0; i < enemys.Length; i++) {
			Destroy (enemys [i]);
		}
		GameObject[] bullets = GameObject.FindGameObjectsWithTag ("bullet");
		for (int i = 0; i < bullets.Length; i++) {
			Destroy (bullets [i]);
		}
		GameObject[] stars = GameObject.FindGameObjectsWithTag ("star");
		for (int i = 0; i < stars.Length; i++) {
			Destroy (stars [i]);
		}
		if (GameObject.Find ("player") != null) {
			GameObject.Find ("player").transform.position = new Vector2 (0, 0);
		}
		Vars.level = 1;
		if (GameObject.Find ("playerSpacecraft") != null) {
			GameObject.Find ("playerSpacecraft").GetComponent<collisionWithEnemy> ().calculateSpacecraftHealth ();
		}
	}
}
