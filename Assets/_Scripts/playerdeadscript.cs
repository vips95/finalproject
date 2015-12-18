using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class playerdeadscript : MonoBehaviour {

	public Canvas quitmenu;
	public Canvas playerdead;
	public Button restart;
	public Button quit;
	public Text player;

	// Use this for initialization
	void Start () {
		playerdead = playerdead.GetComponent<Canvas>();
		restart = quit.GetComponent<Button> ();
		quit = restart.GetComponent<Button> ();
		player = player.GetComponent<Text> ();
		quitmenu.enabled = false;
		restart.enabled = true;
		quit.enabled = true;
		player.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void start_game () {
		Application.LoadLevel ("Level 1");
	}
	public void yes_press(){
		Application.Quit ();
	}
	public void NoPress() //this function will be used for our "NO" button in our Quit Menu
		
	{
		quitmenu.enabled = false;
		restart.enabled = true; //we'll disable the quit menu, meaning it won't be visible anymore
		quit.enabled = true; //enable the Play and Exit buttons again so they can be clicked
		player.enabled = true;

		
	}
	public void quit_game(){
		quitmenu.enabled = true;
		restart.enabled = false;
		player.enabled = false;
		quit.enabled = false;
	}
}
