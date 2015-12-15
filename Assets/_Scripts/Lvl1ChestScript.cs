using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lvl1ChestScript : MonoBehaviour {
    public Text GemText;
    public int GemCount = 0;
    bool guiEnable = false;
	float timer = 0;

	// Use this for initialization
	void Start () {
        GemText.text = "Gems Collected " + GemCount + "/5";
    }
	
	// Update is called once per frame
    void Update ()
    {
		GemText.text = "Gems Collected " + GemCount + "/5";
    }

	void OnTriggerEnter (Collider col) {
        if (GemCount >= 5 && col.name == "Hero")
        {
			Application.LoadLevel ("Level 2");
		} else {
			if (col.name == "Hero") {
				guiEnable = true;
				OnGUI();
			}
		}

	}

	public void OnGUI(){
		if (guiEnable) {
			GUI.Label (new Rect (350, 350, 300, 100), "You should collect at least 5 gems before you can enter next level");
            timer += Time.deltaTime;
			if(timer > 5.0f){
				guiEnable = false;
				timer = 0;
			}
		}

   
  
}

}