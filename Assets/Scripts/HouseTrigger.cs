using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    public Animation probePanel;

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
        probePanel.Play("ShowUI");
        Cursor.visible = true;
    }


    private void OnTriggerExit(Collider other)
    {
        probePanel.Play("HideUI");
        Cursor.visible = false;
    }
}
