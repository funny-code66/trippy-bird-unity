using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_fullscreen : MonoBehaviour
{
    public Toggle tt;

    // Start is called before the first frame update
    void Start()
    {
        //tt.isOn = false;
        tt.onValueChanged.AddListener(delegate {
            ToggleValueChanged(tt);
        });

        if (Screen.fullScreen == true)
        {
            tt.isOn = true;
        }

        if (Screen.fullScreen == false)
        {
            tt.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ToggleValueChanged(Toggle change)
    {
        //m_Text.text = "New Value : " + m_Toggle.isOn;
        Screen.fullScreen = !Screen.fullScreen;
        //tt.isOn = !tt.isOn;
        Debug.Log("You pressed the toggle.");
    }
}
