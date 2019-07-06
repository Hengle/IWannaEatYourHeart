using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [HideInInspector]
    public float timer = 0.0f;

    public CharacterController player;
    public Transform spawnPoint;
    
    public Animation newRoundUI;
    public Animation endRoundUI;
    public Animation movementPanel;
    public Slider timeLimitSlider;



    public HouseTrigger[] houseTriggers;
    // Start is called before the first frame update
    void Start()
    {
        ResetRound();
    }


    private bool alreadyEnd = false;
    // Update is called once per frame
    void Update()
    {
        if (alreadyEnd) { return; }

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
        //TODO
        player.transform.position = spawnPoint.position;

        timer = 0;
        round += 1;
        probeCount = maxProbeCount;

        for(int i = 0; i< houseTriggers.Length; ++i)
        {
            for(int j =0;j<6; ++j)
            {
                houseTriggers[i].probed[j] = false;
            }
        }

        newRoundUI.Play();
        newRoundUI.GetComponentInChildren<Text>().text = "第"+round+"天白天";
        
    }

    private bool pauseTimer = false;
    public void EndRound()
    {
        alreadyEnd = true;
        timer = timelimit;
        pauseTimer = true;
        endRoundUI.Play();
        endRoundUI.GetComponentInChildren<Text>().text = "第" + round + "天白天已结束";
        StartCoroutine(ShowMovementPanel());
    }

    IEnumerator ShowMovementPanel(){
        yield return new WaitForSeconds(5.0f);
        movementPanel.Play("ShowMovement");
    }
    
    public void RunNewRound()
    {
        movementPanel.Play("EndMovement");
        ResetRound();
    }

    public void ChangeNightScene()
    {
        SceneManager.LoadScene("NightScene");
    }

}
