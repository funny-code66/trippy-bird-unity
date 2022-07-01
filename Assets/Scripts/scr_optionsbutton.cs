using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using System;

public class scr_optionsbutton : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject settingsCanvas;

    public Button optionsButton;
    public Toggle fsToggle;

    // Start is called before the first frame update
    void Start()
    {
        
        optionsButton.onClick.AddListener(TaskOnClick);
        fsToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("Fullscreen", 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        mainCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }
}
