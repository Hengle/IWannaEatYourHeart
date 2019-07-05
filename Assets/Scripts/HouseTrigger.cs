using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    public ProbePanelUI probePanel;
    public bool marker = false;
    public bool[] probeables;
    public bool[] probed;

    private void Awake()
    {
        probeables = new bool[6];
        probed = new bool[6];
        for(int i = 0; i < 6; ++i)
        {
            probed[i] = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EndIfLeaveSeconds()
    {
        yield return new WaitForSeconds(0.8f);
        if (!entering)probePanel.HideProbePanel();
    }

    private bool entering = false;
    private void OnTriggerEnter(Collider other)
    {
        if (entering) return;
        entering = true;
        probePanel.ShowProbePanel(this);
    }


    private void OnTriggerExit(Collider other)
    {
        entering = false;
        StartCoroutine(EndIfLeaveSeconds());
    }
}
