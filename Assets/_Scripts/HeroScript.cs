using UnityEngine;
using System.Collections;

public class HeroScript : MonoBehaviour {

    public Animator anim;
    Vector3 inputVec;
    Vector3 targetDirection;

    public EnemyAI enemy;

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
            enemy.hitCount = enemy.hitCount + 1;
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
    }

    void UpdateMovement()
    {
        //get movement input from controls
        Vector3 motion = inputVec;

        //reduce input for diagonal movement
        motion *= (Mathf.Abs(inputVec.x) == 1 && Mathf.Abs(inputVec.z) == 1) ? .7f : 1;    
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Debug.Log(enemy.hitCount);
            if (enemy.hitCount > 1)
            {
                enemy.enemyAlive = false;
                enemy.Goblin.GetComponent<Animation>().Stop();
                enemy.Goblin.GetComponent<Animation>().Play("death");
                //Destroy(col.gameObject);
            }
        }
    }
}
    