using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    private int round = 0;
    public int maxRound = 3;

    private int probeCount = 0;
    public int maxProbeCount = 5;

    public float timelimit = 10.0f;
    private float timer = 0.0f;

    public Animation newRoundUI;
    public Slider timeLimitSlider;

    // Start is called before the first frame update
    void Start()
    {
        ResetRound();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timelimit)
        {
            EndRound();
        }
        timeLimitSlider.value =  (timelimit-timer) / timelimit;
    }


    void ResetRound()
    {
        timer = 0;
        round += 1;
        probeCount = maxProbeCount;

        newRoundUI.Play();
        newRoundUI.GetComponentInChildren<Text>().text = "第"+round+"天白天";
        
    }

    void EndRound()
    {
        ResetRound();
    }

}
