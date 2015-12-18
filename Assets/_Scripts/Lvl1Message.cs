using UnityEngine;
using System.Collections;

public class Lvl1Message : MonoBehaviour {

	float timer = 0;
	bool guienable = true;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

			OnGUI ();

	}

	public void OnGUI(){
		if(guienable==true){
			GUI.Label (new Rect (400, 650, 300, 100), "Collect at least 5 gems before proceeding to next level");
			timer += Time.deltaTime;
			Debug.Log(timer);
			if (timer > 10.0f) {
				guienable = false;
				timer = 0;
			}
		}
	}
}
