using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine.Animations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using TMPro;

public class scr_birdcontrols : MonoBehaviour
{
    public CanvasGroup myCG;
    private bool flash = false;

    //set the rigidbody2d and transform
    public Rigidbody2D rb2D;
    public Transform tf;

    public SpriteRenderer srbird;
    public Animator anbird;

    public AudioSource flapsound;
    public AudioSource hitsound;
    public AudioSource pointsound;
    public AudioSource diemenusound;

    public GameObject pipes;
    public GameObject pipesclone;
    public GameObject pipespawner;
    public GameObject ground;
    public GameObject pipePrefab;

    public GameObject scorecanvas;
    public GameObject scorecanvas2;
    public Canvas scoredaddy;

    public GameObject guidecanvas;

    public GameObject gameovercanvas;
    public GameObject groundOverlay;

    public SpriteRenderer startBird;
    public int sprindex;

    //public int score = 0;

    //variables that can be changed
    public float thrust = 3f;
    public float rotation = 0f;
    public float maxrot = 40f;
    public float minrot = -90f;

    //bool that checks if jumping or not
    public bool jumping;

    //bool that checks if can jump or not
    public bool canjump;
    public bool canguide;
    public bool canhit;

    public bool dead;

    public bool canlol;
    public bool isGameOver = false;

    //states 1 = intro, 2 = canguide, 3 = playing, 4 = dead
    public int state = 1;

    // Start is called before the first frame update
    void Start()
    {
        srbird.enabled = false;

        dead = false;
        canlol = false;
        state = 1;
        scoredaddy.gameObject.SetActive(false);
        gameovercanvas.SetActive(false);

        //score = 0;
        rb2D.bodyType = RigidbodyType2D.Static;

        canhit = true;
        canjump = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 2)
        {
            rb2D.bodyType = RigidbodyType2D.Static;
            guidecanvas.SetActive(true);
        }
        else if (state == 1)
        {
            srbird.enabled = false;
            guidecanvas.SetActive(false);
            rb2D.bodyType = RigidbodyType2D.Static;
        }
        else if (state == 3)
        {
            srbird.enabled = true;
            guidecanvas.SetActive(false);
            rb2D.bodyType = RigidbodyType2D.Dynamic;
        }

        if (flash)
        {

            myCG.alpha = myCG.alpha - Time.deltaTime;
            if (myCG.alpha <= 0)
            {
                myCG.alpha = 0;
                flash = false;
            }
        }

        //rotates the bird clockwise every frame
        if (canjump)
        {
            rotation -= 50f * Time.deltaTime;
            rb2D.angularVelocity = -0.7f;

            scoredaddy.gameObject.SetActive(true);
        }

        //doesn't let the bird move left or right
        tf.position = new Vector3(-0.32f, tf.position.y, tf.position.z);
        
        if (rotation < minrot)
        {
            rotation = minrot;
        }

        if (rotation > maxrot)
        {
            rotation = maxrot;
        }

        tf.rotation = Quaternion.Euler(0, 0, rotation);

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space") || Input.GetKeyDown("up")) 
        {
            jumping = true;

        }

        if (jumping && canlol && state == 2)
        {
            state = 3;
            canlol = false;
            canjump = true;
        }

        //this happens when jumping is true
        if (jumping && canjump)
        {
            flapsound.Play();

            rb2D.velocity = Vector2.up * thrust;

            rotation = 14f;
            rb2D.angularVelocity = -200f;

            tf.rotation = Quaternion.Euler(0, 0, rotation);

            jumping = false;
        }

        if (dead)
        {
            GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other is BoxCollider2D && other.name != "ground")
        {
            scorecanvas.GetComponent<scr_score>().score += 1;
            scorecanvas2.GetComponent<scr_score>().score += 1;
            pointsound.Play();
            Destroy(other.gameObject);
        }
        else
        {
            if (canhit)
            {
                //GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>().mute = true;
                hitsound.Play();
                diemenusound.PlayDelayed(0.7f);
                canhit = false;
                flashscreen();

                GameObject[] coins = GameObject.FindGameObjectsWithTag("coin");
                for (int i = 0; i < coins.Length; i++)
                {
                    coins[i].GetComponent<BoxCollider2D>().enabled = false;
                }

                scorecanvas.gameObject.GetComponent<scr_score>().booga();
            }

            dead = true;
            canjump = false;
            pipes.GetComponent<scr_pipemovement>().pipespeed = 0f;
            Destroy(pipespawner);

            if (other.name == "ground")
            {
                dead = true;
                state = 1;
                canjump = false;
                tf.rotation = Quaternion.Euler(0, 0, minrot);
                rb2D.bodyType = RigidbodyType2D.Static;
            }
        }
    }

    void GameOver()
    {
        gameovercanvas.SetActive(true);
        scoredaddy.enabled = false;
        dead = false;
        isGameOver = true;
    }

    public void restart()
    {
        gameovercanvas.SetActive(false);
        dead = false;
        isGameOver = false;
        canhit = true;
        canjump = false;
        state = 2;
        guidecanvas.SetActive(true);
        transform.position = new Vector3(-0.32f, 0.6f, 0);
    }

    void flashscreen()
    {
        flash = true;
        myCG.alpha = 1;
    }
}
