using UnityEngine;
using System.Collections;


public class EnemyAI : MonoBehaviour {

public Animation anim;
public GameObject Hero;
public GameObject Goblin;
public float distance;

public bool enemyAlive=true;
//float time = 0;
public int hitCount = 0;

private Vector3 _destination;

	// Use this for initialization
	void Start () {
        hitCount = 0;
        enemyAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (enemyAlive==true)
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

	}
}


