using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_highscore : MonoBehaviour
{
    public int highScore;
    string highScoreKey = "HighScore";

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        //use this value in whatever shows the leaderboard.
        GetComponent<UnityEngine.UI.Text>().text = highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
