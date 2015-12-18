using UnityEngine;
using System.Collections;

public class HeroScript : MonoBehaviour {

    public Animator anim;
    Vector3 inputVec;
    Vector3 targetDirection;
	int hitCount = 0;

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
}
    