using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_exitbutton : MonoBehaviour
{

    public Button yourButton;
    public Image yourImage;
    public GameObject player;
    public GameObject menuplayer;

    // Start is called before the first frame update
    void Start()
    {
            yourButton.onClick.AddListener(TaskOnClick);

        
    }

    void TaskOnClick()
    {
        Application.Quit();
        Debug.Log("Exit");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
