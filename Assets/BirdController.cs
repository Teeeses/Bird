using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {

	bool direction = true;

	float sum = 50;
	float time;
	float g;
	float ang = 80;

	float startSpeed = 0.014f;

	float height;

	Rigidbody2D rigidbody;
	float maxSpeed = 4.0f;
	float jumpSpeed = 12f;

	// Use this for initialization
	void Start () {
		Camera camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
		height = 0.12f;
		g = (startSpeed * startSpeed * Mathf.Sin (Mathf.Deg2Rad*ang) * Mathf.Sin (Mathf.Deg2Rad*ang)) / (2 * height); 
		rigidbody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		//Move ();
	}
		
	public void MoveRight() {
		rigidbody.velocity = new Vector2 (maxSpeed, jumpSpeed);
		time = 0;
		direction = false;
		Vector3 theScale = transform.localScale;
		theScale.y = -1;
		transform.localScale = theScale;

		Quaternion theRotation = transform.localRotation;
		transform.rotation = Quaternion.Euler(0, 0, 270 - sum);
	}

	public void MoveLeft() {
		rigidbody.velocity = new Vector2 (-maxSpeed, jumpSpeed);
		time = 0;
		direction = true;
		Vector3 theScale = transform.localScale;
		theScale.y = 1;
		transform.localScale = theScale;

		Quaternion theRotation = transform.localRotation;
		transform.rotation = Quaternion.Euler(0, 0, 270 + sum);
	}

	void Move ()
	{
		Vector3 nVec = transform.position;
		if (!direction)
			nVec.x += startSpeed * time * Mathf.Cos (Mathf.Deg2Rad * ang);
		if (direction)
			nVec.x -= startSpeed * time * Mathf.Cos (Mathf.Deg2Rad*ang);

		float different = startSpeed * time * Mathf.Sin(Mathf.Deg2Rad*ang) - (g * time * time) / 2;
		if (different > 0.4f)
			different = 0.4f;
		if (different < -0.4f)
			different = -0.4f;

		Debug.Log (startSpeed * time * Mathf.Cos (Mathf.Deg2Rad * ang));
		nVec.y += different;

		time++;
		transform.position = nVec;
	}

}
