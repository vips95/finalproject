using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lvl1InstScript : MonoBehaviour {

	float timer = 0;
	bool guiEnable;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		OnGUI ();
	}
	public void OnGUI(){
		if (guiEnable) {
			GUI.Label (new Rect (350, 350, 300, 100), "You should collect at least 5 gems before you can enter next level");
			timer += Time.deltaTime;
			if (timer > 10.0f) {
				guiEnable = false;
				timer = 0;
			}
		}
	}
}
