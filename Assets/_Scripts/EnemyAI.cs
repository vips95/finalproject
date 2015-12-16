using UnityEngine;
using System.Collections;


public class EnemyAI : MonoBehaviour {

public Animation anim;
public GameObject Hero;
public GameObject Goblin;
public float distance;
float time;

int hitCount = 3;
int damageCount;

private Vector3 _destination;

	// Use this for initialization
	void Start () {
        //enemyAlive = true;
	}
	
	// Update is called once per frame
    void Update()
    {
        enemyAI();
    }

    void enemyAI()
    {
        if (hitCount > 0)
        {
            distance = Vector3.Distance(Goblin.transform.position, Hero.transform.position);
            if (distance >= 6)
            {
                Goblin.transform.position = Vector3.MoveTowards(Goblin.transform.position, Hero.transform.position, 0.15f);
                Vector3 targetDir = Hero.transform.position - Goblin.transform.position;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 1, 0.0F);
                Debug.DrawRay(transform.position, newDir, Color.red);
                transform.rotation = Quaternion.LookRotation(newDir);
                Goblin.GetComponent<Animation>().Play("run");
            }

            if (distance < 6)
            {
                Goblin.GetComponent<Animation>().Stop("run");
                Goblin.GetComponent<Animation>().Play("attack1");
            }
        }
        else
        {
            Goblin.GetComponent<Animation>().Stop("run");
            Goblin.GetComponent<Animation>().Stop("attack1");
            Goblin.GetComponent<Animation>().Play("death");
            time += Time.deltaTime;
            if (time >= 2.75f)
                DestroyObject(this.gameObject);
        }

	}

    public void ApplyDamage()
    {
        Debug.Log("Hitting");
         hitCount -= 1;
         Debug.Log(hitCount);
    }


    
}


