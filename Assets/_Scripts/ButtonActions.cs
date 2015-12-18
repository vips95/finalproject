using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonActions : MonoBehaviour {
	public Canvas quitMenu;
	public Canvas instructionMenu;
	public Button startText;
	public Button exitText;
	public Button instructionText;


	void Start ()
		
	{
		quitMenu = quitMenu.GetComponent<Canvas>();
		instructionMenu = instructionMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		instructionText = instructionText.GetComponent<Button> ();
		quitMenu.enabled = false;
		instructionText.enabled = true;
		instructionMenu.enabled = false;
		
	}

	public void NoPress() //this function will be used for our "NO" button in our Quit Menu
		
	{
		quitMenu.enabled = false; //we'll disable the quit menu, meaning it won't be visible anymore
		startText.enabled = true; //enable the Play and Exit buttons again so they can be clicked
		exitText.enabled = true;
		instructionText.enabled = true;
		instructionMenu.enabled = false;
		
	}

	public void YesPress() //this function will be used for our "NO" button in our Quit Menu
		
	{
		Application.Quit ();
	}


	public void Start_Game () {
		Application.LoadLevel ("Level 1");
	}


	public void Instruction_game() {

		quitMenu.enabled = false;
		startText.enabled = false;
		exitText.enabled = false;
		instructionText.enabled = false;
		instructionMenu.enabled = true;

	}
	
	public void Quit_Game(){
		quitMenu.enabled = true; //enable the Quit menu when we click the Exit button
		startText.enabled = false; //then disable the Play and Exit buttons so they cannot be clicked
		exitText.enabled = false;
		instructionText.enabled = false;
		instructionMenu.enabled = false;
	}	

}









