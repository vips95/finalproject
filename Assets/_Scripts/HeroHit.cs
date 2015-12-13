using UnityEngine;
using System.Collections;

public class HeroHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void onCollisionEnter(Collision othercollider)
    {
        Debug.Log(othercollider.collider.gameObject.name);
    }
}
