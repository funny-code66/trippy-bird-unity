using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_mute : MonoBehaviour
{
    public Toggle mt;

    // Start is called before the first frame update
    void Start()
    {
        //mt.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mt.isOn)
        {
            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = 1f;
        }
    }
}
