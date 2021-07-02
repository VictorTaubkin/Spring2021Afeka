using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public GameObject npc;

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
        if(other.gameObject.name == npc.name)// choose new random location of target
        {
            float x, y, z;
            x = Random.Range(50, 150);
            z = Random.Range(-40, 200);
            y = Terrain.activeTerrain.SampleHeight(new Vector3(x, 0, z));
            this.transform.position = new Vector3(x,y,z);
        }
    }
}
