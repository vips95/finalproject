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

	float healthTimer = 0.0f;
	bool healthshouldRespawn = false;

	public GameObject healthbottle;

    public float originx, originy, originz; 
	
    // Use this for initialization
	void Start () {
        currentHealth = health;
        healthBar.text = "Health " + currentHealth + " / 100";
        Debug.Log("enemy health : " + enemyHeal th);
        enemyHealthBar.text = "Cyclocp's health " + enemyHealth;
	}
	
	// Update is called once per frame
	void Update () {
        
         if (!playerFighting)
         {
             Debug.Log("heatlh " + currentHealth);
            if (currentHealth < 100)
                {
                
                timer += Time.deltaTime;
                Debug.Log(timer);
                if (timer > 5.0f)
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
		if (healthshouldRespawn ) {
			healthTimer += Time.deltaTime;

			if(healthTimer > 5.0f)
			{
				healthbottle.gameObject.SetActive(true);
				healthTimer = 0.0f;
			}
		}
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
                if (enemyHealth == 0)
                {
                    Enemy.GetComponent<Animation>().Stop("attack_2");
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

	void OnTriggerEnter(Collider item)
	{
		if (item.gameObject.tag == "PlayerHealthBottle") {

	        if(currentHealth < 100)
			    {
				currentHealth = currentHealth +10;
				item.gameObject.SetActive(false);
				healthshouldRespawn = true;
			    }
		}
			}
}
