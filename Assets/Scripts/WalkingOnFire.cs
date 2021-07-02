using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingOnFire : MonoBehaviour
{
    public GameObject npc;
    private float npcSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == npc.gameObject.name) // if it is npc
        {
            NavMeshAgent nma = npc.GetComponent<NavMeshAgent>();
            npcSpeed = nma.speed;
            nma.speed = 1f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == npc.gameObject.name) // if it is npc
        {
            NavMeshAgent nma = npc.GetComponent<NavMeshAgent>();
            nma.speed = npcSpeed;
        }

    }
}
