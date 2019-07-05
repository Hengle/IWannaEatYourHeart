using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProbePanelUI : MonoBehaviour
{
    public Toggle toggle;

    private HouseTrigger houseTrigger = null;

    new Animation animation;
    private void Awake()
    {
        animation = GetComponent<Animation>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TRICK NEVER MIND
        if (houseTrigger)
        {
            Cursor.visible = true;
        }
    }

    public void ShowProbePanel(HouseTrigger house)
    {
        houseTrigger = house;
        animation.Play("ShowUI");
        Cursor.visible = true;
        toggle.isOn = houseTrigger.marker;
    }

    public void HideProbePanel()
    {
        houseTrigger = null;
        animation.Play("HideUI");
        Cursor.visible = false;
    }

    public void ChangeMarker(bool ifMarker)
    {
        if (houseTrigger)
        {
            houseTrigger.marker = ifMarker;
        }
    }
}
