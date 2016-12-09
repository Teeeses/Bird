using UnityEngine;
using System.Collections;

public class lookerPlayer : MonoBehaviour {

	GameObject player;

	public Transform bottomBorder;
	private Camera camera;
	private float cameraSpeed = 4f;

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera> ();
		player = GameObject.FindGameObjectWithTag ("Player");

		float verticalSize   = Camera.main.orthographicSize * 2;
		float horizontalSize = verticalSize * Screen.width / Screen.height;

		transform.localScale = new Vector3 (horizontalSize, verticalSize, -50);
	}
	
	// Update is called once per frame
	void Update () {
		/*Vector3 vec = player.transform.position;
		vec.x = 0;
		vec.z = -50;
		transform.position = vec;*/


		Vector3 v = player.transform.position;
		v.x = 0;
		v.z = -50;
		if (player.transform.position.y < camera.ViewportToWorldPoint (new Vector3 (player.transform.position.x, .5f, -50)).y) {
			if (getBottomBound () + 4 > bottomBorder.position.y) {
				transform.position = Vector3.Slerp (transform.position, v, cameraSpeed * Time.deltaTime);		
			}
		}

		if (player.transform.position.y > camera.ViewportToWorldPoint (new Vector3 (player.transform.position.x, .5f, -50)).y) {
				transform.position = Vector3.Slerp (transform.position, v, cameraSpeed * Time.deltaTime);		
		}
	}



	private float getBottomBound(){
		return camera.ViewportToWorldPoint (new Vector3(0, 0, -50)).y;
	}
}

/*using UnityEngine;
using System.Collections;

public class notLeavingBorder : MonoBehaviour {

	public Transform player;
	public Transform leftBorder;
	public Transform rightBorder;
	public Transform bottomBorder;
	public Transform topBorder;
	private Camera camera;
	private float cameraSpeed=.8f;

	void Start () {

		camera = GetComponent<Camera> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;

				var vertExtent = Camera.main.orthographicSize;
		var horzExtent = vertExtent * Screen.width / Screen.height;

		minX = horzExtent - mapX / 2.0f;
		maxX = mapX / 2.0f - horzExtent;
		minY = vertExtent - mapY / 2.0f;
		maxY = mapY / 2.0f - vertExtent;
	}

	void Update () {

		Vector3 v = player.position;
		v.z = -50;
		if (player.position.x < camera.ViewportToWorldPoint (new Vector3 (.3f, player.position.y, -50)).x) {
			if (getLeftBound () > leftBorder.position.x) {
				transform.position = Vector3.Slerp (transform.position, v, cameraSpeed * Time.deltaTime);		
			}
		}

		if (player.position.x > camera.ViewportToWorldPoint (new Vector3 (.7f, player.position.y, -50)).x) {
			if (getRightBound () < rightBorder.position.x) {
				transform.position = Vector3.Slerp (transform.position, v, cameraSpeed * Time.deltaTime);		
			}
		}



	}


	private float getLeftBound(){
		return camera.ViewportToWorldPoint (new Vector3(0, 0, -50)).x;
	}

	private float getRightBound(){
		return camera.ViewportToWorldPoint (new Vector3(1, 0, -50)).x;
	}

	private float getBottomBound(){
		return camera.ViewportToWorldPoint (new Vector3(0, 0, -50)).y;
	}

	private float getTopBound(){
		return camera.ViewportToWorldPoint (new Vector3(0, 1, -50)).y;
	}

}*/

