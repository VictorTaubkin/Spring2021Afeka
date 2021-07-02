using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingGrenade : MonoBehaviour
{
    private bool isThrown = false;
    public GameObject player;
    public GameObject explosion;
    public GameObject part1;
    public GameObject part2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("q"))
        {
            if (!isThrown)
            {
                isThrown = true;
                ThrowGrenade();
            }
        }
    }

    void ThrowGrenade()
    {
        Vector3 direction = player.transform.forward * 12;
        direction.y = 5;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.AddForce(direction,ForceMode.Impulse);
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(1.5f);
        explosion.SetActive(true);
        part1.SetActive(false);
        part2.SetActive(false);
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
        // Apply explosion on nearby object 
        Collider[] objectsCollider = Physics.OverlapSphere(transform.position, 20);
        for(int i = 0; i<objectsCollider.Length;i++)
        {
            if(objectsCollider[i]!=null)
            {
                Rigidbody rbo = objectsCollider[i].GetComponent<Rigidbody>();
                if(rbo!=null)
                    rbo.AddExplosionForce(1500.0f, transform.position, 20);
            }
        }
    }
}
