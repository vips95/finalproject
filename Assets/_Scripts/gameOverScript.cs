using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class gameOverScript : MonoBehaviour {
    public Canvas quitmenu;
    public Button Restart;
    public Button quit;
    public Text score;
    public Text gamecomplete;
	// Use this for initialization
	void Start () {
        quitmenu = quitmenu.GetComponent<Canvas>();
        Restart = Restart.GetComponent<Button>();
        quit = quit.GetComponent<Button>();
        score = score.GetComponent<Text>();
        gamecomplete = gamecomplete.GetComponent<Text>();
        quit.enabled = true;
        Restart.enabled = true;
        score.enabled = true;
        gamecomplete.enabled = true;
		quitmenu.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void restart_game()
    {
		Application.LoadLevel ("Level 1");
    }
   public void quit_game()
    {
        quitmenu.enabled = true;
        Restart.enabled = false;
        quit.enabled = false;
        score.enabled = false;
        gamecomplete.enabled = false;
    }
   public void nopress()
    {
        Restart.enabled = true;
        quit.enabled = true;
        score.enabled = true;
            gamecomplete.enabled = true;
            quitmenu.enabled = false;
    }
   public void yespress()
    {
        Application.Quit();
    }
}
