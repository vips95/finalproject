using UnityEngine;
using System.Collections;

public class Player_Animations : MonoBehaviour {

    public GameObject Player;
   	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("s"))
        {
            Player.GetComponent<Animation>().Play("walk");
        }
        else if (Input.GetKey("space"))
        {
            Player.GetComponent<Animation>().Play("jump");
        }
        else if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey("w") || Input.GetKey("s")) )
        {
            Player.GetComponent<Animation>().Play("run");
        }
        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetMouseButton(0))
        {
            Player.GetComponent<Animation>().Play("attack");
        }   
        else
        {
            Player.GetComponent<Animation>().Play("idle");
        }
        
    }

   
}
