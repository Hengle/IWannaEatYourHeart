using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    [HideInInspector]
    public int round = 0;
    public int maxRound = 3;
    [HideInInspector]
    public int probeCount = 0;
    public int maxProbeCount = 5;

    public float timelimit = 10.0f;
    private float timer = 0.0f;

    public Animation newRoundUI;
    public Animation endRoundUI;
    public Animation movementPanel;
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
        if(timer >= timelimit && !pauseTimer)
        {
            EndRound();
        }
        timeLimitSlider.value =  (timelimit-timer) / timelimit;

        //跳过白天
        if(probeCount <= 0 && Input.GetKey(KeyCode.Escape))
        {
            EndRound();
        }
    }


    public void ResetRound()
    {
        timer = 0;
        round += 1;
        probeCount = maxProbeCount;

        newRoundUI.Play();
        newRoundUI.GetComponentInChildren<Text>().text = "第"+round+"天白天";
        
    }

    private bool pauseTimer = false;
    public void EndRound()
    {
        pauseTimer = true;
        endRoundUI.Play();
        endRoundUI.GetComponentInChildren<Text>().text = "第" + round + "天白天已结束";
        StartCoroutine(ShowMovementPanel());
        //ResetRound();
    }

    IEnumerator ShowMovementPanel(){
        yield return new WaitForSeconds(3.0f);
        movementPanel.Play();
    }
    

}
