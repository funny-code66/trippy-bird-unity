using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_score : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    string highScoreKey = "HighScore";

    public bool cansparkle;

    //public GameObject medal;
    public Image medalimage;
    public Sprite bronzemedal;
    public Sprite silvermedal;
    public Sprite goldmedal;
    public Sprite platinummedal;
    public Text text2;

    public GameObject NEW;
    public GameObject hs;

    private string usernameKey = "Username";
    public Text nameText;


    // Start is called before the first frame update
    void Start()
    {
        NEW.SetActive(false);
        cansparkle = false;
        //medalimage = medal.GetComponent<Image>();
        score = 0;
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        text2.text = GetComponent<Text>().text;
    }

    public void booga()
    {
         nameText.text = PlayerPrefs.GetString(usernameKey, "Guest");

        //If our scoree is greter than highscore, set new higscore and save.
        if (score >= highScore)
        {
            PlayerPrefs.SetInt(highScoreKey, score);
            PlayerPrefs.Save();
                      
            medalimage.sprite = platinummedal;
            cansparkle = true;

            if (score > highScore)
            {
                NEW.SetActive(true);
            }
            
        }
        else if (score >= (highScore * 0.75) && score < highScore) // if score is greater than or equal to 75% of highscore and less than highscore
        {
            medalimage.sprite = goldmedal;
            cansparkle = true;
            NEW.SetActive(false);
        }
        else if (score >= (highScore * 0.50) && score < highScore * 0.75) // if score is greater than or equal to 50% of highscore and less than 75% of highscore
        {
            medalimage.sprite = silvermedal;
            cansparkle = true;
            NEW.SetActive(false);
        }
        else if (score >= (highScore * 0.25) && score < highScore * 0.50) // if score is greater than or equal to 25% of highscore and less than 50% of highscore
        {
            medalimage.sprite = bronzemedal;
            cansparkle = true;
            NEW.SetActive(false);
        }
        else if (score < (highScore * 0.25)) // if score is less than to 25% of highscore
        {
            medalimage.sprite = null;
            medalimage.color = new Color(medalimage.color.r, medalimage.color.g, medalimage.color.b, 0f);
            cansparkle = false;
            NEW.SetActive(false);
        }

    }
}
