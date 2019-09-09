using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {


	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (0, 2 * Time.deltaTime, 0);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (0, -2 * Time.deltaTime, 0);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (2 * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (-2 * Time.deltaTime, 0, 0);
		}
	}
}
