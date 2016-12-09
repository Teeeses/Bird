using UnityEngine;
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
		
/*		var vertExtent = Camera.main.orthographicSize;
		var horzExtent = vertExtent * Screen.width / Screen.height;

		minX = horzExtent - mapX / 2.0f;
		maxX = mapX / 2.0f - horzExtent;
		minY = vertExtent - mapY / 2.0f;
		maxY = mapY / 2.0f - vertExtent;*/
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

		/*if (player.position.y < camera.ViewportToWorldPoint (new Vector3 (player.position.x, .3f,  -50)).y) {
			if (getBottomBound () > bottomBorder.position.y) {
				transform.position = Vector3.Slerp (transform.position, player.position, cameraSpeed * Time.deltaTime);		
			}
		}

		if (player.position.y > camera.ViewportToWorldPoint (new Vector3 (player.position.x, .7f,  -50)).y) {
			if (getTopBound () < topBorder.position.y) {
				transform.position = Vector3.Slerp (transform.position, player.position, cameraSpeed * Time.deltaTime);		
			}
		}*/


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
			
}
