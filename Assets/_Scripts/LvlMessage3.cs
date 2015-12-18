using UnityEngine;
using System.Collections;

public class LvlMessage3 : MonoBehaviour {
	float timer = 0;
	bool guienable = true;
	GUIStyle largefont;
	GUIStyle smallfont;
	// Use this for initialization
	void Start () {
		largefont = new GUIStyle ();
		largefont.fontSize = 40;
		smallfont = new GUIStyle ();
		smallfont.fontSize = 30;
	}
	
	// Update is called once per frame
	void Update () {
		
		OnGUI ();
		
	}
	
	public void OnGUI(){
		GUI.contentColor = Color.black;
		
		if(guienable==true){
			GUI.Label (new Rect (100, 440, 300, 100), "Level 3",largefont); 
			GUI.Label (new Rect (10,500,300,100),"Kill the enemies and final boss demon \nand collect treasure to finish the game",smallfont);
			timer += Time.deltaTime;
			if (timer > 10.0f) {
				guienable = false;
				timer = 0;
			}
		}
	}
}
