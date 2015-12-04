using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 180, 0) * Time.deltaTime * 6);
		transform.Translate (new Vector3 (0, 0, Mathf.Sin (Time.time * 8)) * Time.deltaTime);
	}
}
