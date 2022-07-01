using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_guidebutton : MonoBehaviour
{

    public Button thisButton;
    public Image yourImage;
    public GameObject player;
    public GameObject menuplayer;
    public GameObject thiscanvas;
    

    // Start is called before the first frame update
    void Start()
    {
            thisButton.onClick.AddListener(TaskOnClick);

        
    }

    void TaskOnClick()
    {
        //Instantiate(player);
        //player.SetActive(true);
        //player.GetComponent<scr_birdcontrols>().canjump = true;
        player.GetComponent<scr_birdcontrols>().state = 3;
        player.GetComponent<scr_birdcontrols>().canlol = true;
        player.GetComponent<scr_birdcontrols>().canjump = true;
        //player.GetComponent<scr_birdcontrols>().rb2D.bodyType = RigidbodyType2D.Dynamic;
        Destroy(yourImage);
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("up"))
        {
            TaskOnClick();
        }
    }
}
