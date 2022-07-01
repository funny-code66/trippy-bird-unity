using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_pausebutton : MonoBehaviour
{
    public Button pauseButton;
    public Image pauseImage;
    public Sprite pausedSprite;
    public Sprite unpausedSprite;

    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
        pauseButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            pauseImage.sprite = unpausedSprite;
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            pauseImage.sprite = pausedSprite;
            Time.timeScale = 1;
        }
    }

    void TaskOnClick()
    {
        paused = !paused;
        Debug.Log("Paused/Unpaused");
    }
}
