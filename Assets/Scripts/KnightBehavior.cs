using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KnightBehavior : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;
    public GameObject target;
    private LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("NPCState", 0);
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            agent.SetDestination(target.transform.position); // the path has been set
            lr.positionCount = agent.path.corners.Length;
            for (int i = 0; i < agent.path.corners.Length; i++)
                lr.SetPosition(i, agent.path.corners[i]);
        }
    }
}
