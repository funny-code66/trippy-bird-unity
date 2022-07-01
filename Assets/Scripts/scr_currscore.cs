using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_currscore : MonoBehaviour
{
    public int currscore;
    public GameObject scorecanvas;

    // Start is called before the first frame update
    void Start()
    {
        currscore = scorecanvas.GetComponent<scr_score>().score;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = currscore.ToString();
    }
}
