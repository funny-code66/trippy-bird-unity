using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class scr_settingsmenu : MonoBehaviour
{
    public int birdIndex;
    string birdIndexKey = "BirdIndex";

    public int bgIndex;
    string bgIndexKey = "BgIndex";

    public int pipeIndex;
    string pipeIndexKey = "PipeIndex";

    public int fs;
    string fsKey = "Fullscreen";


    public Button okButton;
    public GameObject mainCanvas;
    public GameObject settingsCanvas;
    public Dropdown birdDropdown;
    public Dropdown bgDropdown;
    public Dropdown pipeDropdown;
    public Toggle fsToggle;
    public Text fsToggleText;

    // Start is called before the first frame update
    void Start()
    {
        birdIndex = PlayerPrefs.GetInt(birdIndexKey, 0);
        okButton.onClick.AddListener(TaskOnClick);
        birdDropdown.value = PlayerPrefs.GetInt(birdIndexKey, 0);
        bgDropdown.value = PlayerPrefs.GetInt(bgIndexKey, 0);
        pipeDropdown.value = PlayerPrefs.GetInt(pipeIndexKey, 1);

        if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("This is Android");
            fsToggle.isOn = true;
            fsToggle.interactable = false;
            fsToggleText.color = new Color(88/255f, 88/255f, 88/255f);
        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            Debug.Log("This is Windows");
            fsToggle.interactable = true;
            fsToggleText.color = new Color(50/255f, 50/255f, 50/255f);
        }


        //if (PlayerPrefs.GetInt(fsKey) == 0)
        //{
        //    fsToggle.isOn = false;
        //}
        //else if (PlayerPrefs.GetInt(fsKey) == 1)
        //{
        //    fsToggle.isOn = true;
        //}
        //else
        //{
        //    PlayerPrefs.GetInt(fsKey, 0);
        //}

        //fsToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt(fsKey, 0));
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //settingsCanvas.SetActive(false);
        //mainCanvas.SetActive(true);
    }

    public void SetBirdType (int birdIndex)
    {
        PlayerPrefs.SetInt(birdIndexKey, birdIndex);
        Debug.Log(birdIndex);
    }

    public void SetBgType(int bgIndex)
    {
        PlayerPrefs.SetInt(bgIndexKey, bgIndex);
        Debug.Log(bgIndex);
    }

    public void SetPipeType(int pipeIndex)
    {
        PlayerPrefs.SetInt(pipeIndexKey, pipeIndex);
        Debug.Log(pipeIndex);
    }

    public void SetFullscreen(bool fs)
    {
        PlayerPrefs.SetInt(fsKey, Convert.ToInt32(fs));
        Screen.fullScreen = fs;
        Debug.Log(fs);
    }

}
