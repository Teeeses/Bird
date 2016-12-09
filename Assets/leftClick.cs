using UnityEngine;
using System.Collections;

public class leftClick : MonoBehaviour {


	BirdController controller;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag ("Player").GetComponent<BirdController>();
	}

	void OnMouseDown() 
	{
		controller.MoveLeft ();
	}
}
