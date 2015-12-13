using UnityEngine;
using System.Collections;

public class Lvl1ChestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update ()
    {

    }
	void OnTriggerEnter (Collider col) {
        Debug.Log("Hero");
        if(col.CompareTag("Hero")){Application.LoadLevel("Lvl2");
        }
	}
}
