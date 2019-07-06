using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NightLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(test());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator test()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("DayScene");
    }
}
