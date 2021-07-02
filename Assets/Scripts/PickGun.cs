using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGun : MonoBehaviour
{
    public GameObject gunInDrawer;
    public GameObject gunInHand;

    private void OnMouseDown()
    {
        gunInDrawer.SetActive(false);
        gunInHand.SetActive(true);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
