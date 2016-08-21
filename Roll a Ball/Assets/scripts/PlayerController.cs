using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	// Use this for initialization
	private int score;
	public Text scoreText;
	private int maxScore;
	public static string GOLD_TAG ="gold";

	void Start () {
		score = 0;
		rb = GetComponent<Rigidbody>();
		scoreText.text = "SCORE "+ score;
		maxScore = GameObject.FindGameObjectsWithTag (GOLD_TAG).Length;
		//speed = 10.0f;
	}
	void update(){
	//print score
	}

	void FixedUpdate(){
		float HorizontalAxis = Input.GetAxis ("Horizontal");
		float verticalAxis = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (HorizontalAxis, 0.0f, verticalAxis);
		rb.AddForce (movement*speed, ForceMode.Impulse);
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag (GOLD_TAG)) {
			score = score + 1;
			other.gameObject.SetActive (false);
			scoreText.text = "SCORE "+ score;
		}
		if (maxScore <= score) {
			scoreText.text = "You Win!!";
		}
	}
}
