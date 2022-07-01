using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_changeMusic : MonoBehaviour
{
    public AudioClip[] musics;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        int num = Random.Range(0, 8);
        GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>().clip = musics[num];
        GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>().Play();
    }
}
