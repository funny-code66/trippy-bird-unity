using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_pipemovement : MonoBehaviour
{
    public float pipespeed;

    public GameObject player;
    public GameObject pipe;
    public PolygonCollider2D pc;

    public Sprite greenpipe;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = this.GetComponent<PolygonCollider2D>();
        pc.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<scr_birdcontrols>().canjump == true)
        {
            transform.position += Vector3.left * pipespeed * Time.deltaTime;
        }
        else
        {
            //pc.enabled = false;
        }

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    /*void OnBecameInvisible()
    {
        Destroy(gameObject, 4);
    }*/

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //if (other.name == "yellowbird")
    // {
    // player.GetComponent<scr_birdcontrols>().canjump = false;
    //  Destroy(pipespawner);
    // pipespeed = 0f;
    //  ground.gameObject.GetComponent<Animator>().enabled = false;
    //Time.timeScale = 0;

    // }
    //}
}
