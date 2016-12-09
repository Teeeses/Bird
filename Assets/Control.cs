using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	GameObject leftControl;
	GameObject rightControl;
	public Camera mainCam, uiCam;

	// Use this for initialization
	void Start () {
		mainCam = Camera.main;
		uiCam = gameObject.GetComponent<Camera> ();

		leftControl = new GameObject ();
		leftControl.AddComponent<BoxCollider2D> ();
		rightControl = new GameObject ();
		rightControl.AddComponent<BoxCollider2D> ();
		Vector3 scale =  new Vector3 ((uiCam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - uiCam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x)/2, 
			(uiCam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - uiCam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y), 1);
		
		leftControl.transform.position = uiCam.ViewportToWorldPoint (new Vector3(.25f, .5f, 10));
		rightControl.transform.position = uiCam.ViewportToWorldPoint (new Vector3(.75f, .5f, 10));
		leftControl.transform.localScale = scale;
		rightControl.transform.localScale = scale;

		leftControl.name = "leftControl";
		rightControl.name = "rightControl";
		leftControl.layer = 5;
		rightControl.layer = 5;

		leftControl.transform.parent = transform;
		rightControl.transform.parent = transform;

		leftControl.AddComponent<leftClick>();
		rightControl.AddComponent<rightClick>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
