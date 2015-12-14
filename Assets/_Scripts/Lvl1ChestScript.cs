using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lvl1ChestScript : MonoBehaviour {
    public Text GemText;
    int GemCount = 0;
    bool guiEnable = false;
	float timer = 0;
	// Use this for initialization
	void Start () {
        GemText.text = "Gems Collected " + GemCount + "/5";
    }
	
	// Update is called once per frame
    void Update ()
    {

    }
	void OnTriggerEnter (Collider col) {
        Debug.Log(col.name);
        if (col.CompareTag("Hero"))
        {
            Debug.Log("Hero");
            if (GemCount == 5)
                    Application.LoadLevel("Level 2");
            else
            {
                guiEnable = true;
                OnGUI();
            }
        }
    }

    public void OnGUI()
    {
        while (guiEnable == true) {
            GUI.Label(new Rect(250, Screen.height / 2 - 25, Screen.width, 50), "message");
            timer += Time.deltaTime;
            if (timer == 5)
            {
                guiEnable = false;
                timer = 0;
            }
 
        }
        
    }
}

