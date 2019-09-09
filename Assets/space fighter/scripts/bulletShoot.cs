using UnityEngine;
using System.Collections;

public class bulletShoot : MonoBehaviour {

	public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		this.transform.rotation = Quaternion.AngleAxis (Vars.angle-90, Vector3.forward);
		//rb.AddRelativeForce(Vector3.up * 0.12f);
		rb.velocity = transform.TransformDirection (Vector2.up * 12);
		Destroy (this.gameObject, 2f);
	}
	

}
