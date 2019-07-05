using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Logic logic;

    private new Light light;

    private void Awake()
    {
        light = GetComponent<Light>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        light.intensity =Mathf.Lerp(0,1,logic.timeLimitSlider.value);
    }
}
