using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeroScript : MonoBehaviour {

	public GameObject Player;
	public GameObject Enemy;

	public int health, enemyHealth;
	int currentHealth, HdamageCount, CdamageCount;
	public Text healthBar;
	public Text enemyHealthBar;
    public Animator anim;
    Vector3 inputVec;
    Vector3 targetDirection;
	int hitCount = 0;
	float timer = 0.0f;
	bool playerFighting;
	public float originx, originy, originz; 
	
	public EnemyAI enemy;

	void Start () {
		currentHealth = health;
		healthBar.text = "Health " + currentHealth + " / 10";
		enemyHealthBar.text = "Cyclocp's health " + enemyHealth;
		if (enemyHealth == 0) {
			Enemy.GetComponent<Animation> ().Play ("death");
		}
	}

    void Update()
    {
        //Get input from controls
        float z = Input.GetAxisRaw("Horizontal");
        float x = -(Input.GetAxisRaw("Vertical"));
        inputVec = new Vector3(x, 0, z);

        //Apply inputs to animator
        anim.SetFloat("Input X", z);
        anim.SetFloat("Input Z", -(x));

        if (x != 0 || z != 0)  //if there is some input
        {
            //set that character is moving
            anim.SetBool("Moving", true);
        }
        else
        {
            //character is not moving
            anim.SetBool("Moving", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("attack_1");
			hitCount += 1;
            
        }
		
		 if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("Jump");     
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }

        UpdateMovement();  //update character position and facing

		Debug.Log("Player fighting" + playerFighting);
		if (!playerFighting)
		{
			Debug.Log("heatlh " + currentHealth);
			if (currentHealth < 10)
			{
				
				timer += Time.deltaTime;
				Debug.Log(timer);
				if (timer > 3.0f)
				{
					currentHealth = currentHealth + 1;
					timer = 0.0f;
				}
			}
			
		}
		else
		{
			if (currentHealth == 0)
			{
				Player.transform.position = new Vector3(originx, originy, originz);
				currentHealth = 10;   
			}
		}
		
		healthBar.text = "Health " + currentHealth + " / 10";

	}
	
	void UpdateMovement()
	{
		//get movement input from controls
		Vector3 motion = inputVec;
		
		//reduce input for diagonal movement
		motion *= (Mathf.Abs(inputVec.x) == 1 && Mathf.Abs(inputVec.z) == 1) ? .7f : 1;    
    }

	void OnTriggerEnter(Collider col){

		Debug.Log(col.gameObject);
		if(col.gameObject.CompareTag("Enemy"))
			Destroy (col.gameObject);

	}
	public void ApplyDamage(int damage)
	{
		HdamageCount += damage;
		CdamageCount += damage;
		if (HdamageCount == 10)
		{
			currentHealth = currentHealth - 2;
			healthBar.text = "Health " + currentHealth + " / 10";
			HdamageCount = 0;
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
    