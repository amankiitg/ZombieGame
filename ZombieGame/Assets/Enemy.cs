using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform goal;
    private NavMeshAgent agent;
    void Start()
    {
        goal = Camera.main.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;

        GetComponent<Animation>().Play("Z_Walk_InPlace");
        Debug.Log("Started");
    }

    // Update is called once per frame
    void Update()
    {
        goal = Camera.main.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    public void zombie_dead()
    {
        Debug.Log("Triggered");
        agent.isStopped = true;
        GetComponent<AudioSource>().Play();
        GetComponent<Animation>().Stop();
        GetComponent<Animation>().Play("Z_FallingBack");
        Destroy(gameObject, 2);
        GameObject zombie = Instantiate(Resources.Load("Zombie", typeof(GameObject))) as GameObject;
        float randomX  = UnityEngine.Random.Range(-64f,64f);
        float constantY = 0.01f;
        float randomZ = UnityEngine.Random.Range(30f,120f);
        zombie.transform.position = new Vector3(randomX,constantY,randomZ);
        while( Vector3.Distance(zombie.transform.position, Camera.main.transform.position)<=10){
            randomX  = UnityEngine.Random.Range(-64f,64f);
            randomZ  = UnityEngine.Random.Range(30f,120f);
            zombie.transform.position = new Vector3(randomX,constantY,randomZ);
        }
    }
    
    public void call_gun()
    {
        GameObject player = GameObject.Find("Player");
        Player player_controller = player.GetComponent<Player>();
        player_controller.shoot(); 
    }

}


