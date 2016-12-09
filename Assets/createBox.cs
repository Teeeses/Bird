using UnityEngine;
using System.Collections;

public class createBox : MonoBehaviour {

	public float i;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		i += Time.deltaTime;
		if (i > 0.2f) {
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			DestroyImmediate (cube.GetComponent<BoxCollider> ());
			cube.AddComponent<Rigidbody2D>();
			cube.AddComponent<BoxCollider2D> ();
			cube.GetComponent<Rigidbody2D> ().mass = 100f;
			cube.transform.localScale = new Vector3 (0.5f, 0.5f, 0);
			cube.transform.position = new Vector3 (0, 0, -10);
			i = 0;
		}
	}

}
