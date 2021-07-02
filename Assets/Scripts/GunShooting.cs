using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GunShooting : MonoBehaviour
{
    public GameObject GunInHand;
    public GameObject aCamera;
    [SerializeField] public GameObject target;
    private LineRenderer lr;
    public GameObject MuzzleEnd;
    private AudioSource sound;
    public ParticleSystem MuzzleFlash;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        sound = GunInHand.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("TouchBtn") && GunInHand.activeSelf )
        {
            RaycastHit hit;
            if(Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
            {
                target.transform.position = hit.point;
                StartCoroutine(ShowShot());
                if(hit.transform.gameObject.name==Enemy.gameObject.name)
                {
                    Animator a = Enemy.GetComponent<Animator>();
                    a.SetInteger("NPCState", 2); // NPC dyes
                    NavMeshAgent nma= Enemy.GetComponent<NavMeshAgent>();
                    nma.enabled = false; // NPS stops moving
                    LineRenderer lr1 = Enemy.GetComponent<LineRenderer>();
                    lr1.enabled = false;

                }
            }
        }
    }
    public IEnumerator ShowShot()
    {
        lr.SetPosition(0, MuzzleEnd.transform.position);
        lr.SetPosition(1, target.transform.position);
        lr.enabled = true;
        target.SetActive(true);
        MuzzleFlash.Play();
        sound.Play();
        yield return new WaitForSeconds(0.1f);
        lr.enabled = false;
        target.SetActive(false);
    }
}
