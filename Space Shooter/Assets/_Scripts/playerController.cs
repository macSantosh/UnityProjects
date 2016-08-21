using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	Rigidbody rb;
	public int speed;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float zspeed = Input.GetAxis("Vertical") ;
		float xspeed = Input.GetAxis ("Horizontal");
		Vector3 movement = new Vector3 (xspeed, 0.0f, zspeed );
		//rb.AddForce (movement*speed, ForceMode.Force);
		rb.velocity = movement*speed;
		rb.position = new Vector3
			(
				Mathf.Clamp(rb.position.x, -2.7f, 2.7f),
				0.0f,
				Mathf.Clamp(rb.position.z, -1.25f, 5.0f)
			);
		rb.rotation = Quaternion.Euler(0, 0, rb.velocity.x*-5);
		//Debug.Log ("rb velocity " +rb.velocity.x);
	}
}
