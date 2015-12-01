using UnityEngine;
using System.Collections;

public class ButtonActions : MonoBehaviour {

	public void Start_Game () {
		Application.LoadLevel ("Lvl1");
	}
	
	public void Show_Instructions(){
	}
	
	public void Quit_Game(){
		Application.Quit ();
	}	
}
