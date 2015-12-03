using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour {
    
    public GameObject Player;
    public GameObject Enemy;
    
    public int health, enemyHealth;
    int currentHealth, HdamageCount, CdamageCount;
    bool playerFighting;
    public Text healthBar;
    public Text enemyHealthBar;
    float timer = 0.0f;
    public float originx, originy, originz; 
	
    // Use this for initialization
	void Start () {
        currentHealth = health;
        healthBar.text = "Health " + currentHealth + " / 100";
        enemyHealthBar.text = "Cyclocp's health " + enemyHealth;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Player fighting" + playerFighting);
         if (!playerFighting)
         {
             Debug.Log("heatlh " + currentHealth);
            if (currentHealth < 100)
                {
                
                timer += Time.deltaTime;
                Debug.Log(timer);
                if (timer > 3.0f)
                {
                    currentHealth = currentHealth + 10;
                    timer = 0.0f;
                }
            }
           
        }
     else
     {
         if (currentHealth == 0)
         {
             Player.transform.position = new Vector3(originx, originy, originz);
             currentHealth = 100;   
         }
     }

     healthBar.text = "Health " + currentHealth + " / 100";

	}

    public void ApplyDamage(int damage)
    {
        HdamageCount += damage;
        CdamageCount += damage;
        if (HdamageCount == 100)
        {
            currentHealth = currentHealth - 10;
            healthBar.text = "Health " + currentHealth + " / 100";
            HdamageCount = 0;
        }
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetMouseButton(0))
        {
            if (CdamageCount == 100)
            {
                enemyHealth -= 20;
                enemyHealthBar.text = "Cyclop's health " + enemyHealth;
                CdamageCount = 0;
                if (enemyHealth < 400 && enemyHealth >450 ) {
                    Enemy.GetComponent<Animation>().Play("stunned_idle");
                }
                else if (enemyHealth == 0)
                {
                    Enemy.GetComponent<Animation>().Play("death");
                }
            }
        }
    }

    public void playerInCombat(int combat)
    {
        if (combat == 1)
        {
            playerFighting = true;
        }
        else
        {
            playerFighting = false;
        }
    }
}
