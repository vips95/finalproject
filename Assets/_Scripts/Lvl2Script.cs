using UnityEngine;
using System.Collections;

public class Lvl2Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Hero") { Application.LoadLevel("Level 3"); }
        
    }
}
