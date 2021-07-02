using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SpeedSliderBehavior : MonoBehaviour
{
  
    public Text speedText;
    private Slider speedSlider;
    // Start is called before the first frame update
    void Start()
    {
        //    speedText = GetComponent<TextMeshPro>();
        speedSlider = GetComponent<Slider>();
    }

    public void UpdateSpeed()
    {
        speedText.text = "SPEED:   " + ((int)speedSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
